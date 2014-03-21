using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace modDB_downloader {
    public partial class FrmMain : Form {
        private const string ModLinkSelector =
            "#body>div.container:first-child>div.column.span-300-alt.first>div:first-child>div.inner>div:first-child>div.table.tablesummarysupport>div.clear>a:first-child";
        private const string ScreenshotLinkSelector =
            "#body>div.container:first-child>div.first>div.normalbox>div.inner>div.mediaviewer.clear>div.media>a";
        private const string ModDBRoot = "http://www.moddb.com/";
        private Regex _modDownloadLinkRegex = new Regex( @"\/[a-z]+\/start\/[0-9]+" );
        private bool _running = false;
        
        public FrmMain() {
            InitializeComponent();

        }
        private void chk_separate_folders_CheckedChanged( object sender, EventArgs e ) {
            chk_download_screenshots.Enabled = chk_download_screenshots.Checked = chk_download_description.Enabled = chk_download_description.Checked = chk_separate_folders.Checked;
        }

        private void btn_browse_Click( object sender, EventArgs e ) {
            if ( ofd.ShowDialog() == DialogResult.OK )
                txt_savepath.Text = ofd.SelectedPath;
        }

        private async void btn_download_Click( object sender, EventArgs e ) {
            _running ^= true;
            if ( _running && !bw.IsBusy )
                bw.RunWorkerAsync();
            else {
                btn_download.Enabled = false;
            }
        }

        private void Download() {
            string link = txt_link.Text,
                outpath = txt_savepath.Text;
            bool crtFld = chk_separate_folders.Checked,
                 dwnScr = chk_download_description.Checked,
                 dwnDsc = chk_download_description.Checked;
            this.Invoke( ( (Action) ( this.OnDownloadStart ) ) );
            if ( !checkLink( link ) ) {
                this.Invoke( ( (Action) ( this.OnBadLink ) ) );
                this.ErrorBox( "Bad link" );
            }
            else {
                try {
                    bool next;
                    var curpage = 1;
                    var links = new List<string>();
                    do {
                        try {
                            if ( !this._running ) { this.Invoke( ( (Action) this.OnDownloadComplete ) ); return; }
                            var page = ( this.GetDocument( new Uri( link ) + "/page/" + curpage ) ).DocumentNode;
                            links.AddRange(
                                page.QuerySelectorAll( ModLinkSelector )
                                    .Select( c => c.Attributes[ "href" ].Value )
                                    
                                    .ToArray() );
                            next = page.QuerySelectorAll( "a.next" ).Any();
                            curpage++;
                            this.Invoke( ( (Action) ( () => OnCatalogProgress( curpage ) ) ) );
                        }
                        catch ( WebException ) {
                            next = false;
                        }
                    } while ( next );
                    this.Invoke( ( (Action) ( () => {
                        lbl_standby.Text = @"Preparing...";
                        progressbar.BarColor = Color.FromArgb( 192, 255, 192 );
                        progressbar.Value = 0;
                        Application.DoEvents();
                    } ) ) );
                    var total = links.Count;
                    for ( var index = 0; index < total; index++ ) {
                        var modlink = links[ index ];
                        if ( !this._running ) { this.Invoke( ( (Action) this.OnDownloadComplete ) );  return; }
                        this.Invoke( ( (Action) ( () => OnDownloadProgress( total, index, modlink ) ) ) );
                        this.DownloadMod( this.GetFullLink( modlink ), outpath, crtFld, dwnScr, dwnDsc );
                    }
                }
                catch ( Exception ex ) {
                    this.ShowError( ex );
                }
                this.Invoke( (Action) ( () => MessageBox.Show( @"Download complete", @"Winrar", MessageBoxButtons.OK, MessageBoxIcon.Information ) ) );
            }

            this.Invoke( ( (Action) this.OnDownloadComplete ) );
        }

        private void OnBadLink() {
            lbl_standby.Text = string.Format( "Error!" );
            progressbar.BarColor = Color.FromArgb( 255, 128, 128 );
            progressbar.Value = 100;
            Application.DoEvents();
        }

        private void OnDownloadStart() {
            lbl_standby.Text = @"Scanning for Mods & Links";
            btn_download.Text = "Cancel";
            progressbar.BarColor = Color.FromArgb( 255, 255, 128 );
            progressbar.Value = 100;
            Application.DoEvents();
        }

        private void OnCatalogProgress( int curpage ) {
            lbl_standby.Text = string.Format( "Scanning for Mods && Links. Found {0} pages...", curpage );
            progressbar.BarColor = Color.FromArgb( 128, 255, 154 );
            progressbar.Value = 100;
            Application.DoEvents();
        }

        private void OnDownloadProgress( int total, int index, string modlink ) {
            lbl_standby.Text = string.Format( "Downloading {0}, {1} of {2}", Path.GetFileName( modlink ), index + 1, total );
            progressbar.BarColor = Color.FromArgb( 128, 255, 255 );
            progressbar.Value = ( index * 100 ) / ( total );
            Application.DoEvents();
        }

        private void OnDownloadComplete() {
            this.btn_download.Enabled = true;
            lbl_standby.Text = @"Complete. Standby.";
            btn_download.Text = @"Download";
            progressbar.BarColor = Color.White;
            progressbar.Value = 100;
            this._running = false;
            Application.DoEvents();
        }

        private void DownloadMod( string modlink, string outpath, bool crtFld, bool dwnScr, bool dwnDsc ) {
            try {
                //paths
                var dwnpath = Path.Combine( outpath, crtFld ? Path.GetFileName( modlink ) : "" );
                var dscPath = Path.Combine( dwnpath, "description.txt" );
				var dsc2Path = Path.Combine( dwnpath, "description2.txt" );
                if ( !Directory.Exists( dwnpath ) ) Directory.CreateDirectory( dwnpath );
                //fetch doc
                File.WriteAllText( Path.Combine( dwnpath, "mod-url.txt" ), modlink );
                var modpage = this.GetDocument( modlink );
                //description
                if ( dwnDsc && !File.Exists( dscPath ) ) {
                    var dsc = modpage.DocumentNode.QuerySelectorAll( "#downloadsummary" ).Take( 1 ).ToArray();
                    if ( dsc.Length > 0 ) File.WriteAllText( dscPath, dsc[ 0 ].InnerText );
                }
				if ( dwnDsc && !File.Exists( dsc2Path ) ) {
                    var dsc2 = modpage.DocumentNode.QuerySelectorAll( "#body>.container>.column.span-all>div.normalbox>div.inner>div.body>p" ).Take( 1 ).ToArray();
                    if ( dsc2.Length > 0 ) File.WriteAllText( dsc2Path, dsc2[ 0 ].InnerText );
                }
				
                //preview
                if ( dwnScr ) {
                    var scr = modpage.DocumentNode.QuerySelectorAll( ScreenshotLinkSelector ).Take( 1 ).ToArray();
                    if ( scr.Length > 0 ) {
                        var srcLink = scr[ 0 ].Attributes[ "href" ].Value;
                        var scrPath = Path.Combine( dwnpath, Path.GetFileName( srcLink ) );
                        if ( !File.Exists( scrPath ) )
                            new WebClient().DownloadFile( srcLink, scrPath );
                    }
                }
                //mod 
                var linke = modpage.DocumentNode.QuerySelectorAll( "#downloadmirrorstoggle" ).Take( 1 ).ToArray();
                if ( linke.Length == 0 ) return;
                var fileLink = linke[ 0 ].Attributes[ "href" ].Value;
                var modDownloadLink = new Uri(
                       new Uri( ModDBRoot ),
                       this._modDownloadLinkRegex.Match( fileLink ).Value
                   )
                   .ToString();
                //parse mod dwn page
                var custormersMomIsACheapWhore = this.GetDocument( modDownloadLink );
                var lnk = custormersMomIsACheapWhore
                    .DocumentNode.QuerySelectorAll( "body>p:first-child>a:first-child" )
                    .Take( 1 )
                    .Select( a => a.Attributes[ "href" ].Value )
                    .ToArray();
                if ( lnk.Length == 0 ) return;
                var modDwn = this.GetFullLink( Path.Combine( ModDBRoot, lnk[ 0 ] ) );
                //get real file name
                var req = WebRequest.CreateHttp( modDwn );
                req.AllowAutoRedirect = false;
                using ( var resp = req.GetResponse() ) {
                    var fname = resp.Headers[ "Location" ] ?? modDwn;
                    var f = Path.GetFileName( fname );
                    var outfile = Path.Combine( dwnpath, f );
                    new WebClient().DownloadFile( modDwn, outfile );
                }
            }
            catch ( WebException ) { }
        }

        private string GetFullLink( string s ) {
            return new Uri( new Uri( ModDBRoot ), s ).ToString();
        }

        private HtmlDocument GetDocument( string url ) {
            try {
                return new HtmlAgilityPack.HtmlWeb().Load( url );
            }
            catch ( Exception ex ) {
                throw;
            }
        }

        private void ShowError( Exception ex ) {
            this.Invoke( (Action) ( () => this.ErrorBox( "Error occured:\r\n" + ex.Message )));
        }

        private void ErrorBox( string str ) {
            MessageBox.Show( str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        private bool checkLink( string link ) {
            try {
                var url = new Uri( link );
                return url.Host.Contains( "moddb.com" );
                //  &&
                //    url.AbsolutePath.TrimEnd( '/' ).EndsWith( "downloads" );
            }
            catch ( Exception ) {
                return false;
            }
        }

        private void FrmMain_Load( object sender, EventArgs e ) {
            // white -  цвет при простое. value = 100 выставлять
            // 255; 255; 128 - цвет при ожидании перед скачиванием файлов. value = 100 выставлять
            // 128; 255; 255 - цвет стандартного выполнения индикатора
        }

        private void btn_about_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            var frmAbout = new frm_about();
            frmAbout.ShowDialog();
        }

        private void FrmMain_FormClosing( object sender, FormClosingEventArgs e ) {
            base.OnClosing( e );
            if ( !this._running ) return;
            e.Cancel = true;
            MessageBox.Show( @"Please wait!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }

        private void bw_DoWork( object sender, System.ComponentModel.DoWorkEventArgs e ) {
            Download();
        }
    }
}
