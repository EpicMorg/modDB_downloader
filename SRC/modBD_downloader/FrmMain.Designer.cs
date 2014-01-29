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
            this.progressbar_download = new System.Windows.Forms.ProgressBar();
            this.gbx_null1 = new System.Windows.Forms.GroupBox();
            this.chk_download_screenshots = new System.Windows.Forms.CheckBox();
            this.chk_download_description = new System.Windows.Forms.CheckBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.txt_savepath = new System.Windows.Forms.TextBox();
            this.chk_separate_folders = new System.Windows.Forms.CheckBox();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_link = new System.Windows.Forms.Label();
            this.label_progress = new System.Windows.Forms.GroupBox();
            this.ofd = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbx_null1.SuspendLayout();
            this.label_progress.SuspendLayout();
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
            this.btn_download.Location = new System.Drawing.Point(293, 18);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(101, 34);
            this.btn_download.TabIndex = 1;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // progressbar_download
            // 
            this.progressbar_download.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressbar_download.Location = new System.Drawing.Point(6, 18);
            this.progressbar_download.Name = "progressbar_download";
            this.progressbar_download.Size = new System.Drawing.Size(281, 34);
            this.progressbar_download.TabIndex = 2;
            // 
            // gbx_null1
            // 
            this.gbx_null1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_null1.Controls.Add(this.chk_download_screenshots);
            this.gbx_null1.Controls.Add(this.chk_download_description);
            this.gbx_null1.Controls.Add(this.btn_browse);
            this.gbx_null1.Controls.Add(this.txt_savepath);
            this.gbx_null1.Controls.Add(this.chk_separate_folders);
            this.gbx_null1.Controls.Add(this.txt_link);
            this.gbx_null1.Controls.Add(this.label2);
            this.gbx_null1.Controls.Add(this.label_link);
            this.gbx_null1.Location = new System.Drawing.Point(12, 85);
            this.gbx_null1.Name = "gbx_null1";
            this.gbx_null1.Size = new System.Drawing.Size(400, 146);
            this.gbx_null1.TabIndex = 3;
            this.gbx_null1.TabStop = false;
            this.gbx_null1.Text = "Downloading:";
            // 
            // chk_download_screenshots
            // 
            this.chk_download_screenshots.AutoSize = true;
            this.chk_download_screenshots.Enabled = false;
            this.chk_download_screenshots.Location = new System.Drawing.Point(169, 62);
            this.chk_download_screenshots.Name = "chk_download_screenshots";
            this.chk_download_screenshots.Size = new System.Drawing.Size(203, 17);
            this.chk_download_screenshots.TabIndex = 5;
            this.chk_download_screenshots.Text = "Download screenshots && Previews";
            this.chk_download_screenshots.UseVisualStyleBackColor = true;
            // 
            // chk_download_description
            // 
            this.chk_download_description.AutoSize = true;
            this.chk_download_description.Enabled = false;
            this.chk_download_description.Location = new System.Drawing.Point(169, 85);
            this.chk_download_description.Name = "chk_download_description";
            this.chk_download_description.Size = new System.Drawing.Size(163, 17);
            this.chk_download_description.TabIndex = 6;
            this.chk_download_description.Text = "Download text description";
            this.chk_download_description.UseVisualStyleBackColor = true;
            // 
            // btn_browse
            // 
            this.btn_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browse.Location = new System.Drawing.Point(364, 117);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(32, 23);
            this.btn_browse.TabIndex = 4;
            this.btn_browse.Text = "...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // txt_savepath
            // 
            this.txt_savepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_savepath.Location = new System.Drawing.Point(9, 120);
            this.txt_savepath.Name = "txt_savepath";
            this.txt_savepath.Size = new System.Drawing.Size(349, 22);
            this.txt_savepath.TabIndex = 3;
            // 
            // chk_separate_folders
            // 
            this.chk_separate_folders.AutoSize = true;
            this.chk_separate_folders.Location = new System.Drawing.Point(6, 62);
            this.chk_separate_folders.Name = "chk_separate_folders";
            this.chk_separate_folders.Size = new System.Drawing.Size(159, 17);
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
            this.txt_link.Size = new System.Drawing.Size(390, 22);
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
            this.label_link.Size = new System.Drawing.Size(31, 13);
            this.label_link.TabIndex = 0;
            this.label_link.Text = "Link:";
            // 
            // label_progress
            // 
            this.label_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_progress.Controls.Add(this.progressbar_download);
            this.label_progress.Controls.Add(this.btn_download);
            this.label_progress.Location = new System.Drawing.Point(12, 237);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(400, 58);
            this.label_progress.TabIndex = 3;
            this.label_progress.TabStop = false;
            this.label_progress.Text = "Progress: 0/0";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(424, 307);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.gbx_null1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(440, 345);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModDB Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbx_null1.ResumeLayout(false);
            this.gbx_null1.PerformLayout();
            this.label_progress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.ProgressBar progressbar_download;
        private System.Windows.Forms.GroupBox gbx_null1;
        private System.Windows.Forms.GroupBox label_progress;
        private System.Windows.Forms.CheckBox chk_separate_folders;
        private System.Windows.Forms.TextBox txt_link;
        private System.Windows.Forms.Label label_link;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txt_savepath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_download_screenshots;
        private System.Windows.Forms.CheckBox chk_download_description;
        private System.Windows.Forms.FolderBrowserDialog ofd;
    }
}

