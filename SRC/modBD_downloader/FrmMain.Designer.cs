namespace modBD_downloader {
    partial class FrmMain {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.grp_main = new System.Windows.Forms.GroupBox();
            this.chk_download_screenshots = new System.Windows.Forms.CheckBox();
            this.chk_download_description = new System.Windows.Forms.CheckBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.txt_savepath = new System.Windows.Forms.TextBox();
            this.chk_separate_folders = new System.Windows.Forms.CheckBox();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_link = new System.Windows.Forms.Label();
            this.grp_progress = new System.Windows.Forms.GroupBox();
            this.progressbar = new ColorProgressBar.ColorProgressBar();
            this.btn_about = new System.Windows.Forms.LinkLabel();
            this.lbl_standby = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grp_main.SuspendLayout();
            this.grp_progress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::modBD_downloader.Properties.Resources.bg_header;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(424, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_download
            // 
            this.btn_download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_download.Location = new System.Drawing.Point(293, 48);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(101, 34);
            this.btn_download.TabIndex = 1;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // grp_main
            // 
            this.grp_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_main.Controls.Add(this.chk_download_screenshots);
            this.grp_main.Controls.Add(this.chk_download_description);
            this.grp_main.Controls.Add(this.btn_browse);
            this.grp_main.Controls.Add(this.txt_savepath);
            this.grp_main.Controls.Add(this.chk_separate_folders);
            this.grp_main.Controls.Add(this.txt_link);
            this.grp_main.Controls.Add(this.label2);
            this.grp_main.Controls.Add(this.label_link);
            this.grp_main.Location = new System.Drawing.Point(12, 85);
            this.grp_main.Name = "grp_main";
            this.grp_main.Size = new System.Drawing.Size(400, 141);
            this.grp_main.TabIndex = 3;
            this.grp_main.TabStop = false;
            this.grp_main.Text = "Downloading:";
            // 
            // chk_download_screenshots
            // 
            this.chk_download_screenshots.AutoSize = true;
            this.chk_download_screenshots.Enabled = false;
            this.chk_download_screenshots.Location = new System.Drawing.Point(169, 62);
            this.chk_download_screenshots.Name = "chk_download_screenshots";
            this.chk_download_screenshots.Size = new System.Drawing.Size(120, 17);
            this.chk_download_screenshots.TabIndex = 5;
            this.chk_download_screenshots.Text = "Download Previews";
            this.chk_download_screenshots.UseVisualStyleBackColor = true;
            // 
            // chk_download_description
            // 
            this.chk_download_description.AutoSize = true;
            this.chk_download_description.Enabled = false;
            this.chk_download_description.Location = new System.Drawing.Point(169, 85);
            this.chk_download_description.Name = "chk_download_description";
            this.chk_download_description.Size = new System.Drawing.Size(173, 17);
            this.chk_download_description.TabIndex = 6;
            this.chk_download_description.Text = "Download text description && Url";
            this.chk_download_description.UseVisualStyleBackColor = true;
            // 
            // btn_browse
            // 
            this.btn_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browse.Location = new System.Drawing.Point(364, 113);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(32, 23);
            this.btn_browse.TabIndex = 4;
            this.btn_browse.Text = "...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // txt_savepath
            // 
            this.txt_savepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_savepath.Location = new System.Drawing.Point(9, 116);
            this.txt_savepath.Name = "txt_savepath";
            this.txt_savepath.Size = new System.Drawing.Size(349, 20);
            this.txt_savepath.TabIndex = 3;
            // 
            // chk_separate_folders
            // 
            this.chk_separate_folders.AutoSize = true;
            this.chk_separate_folders.Location = new System.Drawing.Point(6, 62);
            this.chk_separate_folders.Name = "chk_separate_folders";
            this.chk_separate_folders.Size = new System.Drawing.Size(146, 17);
            this.chk_separate_folders.TabIndex = 2;
            this.chk_separate_folders.Text = "Separate folders for mods";
            this.chk_separate_folders.UseVisualStyleBackColor = true;
            this.chk_separate_folders.CheckedChanged += new System.EventHandler(this.chk_separate_folders_CheckedChanged);
            // 
            // txt_link
            // 
            this.txt_link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_link.Location = new System.Drawing.Point(6, 36);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(388, 20);
            this.txt_link.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Save to:";
            // 
            // label_link
            // 
            this.label_link.AutoSize = true;
            this.label_link.Location = new System.Drawing.Point(3, 20);
            this.label_link.Name = "label_link";
            this.label_link.Size = new System.Drawing.Size(30, 13);
            this.label_link.TabIndex = 0;
            this.label_link.Text = "Link:";
            // 
            // grp_progress
            // 
            this.grp_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_progress.Controls.Add(this.progressbar);
            this.grp_progress.Controls.Add(this.btn_about);
            this.grp_progress.Controls.Add(this.lbl_standby);
            this.grp_progress.Controls.Add(this.btn_download);
            this.grp_progress.Location = new System.Drawing.Point(12, 232);
            this.grp_progress.Name = "grp_progress";
            this.grp_progress.Size = new System.Drawing.Size(400, 88);
            this.grp_progress.TabIndex = 3;
            this.grp_progress.TabStop = false;
            this.grp_progress.Text = "Progress:";
            // 
            // progressbar
            // 
            this.progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressbar.BarColor = System.Drawing.Color.White;
            this.progressbar.BorderColor = System.Drawing.Color.Black;
            this.progressbar.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressbar.Location = new System.Drawing.Point(9, 18);
            this.progressbar.Maximum = 100;
            this.progressbar.Minimum = 0;
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(385, 24);
            this.progressbar.Step = 10;
            this.progressbar.TabIndex = 5;
            this.progressbar.Value = 100;
            // 
            // btn_about
            // 
            this.btn_about.AutoSize = true;
            this.btn_about.Location = new System.Drawing.Point(6, 69);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(35, 13);
            this.btn_about.TabIndex = 4;
            this.btn_about.TabStop = true;
            this.btn_about.Text = "About";
            this.btn_about.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_about_LinkClicked);
            // 
            // lbl_standby
            // 
            this.lbl_standby.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_standby.Location = new System.Drawing.Point(6, 48);
            this.lbl_standby.Name = "lbl_standby";
            this.lbl_standby.Size = new System.Drawing.Size(281, 21);
            this.lbl_standby.TabIndex = 3;
            this.lbl_standby.Text = "Standby...";
            this.lbl_standby.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(424, 332);
            this.Controls.Add(this.grp_progress);
            this.Controls.Add(this.grp_main);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(440, 370);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModDB Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grp_main.ResumeLayout(false);
            this.grp_main.PerformLayout();
            this.grp_progress.ResumeLayout(false);
            this.grp_progress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.GroupBox grp_main;
        private System.Windows.Forms.GroupBox grp_progress;
        private System.Windows.Forms.CheckBox chk_separate_folders;
        private System.Windows.Forms.TextBox txt_link;
        private System.Windows.Forms.Label label_link;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txt_savepath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_download_screenshots;
        private System.Windows.Forms.CheckBox chk_download_description;
        private System.Windows.Forms.FolderBrowserDialog ofd;
        private System.Windows.Forms.Label lbl_standby;
        private System.Windows.Forms.LinkLabel btn_about;
        private ColorProgressBar.ColorProgressBar progressbar;
    }
}

