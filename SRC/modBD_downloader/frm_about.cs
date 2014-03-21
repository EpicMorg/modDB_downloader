using System.Diagnostics;
using System.Windows.Forms;

namespace modDB_downloader {
    public partial class frm_about : Form {
        public frm_about() {
            InitializeComponent();
        }

        private void url1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(url1.Text);
        }

        private void url2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(url2.Text);
        }

        private void url3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(url3.Text);
        }

        private void url4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(url4.Text);
        }

        private void url5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://epicm.org/");
        }

        private void url6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(url6.Text);
        }
    }
}
