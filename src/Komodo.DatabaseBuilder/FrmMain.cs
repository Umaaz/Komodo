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
            lbFiles.DataSource = FileFetcher.GetVideoFiles(txtBrowse.Text);
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filmFetcher = new FilmFetcher(lbFiles.SelectedValue.ToString());
            var film = filmFetcher.Film;
            if(film != null)
                textBox1.Text = film.ToString();
        }
    }
}
