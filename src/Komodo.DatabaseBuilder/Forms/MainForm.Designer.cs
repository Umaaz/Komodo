namespace Komodo.App.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spcSideMenu = new System.Windows.Forms.SplitContainer();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.spcSearchBar = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.spcDetailView = new System.Windows.Forms.SplitContainer();
            this.btnDetails = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSideMenu)).BeginInit();
            this.spcSideMenu.Panel1.SuspendLayout();
            this.spcSideMenu.Panel2.SuspendLayout();
            this.spcSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSearchBar)).BeginInit();
            this.spcSearchBar.Panel1.SuspendLayout();
            this.spcSearchBar.Panel2.SuspendLayout();
            this.spcSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcDetailView)).BeginInit();
            this.spcDetailView.Panel1.SuspendLayout();
            this.spcDetailView.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.settingsToolStripMenuItem.Text = "&Tools";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.settingsToolStripMenuItem1.Text = "&Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // spcSideMenu
            // 
            this.spcSideMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSideMenu.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcSideMenu.IsSplitterFixed = true;
            this.spcSideMenu.Location = new System.Drawing.Point(0, 24);
            this.spcSideMenu.Name = "spcSideMenu";
            // 
            // spcSideMenu.Panel1
            // 
            this.spcSideMenu.Panel1.Controls.Add(this.trvMenu);
            // 
            // spcSideMenu.Panel2
            // 
            this.spcSideMenu.Panel2.Controls.Add(this.spcSearchBar);
            this.spcSideMenu.Size = new System.Drawing.Size(732, 478);
            this.spcSideMenu.SplitterDistance = 149;
            this.spcSideMenu.TabIndex = 2;
            // 
            // trvMenu
            // 
            this.trvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenu.Location = new System.Drawing.Point(0, 0);
            this.trvMenu.Name = "trvMenu";
            this.trvMenu.Size = new System.Drawing.Size(149, 478);
            this.trvMenu.TabIndex = 0;
            // 
            // spcSearchBar
            // 
            this.spcSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSearchBar.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcSearchBar.IsSplitterFixed = true;
            this.spcSearchBar.Location = new System.Drawing.Point(0, 0);
            this.spcSearchBar.Name = "spcSearchBar";
            this.spcSearchBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcSearchBar.Panel1
            // 
            this.spcSearchBar.Panel1.Controls.Add(this.txtSearch);
            this.spcSearchBar.Panel1.Controls.Add(this.btnSearch);
            this.spcSearchBar.Panel1.Controls.Add(this.btnAdvanced);
            // 
            // spcSearchBar.Panel2
            // 
            this.spcSearchBar.Panel2.Controls.Add(this.spcDetailView);
            this.spcSearchBar.Size = new System.Drawing.Size(579, 478);
            this.spcSearchBar.SplitterDistance = 29;
            this.spcSearchBar.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(3, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(411, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(420, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvanced.Location = new System.Drawing.Point(501, 3);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(75, 23);
            this.btnAdvanced.TabIndex = 0;
            this.btnAdvanced.Text = "Advanced";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            // 
            // spcDetailView
            // 
            this.spcDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcDetailView.Location = new System.Drawing.Point(0, 0);
            this.spcDetailView.Name = "spcDetailView";
            this.spcDetailView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcDetailView.Panel1
            // 
            this.spcDetailView.Panel1.Controls.Add(this.btnDetails);
            this.spcDetailView.Panel1.Controls.Add(this.listView1);
            this.spcDetailView.Size = new System.Drawing.Size(579, 445);
            this.spcDetailView.SplitterDistance = 270;
            this.spcDetailView.TabIndex = 0;
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.Location = new System.Drawing.Point(501, 244);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "Hide";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(579, 238);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Release Year";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Genres";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stars";
            this.columnHeader3.Width = 120;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 502);
            this.Controls.Add(this.spcSideMenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Komodo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.spcSideMenu.Panel1.ResumeLayout(false);
            this.spcSideMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSideMenu)).EndInit();
            this.spcSideMenu.ResumeLayout(false);
            this.spcSearchBar.Panel1.ResumeLayout(false);
            this.spcSearchBar.Panel1.PerformLayout();
            this.spcSearchBar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSearchBar)).EndInit();
            this.spcSearchBar.ResumeLayout(false);
            this.spcDetailView.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcDetailView)).EndInit();
            this.spcDetailView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.SplitContainer spcSideMenu;
        private System.Windows.Forms.TreeView trvMenu;
        private System.Windows.Forms.SplitContainer spcSearchBar;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.SplitContainer spcDetailView;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnDetails;
    }
}