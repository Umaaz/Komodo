using System;
using System.Windows.Forms;
using Komodo.DatabaseBuilder.Builder;

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
    }
}
