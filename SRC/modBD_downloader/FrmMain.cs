﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpicMorg.Net;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace modBD_downloader {
    public partial class FrmMain : Form {
        private const string ModLinkSelector =
            "#body>div.container:first-child>div.column.span-300-alt.first>div:first-child>div.inner>div:first-child>div.table.tablesummarysupport>div.clear>a:first-child";
        private const string ScreenshotLinkSelector =
            "#body>div.container:first-child>div.first>div.normalbox>div.inner>div.mediaviewer.clear>div.media>a";
        private const string ModDBRoot = "http://www.moddb.com/";
        private Regex _modDownloadLinkRegex = new Regex( @"\/downloads\/start\/[0-9]+" );

        public FrmMain() {
            InitializeComponent();
        }

        private void chk_separate_folders_CheckedChanged( object sender, EventArgs e ) {
            chk_download_screenshots.Enabled = chk_download_description.Enabled = chk_separate_folders.Checked;
        }

        private void btn_browse_Click( object sender, EventArgs e ) {
            if ( ofd.ShowDialog() == DialogResult.OK )
                txt_savepath.Text = ofd.SelectedPath;
        }

        private async void btn_download_Click( object sender, EventArgs e ) {
            string link = txt_link.Text,
                outpath = txt_savepath.Text;
            bool crtFld = chk_separate_folders.Checked,
                 dwnScr = chk_download_description.Checked,
                 dwnDsc = chk_download_description.Checked;
            this.grp_main.Enabled = this.grp_progress.Enabled = false;
            if ( !checkLink( link ) ) {
                this.ErrorBox( "Bad link" );
            }
            else {

                try {
                    bool next;
                    var curpage = 1;
                    var links = new List<string>();
                    do {
                        try {
                            var page = ( this.GetDocument( new Uri( link ) + "/page/" + curpage ) ).DocumentNode;
                            links.AddRange(
                                page.QuerySelectorAll( ModLinkSelector )
                                    .Select( c => c.Attributes[ "href" ].Value )
                                    .ToArray() );
                            next = page.QuerySelectorAll( "a.next" ).Any();
                            curpage++;
                        }
                        catch ( WebException ) {
                            next = false;
                        }
#if DEBUG
                        next = false;
#endif
                    } while ( next );
                    foreach ( var modlink in links )
                        this.DownloadMod( this.GetFullLink( modlink ), outpath, crtFld, dwnScr, dwnDsc );
                }
                catch ( Exception ex ) {
                    this.ShowError( ex );
                }
                MessageBox.Show( @"Download complete", @"Winrar", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            this.grp_main.Enabled = this.grp_progress.Enabled = true;
        }

        private void DownloadMod( string modlink, string outpath, bool crtFld, bool dwnScr, bool dwnDsc ) {
            try {
                //paths
                var dwnpath = Path.Combine( outpath, crtFld ? Path.GetFileName( modlink ) : "" );
                var dscPath = Path.Combine( dwnpath, "description.txt" );
                if ( !Directory.Exists( dwnpath ) ) Directory.CreateDirectory( dwnpath );
                //fetch doc
                var modpage = this.GetDocument( modlink );
                //description
                if ( dwnDsc && !File.Exists( dscPath ) ) {
                    var dsc = modpage.DocumentNode.QuerySelectorAll( "#downloadsummary" ).Take( 1 ).ToArray();
                    if ( dsc.Length > 0 ) File.WriteAllText( dscPath, dsc[ 0 ].InnerText );
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
                var fileLink = linke.Length == 0 ? null : linke[ 0 ].Attributes[ "href" ].Value;
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
            this.ErrorBox( "Error occured:\r\n" + ex.Message );
        }

        private void ErrorBox( string str ) {
            MessageBox.Show( str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        private bool checkLink( string link ) {
            try {
                var url = new Uri( link );
                return url.Host.Contains( "moddb.com" )
                    &&
                    url.AbsolutePath.TrimEnd( '/' ).EndsWith( "downloads" );
            }
            catch ( Exception ) {
                return false;
            }
        }
    }
}
