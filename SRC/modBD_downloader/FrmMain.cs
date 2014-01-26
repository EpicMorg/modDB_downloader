using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace modBD_downloader {
    public partial class FrmMain : Form {
        public FrmMain() {
            InitializeComponent();
        }

        private void chk_separate_folders_CheckedChanged(object sender, EventArgs e) {
            chk_download_description.Enabled = chk_separate_folders.Checked;
            chk_download_screenshots.Enabled = chk_separate_folders.Checked;
        }

        private void btn_browse_Click(object sender, EventArgs e) {
            var ofd = new FolderBrowserDialog();
            txt_savepath.Text = ofd.ShowDialog() == DialogResult.OK ? ofd.SelectedPath : "";
        }
    }
}
