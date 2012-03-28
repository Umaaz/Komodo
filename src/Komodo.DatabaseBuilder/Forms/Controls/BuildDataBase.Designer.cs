namespace Komodo.App.Forms.Controls
{
    partial class BuildDataBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddDirectory = new System.Windows.Forms.Button();
            this.btnDeleteDirectory = new System.Windows.Forms.Button();
            this.lsbDirectories = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddExtension = new System.Windows.Forms.Button();
            this.lsbExtensions = new System.Windows.Forms.ListBox();
            this.btnDeleteExtension = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCleanBuild = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.lblCurrentTaskObject = new System.Windows.Forms.Label();
            this.lblCurrentTask = new System.Windows.Forms.Label();
            this.pbBuildBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkRescan = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddDirectory);
            this.groupBox1.Controls.Add(this.btnDeleteDirectory);
            this.groupBox1.Controls.Add(this.lsbDirectories);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directories";
            // 
            // btnAddDirectory
            // 
            this.btnAddDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDirectory.Location = new System.Drawing.Point(115, 137);
            this.btnAddDirectory.Name = "btnAddDirectory";
            this.btnAddDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnAddDirectory.TabIndex = 2;
            this.btnAddDirectory.Text = "Add";
            this.btnAddDirectory.UseVisualStyleBackColor = true;
            this.btnAddDirectory.Click += new System.EventHandler(this.btnAddDirectory_Click);
            // 
            // btnDeleteDirectory
            // 
            this.btnDeleteDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDirectory.Location = new System.Drawing.Point(34, 137);
            this.btnDeleteDirectory.Name = "btnDeleteDirectory";
            this.btnDeleteDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDirectory.TabIndex = 1;
            this.btnDeleteDirectory.Text = "Delete";
            this.btnDeleteDirectory.UseVisualStyleBackColor = true;
            // 
            // lsbDirectories
            // 
            this.lsbDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbDirectories.FormattingEnabled = true;
            this.lsbDirectories.Location = new System.Drawing.Point(6, 19);
            this.lsbDirectories.Name = "lsbDirectories";
            this.lsbDirectories.Size = new System.Drawing.Size(182, 108);
            this.lsbDirectories.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddExtension);
            this.groupBox2.Controls.Add(this.lsbExtensions);
            this.groupBox2.Controls.Add(this.btnDeleteExtension);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 173);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Types";
            // 
            // btnAddExtension
            // 
            this.btnAddExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExtension.Location = new System.Drawing.Point(125, 137);
            this.btnAddExtension.Name = "btnAddExtension";
            this.btnAddExtension.Size = new System.Drawing.Size(75, 23);
            this.btnAddExtension.TabIndex = 5;
            this.btnAddExtension.Text = "Add";
            this.btnAddExtension.UseVisualStyleBackColor = true;
            // 
            // lsbExtensions
            // 
            this.lsbExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbExtensions.FormattingEnabled = true;
            this.lsbExtensions.Location = new System.Drawing.Point(6, 19);
            this.lsbExtensions.Name = "lsbExtensions";
            this.lsbExtensions.Size = new System.Drawing.Size(194, 108);
            this.lsbExtensions.TabIndex = 3;
            // 
            // btnDeleteExtension
            // 
            this.btnDeleteExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteExtension.Location = new System.Drawing.Point(44, 137);
            this.btnDeleteExtension.Name = "btnDeleteExtension";
            this.btnDeleteExtension.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteExtension.TabIndex = 4;
            this.btnDeleteExtension.Text = "Delete";
            this.btnDeleteExtension.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCleanBuild);
            this.groupBox3.Controls.Add(this.btnBuild);
            this.groupBox3.Controls.Add(this.lblCurrentTaskObject);
            this.groupBox3.Controls.Add(this.lblCurrentTask);
            this.groupBox3.Controls.Add(this.pbBuildBar);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblLastUpdate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 182);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Build";
            // 
            // btnCleanBuild
            // 
            this.btnCleanBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanBuild.Location = new System.Drawing.Point(243, 110);
            this.btnCleanBuild.Name = "btnCleanBuild";
            this.btnCleanBuild.Size = new System.Drawing.Size(75, 23);
            this.btnCleanBuild.TabIndex = 7;
            this.btnCleanBuild.Text = "Clean Build";
            this.btnCleanBuild.UseVisualStyleBackColor = true;
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Location = new System.Drawing.Point(324, 110);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 6;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // lblCurrentTaskObject
            // 
            this.lblCurrentTaskObject.AutoSize = true;
            this.lblCurrentTaskObject.Location = new System.Drawing.Point(6, 65);
            this.lblCurrentTaskObject.Name = "lblCurrentTaskObject";
            this.lblCurrentTaskObject.Size = new System.Drawing.Size(104, 13);
            this.lblCurrentTaskObject.TabIndex = 5;
            this.lblCurrentTaskObject.Text = "{Current task object}";
            this.lblCurrentTaskObject.Visible = false;
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.Location = new System.Drawing.Point(89, 40);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(24, 13);
            this.lblCurrentTask.TabIndex = 4;
            this.lblCurrentTask.Text = "Idle";
            // 
            // pbBuildBar
            // 
            this.pbBuildBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBuildBar.Location = new System.Drawing.Point(6, 81);
            this.pbBuildBar.Name = "pbBuildBar";
            this.pbBuildBar.Size = new System.Drawing.Size(393, 23);
            this.pbBuildBar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Current Task:";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(89, 16);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(105, 13);
            this.lblLastUpdate.TabIndex = 1;
            this.lblLastUpdate.Text = "{Date of last update}";
            this.lblLastUpdate.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Updated: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkRescan);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(410, 150);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // chkRescan
            // 
            this.chkRescan.AutoSize = true;
            this.chkRescan.Checked = global::Komodo.App.Properties.Settings.Default.ScanOnStartUp;
            this.chkRescan.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Komodo.App.Properties.Settings.Default, "ScanOnStartUp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkRescan.Location = new System.Drawing.Point(9, 19);
            this.chkRescan.Name = "chkRescan";
            this.chkRescan.Size = new System.Drawing.Size(113, 17);
            this.chkRescan.TabIndex = 0;
            this.chkRescan.Text = "Rescan on startup";
            this.chkRescan.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(410, 513);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(410, 327);
            this.splitContainer2.SplitterDistance = 173;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(410, 173);
            this.splitContainer3.SplitterDistance = 200;
            this.splitContainer3.TabIndex = 0;
            // 
            // BuildDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BuildDataBase";
            this.Size = new System.Drawing.Size(410, 513);
            this.Load += new System.EventHandler(this.BuildDataBase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddDirectory;
        private System.Windows.Forms.Button btnDeleteDirectory;
        private System.Windows.Forms.ListBox lsbDirectories;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddExtension;
        private System.Windows.Forms.ListBox lsbExtensions;
        private System.Windows.Forms.Button btnDeleteExtension;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCleanBuild;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label lblCurrentTaskObject;
        private System.Windows.Forms.Label lblCurrentTask;
        private System.Windows.Forms.ProgressBar pbBuildBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkRescan;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}
