using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Komodo.App.Builder;
using Komodo.App.Contorllers;
using Komodo.Core.Database.Commands;
using Komodo.Core.Types.Model;
using Komodo.Scraper.Fetcher;

namespace Komodo.App.Forms.Controls
{
    public partial class BuildDataBase : UserControl
    {
        public BuildDataBase()
        {
            InitializeComponent();
            Errors = new List<Film>();
        }

        private void BuildDataBase_Load(object sender, System.EventArgs e)
        {
            lsbDirectories.DataSource = SettingsController.GetWatchedFoldersAsArray();
            lsbExtensions.DataSource = SettingsController.GetFileExtensionsAsArray();
        }

        private void btnAddDirectory_Click(object sender, System.EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                SettingsController.AddWatchedFolders(fbd.SelectedPath);
            }
            lsbDirectories.DataSource = SettingsController.GetWatchedFoldersAsArray();
        }

        private void btnBuild_Click(object sender, System.EventArgs e)
        {
            var folders = new List<string>();
            foreach (var s in SettingsController.GetWatchedFoldersAsArray())
            {
                folders.AddRange(FileFetcher.GetFoldersWithVideoFiles(s));
            }
            var folders1 = new List<string>(folders);
            var i = ((folders.Count)/2);
            folders.RemoveRange(0, i);
            folders1.RemoveRange((folders1.Count) / 2, (folders1.Count) / 2);
            var sema = new Semaphore();
            var adfilm = new AddFilms(lblCurrentTaskObject, sema, lblCurrentTask,this);
            var dbbt = new DatabaseBuildThread(folders, lblCurrentTaskObject, sema, adfilm, lblCurrentTask);
            var dbbt1 = new DatabaseBuildThread(folders1, lblCurrentTaskObject, sema, adfilm, lblCurrentTask);
            lblCurrentTaskObject.Visible = true;
            lblCurrentTaskObject.Text = "";
            var dbbtThread = new Thread(dbbt.Run);
            var dbbtThread1 = new Thread(dbbt1.Run);
            var afThread = new Thread(adfilm.Run);
            dbbtThread.Start();
            dbbtThread1.Start();
            afThread.Start();
        }

        public List<Film> Errors { get; set; }

        public void ShowErrors()
        {
            MessageBox.Show(this, Errors.Aggregate("",(current, next) => current + next));
        }
    }

    internal class Semaphore
    {
        public int Count { get; private set; }

        public void Wait()
        {
            lock(this)
            {
                while (Count != 2)
                    Monitor.Wait(this);
                Count = 0;
                Monitor.Pulse(this);
            }
        }

        public void Signal()
        {
            lock(this)
            {
                Count++;
                Monitor.Pulse(this);
            }
        }

        public Semaphore()
        {
            Count = 0;
        }
    }

    internal class AddFilms
    {
        private readonly Label _label;
        private readonly Label _taskLabel;
        public List<Film> Films { get; private set; }
        public List<Film> Errors { get; private set; }
        private string _str;
        private string _str1;
        private readonly Semaphore _semaphore;
        private readonly BuildDataBase _form;
        public AddFilms(Label label, Semaphore semaphore, Label taskLabel, BuildDataBase form)
        {
            _label = label;
            _form = form;
            _taskLabel = taskLabel;
            _semaphore = semaphore;
            Films = new List<Film>();
            Errors = new List<Film>();
        }

        public void UpdateLabel()
        {
            _label.Text = _str;
        }

        public void UpdateTaskLabel()
        {
            _taskLabel.Text = _str1;
        }

        public void Run()
        {
            _semaphore.Wait();
            _str1 = "Adding Films";
            _taskLabel.BeginInvoke(new MethodInvoker(UpdateTaskLabel));
            foreach (var film in Films)
            {
                new Add().AddFilm(film);
                _str = "Adding " + film.Title;
                _label.BeginInvoke(new MethodInvoker(UpdateLabel));
            }
            _str1 = "Completed";
            _taskLabel.BeginInvoke(new MethodInvoker(UpdateTaskLabel));
            _form.Errors.AddRange(Errors);
            _form.BeginInvoke(new MethodInvoker(_form.ShowErrors));
        }
    }
    
    internal class DatabaseBuildThread
    {
        private readonly List<string> _folders;
        private readonly Label _label;
        private readonly Label _taskLabel;
        private string _str;
        private string _str1;
        private readonly Semaphore _semaphore;
        private readonly AddFilms _addFilms;
        public List<Film> Films { get; private set; }
        public List<Film> Errors { get; private set; }

        public DatabaseBuildThread(List<string> folders, Label label, Semaphore semaphore, AddFilms addfilms, Label taskLabel)
        {
            _folders = folders;
            _addFilms = addfilms;
            _taskLabel = taskLabel;
            _semaphore = semaphore;
            _label = label;
            Films = new List<Film>();
            Errors = new List<Film>();
        }

        public void UpdateLabel()
        {
            _label.Text = _str;
        }

        public void UpdateTaskLabel()
        {
            _taskLabel.Text = _str1;
        }
        
        public void Run()
        {
            _str1 = "Fetching Films";
            _taskLabel.BeginInvoke(new MethodInvoker(UpdateTaskLabel));
            foreach (var folder in _folders)
            {
                var title = folder.Remove(0, folder.LastIndexOf('\\') + 1);
                _str = "Searching for " + title;
                _label.BeginInvoke(new MethodInvoker(UpdateLabel));
                var film = new FilmFetcher(title).Film;
                if(film.Url == null)
                    Errors.Add(film);
                else
                    Films.Add(film);
            }
            _addFilms.Errors.AddRange(Errors);
            _addFilms.Films.AddRange(Films);
            _semaphore.Signal();
        }
    }
}
