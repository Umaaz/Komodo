using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Komodo.App.Contorllers;
using Komodo.Core.Database;
using Komodo.Core.Database.Commands;
using Komodo.Core.Database.Index.Search;
using Komodo.Core.Types.Model;

namespace Komodo.App.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Context.Bootstrap();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            spcDetailView.Panel2Collapsed = SettingsController.GetDetialsShowen();
            btnDetails.Text = SettingsController.GetDetialsShowen() ? "Show" : "Hide";
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            SettingsController.ToggleDetailsShowen();
            spcDetailView.Panel2Collapsed = SettingsController.GetDetialsShowen();
            btnDetails.Text = SettingsController.GetDetialsShowen() ? "Show" : "Hide";
        }

        private void ListFilms(List<Film> films)
        {
            listView1.Items.Clear();
            foreach (var film in films)
            {
                var genres = film.Genres.Aggregate("", (current, genre) => current + (genre.GenreName + ", "));
                var stars = "";
                int[] i = { 0 };
                foreach (var star in film.Cast.Where(star => i[0] < 5))
                {
                    stars += star.Actor.Name + ", ";
                    i[0]++;
                }
                listView1.Items.Add(new ListViewItem(new[] { film.Title, film.ReleaseDate, genres, stars }));
            }
        }

        private void BuildFilmLibrary()
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                var films = new Get().GetFilms();
                ListFilms(films);
            }
            else
            {
                var results = Search.SearchFilm(txtSearch.Text);
                var films = results.Select(result => new Get().GetFilm(new Guid(result))).ToList();
                ListFilms(films);
            }
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sett = new SettingsForm();
            sett.Show(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BuildFilmLibrary();
        }
    }
}
