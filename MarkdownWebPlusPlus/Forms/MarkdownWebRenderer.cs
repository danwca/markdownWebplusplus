using Svg;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
//using TheArtOfDev.HtmlRenderer.Core.Entities;
using static com.danw.MarkdownWebPlusPlus.MarkdownWeb;

namespace com.danw.MarkdownWebPlusPlus.Forms
{


    public class MarkdownWebRenderer : AbstractRenderer
    {
        //public MarkdownViewerHtmlPanel markdownViewerHtmlPanel;
        public System.Windows.Forms.WebBrowser markdownViewerHtmlPanel;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="markdownViewerNew"></param>

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
            this.markdownViewerHtmlPanel = new System.Windows.Forms.WebBrowser();
            //this.markdownViewerHtmlPanel.AllowDrop = false;
            this.markdownViewerHtmlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.markdownViewerHtmlPanel.IsContextMenuEnabled = true;
            this.markdownViewerHtmlPanel.Location = new System.Drawing.Point(0, 24);
            this.markdownViewerHtmlPanel.MinimumSize = new System.Drawing.Size(20, 20);
            this.markdownViewerHtmlPanel.Name = "markdownViewerHtmlPanel";
            this.markdownViewerHtmlPanel.Size = new System.Drawing.Size(284, 237);
            this.markdownViewerHtmlPanel.TabIndex = 0;
            //this.markdownViewerHtmlPanel.AvoidImagesLateLoading = false;
            //Add a custom image loader
            //this.markdownViewerHtmlPanel.ImageLoad += OnImageLoad;
            //Add to view
            this.Controls.Add(this.markdownViewerHtmlPanel);
            this.Controls.SetChildIndex(this.markdownViewerHtmlPanel, 0);
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileInfo"></param>
        public override void Render(string text, FileInformation fileInfo)
        {
            //Uri uri1 = new Uri(this.markdownViewerHtmlPanel.Address);
            //this.markdownViewerHtmlPanel.Navigate(fileInfo.FileDirectory+"\\" + fileInfo.FileName);
            base.Render( text, fileInfo);
            this.markdownViewerHtmlPanel.DocumentText = BuildHtml(ConvertedText, fileInfo.FileName);
            //this.markdownViewerHtmlPanel.Url.AbsolutePath = fileInfo.FileDirectory;
           // Console.WriteLine(this.markdownViewerHtmlPanel.Url.AbsolutePath);
        }

        /// <summary>
        /// Scroll the rendered panel vertically based on the given ration
        /// taken from Notepad++
        /// </summary>
        /// <param name="scrollRatio"></param>
        public override void ScrollByRatioVertically(double scrollRatio)
        {
            //this.markdownViewerHtmlPanel.ScrollByRatioVertically(scrollRatio);
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
            if (this.markdownViewerHtmlPanel != null)
            {
                //this.markdownViewerHtmlPanel.ImageLoad -= OnImageLoad;
            }
            base.Dispose(disposing);
        }
    }
}

