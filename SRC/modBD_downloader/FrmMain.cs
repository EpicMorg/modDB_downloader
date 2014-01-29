using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpicMorg.Net;
using Fizzler.Systems.HtmlAgilityPack;

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

        private void chk_separate_folders_CheckedChanged(object sender, EventArgs e) {
            chk_download_screenshots.Enabled = chk_download_description.Enabled = chk_separate_folders.Checked;
        }

        private void btn_browse_Click(object sender, EventArgs e) {
            if(ofd.ShowDialog() == DialogResult.OK)
                txt_savepath.Text =  ofd.SelectedPath;
        }

        private async void btn_download_Click( object sender, EventArgs e ) {
            string link = txt_link.Text,
                outpath = txt_savepath.Text;
            bool crtFld = chk_separate_folders.Checked,
                 dwnScr = chk_download_description.Checked,
                 dwnDsc = chk_download_description.Checked;
            this.Enabled = false;
            if ( !checkLink( link ) )
                this.ErrorBox( "Bad link" );
            try {
                bool next;
                var curpage = 1;
                do {
                    try {
// ReSharper disable once SpecifyACultureInStringConversionExplicitly
                        var page = (await this.GetDocument( Path.Combine( link, "page", curpage.ToString() ) )).DocumentNode;
                        var links = page
                            .QuerySelectorAll(ModLinkSelector)
                            .Select( c => c.Attributes[ "href" ].Value )
                            .ToArray();
                        foreach (var modlink in links)
                            await DownloadMod( new Uri(new Uri( ModDBRoot ), modlink).ToString(), outpath, crtFld, dwnScr, dwnDsc );
                        next = page.QuerySelectorAll( "a.next" ).Any();
                        curpage++;
                    }
                    catch (WebException) {
                        next = false;
                    }
                } while ( next ); 
            }
            catch (WebException ex) {
                this.ShowError( ex );
            }
            this.Enabled = true;
        }

        private async Task<bool> DownloadMod( string modlink, string outpath, bool crtFld, bool dwnScr, bool dwnDsc ) {
            try {
                //paths
                var dwnpath = Path.Combine( outpath, crtFld? Path.GetFileName( modlink ):"" );
                var dscPath = Path.Combine( dwnpath, "description.txt" );
                if ( !Directory.Exists( dwnpath ) ) Directory.CreateDirectory( dwnpath );
                //fetch doc
                var modpage = await this.GetDocument( modlink );
                //description
                if ( dwnDsc && !File.Exists( dscPath ) ) {
                    var dsc = modpage.DocumentNode.QuerySelectorAll( "#downloadsummary" ).Take( 1 ).ToArray();
                    if (dsc.Length>0) File.WriteAllText( dscPath, dsc[0].InnerText );
                }
                //preview
                if ( dwnScr ) {
                    var scr = modpage.DocumentNode.QuerySelectorAll( ScreenshotLinkSelector ).Take( 1 ).ToArray();
                    if ( scr.Length > 0 ) {
                        var srcLink = scr[ 0 ].Attributes[ "href" ].Value;
                        var scrPath = Path.Combine( dwnpath, Path.GetFileName( srcLink ) );
                        if ( !File.Exists( scrPath ) )
                            await AWC.DownloadFileAsync( srcLink, scrPath );
                    }
                }
                //mod 
                var linke = modpage.DocumentNode.QuerySelectorAll( "#downloadmirrorstoggle" ).Take( 1 ).ToArray();
                if ( linke.Length == 0 ) return true;
                var modDownloadLink =new Uri(
                    new Uri( ModDBRoot ),
                    this._modDownloadLinkRegex.Match( linke[ 0 ].Attributes[ "href" ].Value ).Value
                )
                .ToString();
                var custormersMomIsACheapWhore = await this.GetDocument( modDownloadLink );
                linke = custormersMomIsACheapWhore
                    .DocumentNode.QuerySelectorAll( "body>p:first-child>a:first-child" )
                    .Take( 1 )
                    .ToArray();
                if ( linke.Length == 0 ) return true;
                var modFileLink = new Uri(new Uri( ModDBRoot ),Path.Combine( ModDBRoot, linke[ 0 ].Attributes[ "href" ].Value )).ToString();
                var req = WebRequest.CreateHttp( modFileLink );
                    req.AllowAutoRedirect = false;
                var resp = await req.GetResponseAsync();
                var fileLink = resp.Headers["Location"]??modFileLink;
                var modFilePath = Path.Combine( dwnpath, Path.GetFileName( fileLink ) );
                if ( !File.Exists( modFilePath ) )
                    await AWC.DownloadFileAsync( fileLink, modFilePath );
                return true;
            }
            catch (WebException) {
                return false;
            }

        }

        private async Task<HtmlAgilityPack.HtmlDocument> GetDocument( string url ) {
            var page = await AWC.DownloadStringAsync( url );
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml( page );
            return doc;
        }

        private void ShowError(Exception ex) {
            this.ErrorBox( "Error occured:\r\n"+ex.Message );
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
            catch (Exception) {
                return false;
            }
        }
    }
}
