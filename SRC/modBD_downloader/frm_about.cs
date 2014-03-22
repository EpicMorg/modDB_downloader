using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace modDB_downloader {
    public partial class frm_about : Form {
        public frm_about() {
            InitializeComponent();
        }

        #region Методы доступа к атрибутам сборки 
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        } 
    
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        } 
          #endregion


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

        private void frm_about_Load(object sender, System.EventArgs e)
        {
            this.lbl_name.Text = String.Format("{0} {1}", AssemblyProduct, AssemblyVersion);
        }
    }
}
