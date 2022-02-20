using Svg;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
//using TheArtOfDev.HtmlRenderer.Core.Entities;
using static com.danw.MarkdownWebPlusPlus.MarkdownWeb;

namespace com.danw.MarkdownWebPlusPlus.Forms
{


    public class MarkdownWebRenderer : AbstractRenderer
    {
        //public MarkdownViewerHtmlPanel markdownWebHtmlPanel;
        public System.Windows.Forms.WebBrowser markdownWebHtmlPanel;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="markdownViewerNew"></param>
        private int WebBrowserHeight = 0;

        public MarkdownWebRenderer(MarkdownWeb markdownViewer) : base(markdownViewer)
        {
            //InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Init()
        {
            base.Init();
            this.markdownWebHtmlPanel = new System.Windows.Forms.WebBrowser();
            //this.markdownWebHtmlPanel.AllowDrop = false;
            this.markdownWebHtmlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.markdownWebHtmlPanel.IsContextMenuEnabled = true;
            this.markdownWebHtmlPanel.Location = new System.Drawing.Point(0, 24);
            this.markdownWebHtmlPanel.MinimumSize = new System.Drawing.Size(20, 20);
            this.markdownWebHtmlPanel.Name = "markdownWebHtmlPanel";
            this.markdownWebHtmlPanel.Size = new System.Drawing.Size(284, 237);
            this.markdownWebHtmlPanel.TabIndex = 0;
            //this.markdownWebHtmlPanel.AvoidImagesLateLoading = false;
            //Add a custom image loader
            //this.markdownWebHtmlPanel.ImageLoad += OnImageLoad;
            //Add to view
            this.Controls.Add(this.markdownWebHtmlPanel);
            this.Controls.SetChildIndex(this.markdownWebHtmlPanel, 0);
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileInfo"></param>
        public override void Render(string text, FileInformation fileInfo)
        {
            //Uri uri1 = new Uri(this.markdownWebHtmlPanel.Address);
            //this.markdownWebHtmlPanel.Navigate(fileInfo.FileDirectory+"\\" + fileInfo.FileName);
            base.Render( text, fileInfo);
            this.markdownWebHtmlPanel.DocumentText = BuildHtml(ConvertedText, fileInfo.FileName);
            //this.markdownWebHtmlPanel.Url.AbsolutePath = fileInfo.FileDirectory;
            // Console.WriteLine(this.markdownWebHtmlPanel.Url.AbsolutePath);
 
            while (this.markdownWebHtmlPanel.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            var height = this.markdownWebHtmlPanel.Document.InvokeScript("eval", new object[] { @"
            function documentHeight(){
            return Math.max(
            document.documentElement['clientHeight'],
            document.body['scrollHeight'], document.documentElement['scrollHeight'],
            document.body['offsetHeight'], document.documentElement['offsetHeight']
            );
            }
            documentHeight();
            " });
            if (height != null)
            {
                this.WebBrowserHeight = int.Parse(height.ToString());
            }
            else
                this.WebBrowserHeight = this.markdownWebHtmlPanel.Document.Body.ClientRectangle.Height;
            /*
            this.WebBrowserHeight = int.Parse(this.markdownWebHtmlPanel.Document.InvokeScript ("eval", new object[] { @"
            function documentHeight(){
            return Math.max(
            document.documentElement['clientHeight'],
            document.body['scrollHeight'], document.documentElement['scrollHeight'],
            document.body['offsetHeight'], document.documentElement['offsetHeight']
            );
            }
            documentHeight();
            " }).ToString());
            */
            //this.WebBrowserHeight = this.markdownWebHtmlPanel.Document.Body.ScrollRectangle.Height;
            if (this.WebBrowserHeight == 0) this.WebBrowserHeight = this.markdownWebHtmlPanel.Document.Body.ScrollRectangle.Height;
        }
 

        /// <summary>
        /// Scroll the rendered panel vertically based on the given ration
        /// taken from Notepad++
        /// </summary>
        /// <param name="scrollRatio"></param>
        public override void ScrollByRatioVertically(double scrollRatio)
        {
            //this.markdownWebHtmlPanel.ScrollByRatioVertically(scrollRatio);
            //scrollRatio = 2;
            if (this.markdownWebHtmlPanel.Document.Body != null)
            {
                this.markdownWebHtmlPanel.Document.Window.ScrollTo (0,(int)(scrollRatio * this.WebBrowserHeight ));
                //this.markdownWebHtmlPanel.Document.Body.S
            }
        }

        /// <summary>
        /// Custom renderer for SVG images in the markdown as not supported natively.
        /// @see https://htmlrenderer.codeplex.com/wikipage?title=Rendering%20SVG%20images
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="imageLoadEvent"></param>
 
        /// <summary>
        /// Release the custom loader
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (this.markdownWebHtmlPanel != null)
            {
                //this.markdownWebHtmlPanel.ImageLoad -= OnImageLoad;
            }
            base.Dispose(disposing);
        }
    }
}

