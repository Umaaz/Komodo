using System;
using System.Windows.Forms;
using Komodo.DatabaseBuilder.Builder;
using Komodo.Scraper.Fetcher;

namespace Komodo.DatabaseBuilder
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog(this) != DialogResult.OK)
                return;
            txtBrowse.Text = fbd.SelectedPath;
            lbFiles.DataSource = FileFetcher.GetFoldersWithVideoFiles(txtBrowse.Text);
        }

        private void lbFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            var path = lbFiles.SelectedValue.ToString();
            var ff = new FilmFetcher(path.Remove(0, lbFiles.SelectedValue.ToString().LastIndexOf("\\") + 1));
            ff.Film.Files = FileFetcher.GetVideoFiles(path);
            textBox1.Text = ff.Film.ToString();
        }
    }
}
