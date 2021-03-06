/// <summary>
/// 
/// </summary>
namespace com.danw.MarkdownWebPlusPlus.Forms
{
    /// <summary>
    /// 
    /// </summary>
    partial class AbstractRenderer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {            
            this.markdownViewerMenuStrip = new System.Windows.Forms.MenuStrip();
            this.exportAsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsHTMLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsPDFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAsHTMLMail = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAsTextMail = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToPrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.markdownViewerMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // markdownViewerMenuStrip
            // 
            this.markdownViewerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsToolStrip,
            this.sendToolStrip,
            this.refreshToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.markdownViewerMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.markdownViewerMenuStrip.Name = "markdownViewerMenuStrip";
            this.markdownViewerMenuStrip.Size = new System.Drawing.Size(284, 25);
            this.markdownViewerMenuStrip.TabIndex = 1;
            this.markdownViewerMenuStrip.Text = "markdownViewerMenuStrip";
            // 
            // exportAsToolStrip
            // 
            this.exportAsToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsHTMLMenuItem,
            this.exportAsPDFMenuItem});
            this.exportAsToolStrip.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_download_16x16;
            this.exportAsToolStrip.Name = "exportAsToolStrip";
            this.exportAsToolStrip.Size = new System.Drawing.Size(91, 21);
            this.exportAsToolStrip.Text = "Export as";
            // 
            // exportAsHTMLMenuItem
            // 
            this.exportAsHTMLMenuItem.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_html5_16x16;
            this.exportAsHTMLMenuItem.Name = "exportAsHTMLMenuItem";
            this.exportAsHTMLMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportAsHTMLMenuItem.Text = "HTML";
            this.exportAsHTMLMenuItem.Click += new System.EventHandler(this.exportAsHTMLMenuItem_Click);
            // 
            // exportAsPDFMenuItem
            // 
            this.exportAsPDFMenuItem.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_file_pdf_o_16x16;
            this.exportAsPDFMenuItem.Name = "exportAsPDFMenuItem";
            this.exportAsPDFMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportAsPDFMenuItem.Text = "PDF";
            this.exportAsPDFMenuItem.Click += new System.EventHandler(this.exportAsPDFMenuItem_Click);
            // 
            // sendToolStrip
            // 
            this.sendToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendAsHTMLMail,
            this.sendAsTextMail,
            this.sendToPrinter,
            this.sendToClipboard});
            this.sendToolStrip.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_upload_16x16;
            this.sendToolStrip.Name = "sendToolStrip";
            this.sendToolStrip.Size = new System.Drawing.Size(65, 21);
            this.sendToolStrip.Text = "Send";
            // 
            // sendAsHTMLMail
            // 
            this.sendAsHTMLMail.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_html5_16x16;
            this.sendAsHTMLMail.Name = "sendAsHTMLMail";
            this.sendAsHTMLMail.Size = new System.Drawing.Size(188, 22);
            this.sendAsHTMLMail.Text = "as HTML E-mail";
            this.sendAsHTMLMail.Click += new System.EventHandler(this.sendAsHTMLMail_Click);
            // 
            // sendAsTextMail
            // 
            this.sendAsTextMail.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_envelope_16x16;
            this.sendAsTextMail.Name = "sendAsTextMail";
            this.sendAsTextMail.Size = new System.Drawing.Size(188, 22);
            this.sendAsTextMail.Text = "as Text E-mail";
            this.sendAsTextMail.Click += new System.EventHandler(this.sendAsTextMail_Click);
            // 
            // sendToPrinter
            // 
            this.sendToPrinter.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_print_16x16;
            this.sendToPrinter.Name = "sendToPrinter";
            this.sendToPrinter.Size = new System.Drawing.Size(188, 22);
            this.sendToPrinter.Text = "to Printer";
            this.sendToPrinter.Click += new System.EventHandler(this.sendToPrinter_Click);
            // 
            // sendToClipboard
            // 
            this.sendToClipboard.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_clipboard_16x16;
            this.sendToClipboard.Name = "sendToClipboard";
            this.sendToClipboard.Size = new System.Drawing.Size(188, 22);
            this.sendToClipboard.Text = "HTML to Clipboard";
            this.sendToClipboard.Click += new System.EventHandler(this.sendToClipboard_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_refresh_16x16;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(26, 21);
            this.aboutToolStripMenuItem.Text = "?";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_cog_16x16;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = global::com.danw.MarkdownWebPlusPlus.Properties.Resources.fa_info_16x16;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // AbstractRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 241);
            this.Controls.Add(this.markdownViewerMenuStrip);
            this.MainMenuStrip = this.markdownViewerMenuStrip;
            this.Name = "AbstractRenderer";
            this.Text = "MarkdownWebViewer++";
            this.markdownViewerMenuStrip.ResumeLayout(false);
            this.markdownViewerMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        protected System.Windows.Forms.MenuStrip markdownViewerMenuStrip;
        protected System.Windows.Forms.ToolStripMenuItem exportAsToolStrip;
        protected System.Windows.Forms.ToolStripMenuItem exportAsHTMLMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem exportAsPDFMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToolStrip;
        private System.Windows.Forms.ToolStripMenuItem sendAsHTMLMail;
        private System.Windows.Forms.ToolStripMenuItem sendAsTextMail;
        private System.Windows.Forms.ToolStripMenuItem sendToPrinter;
        private System.Windows.Forms.ToolStripMenuItem sendToClipboard;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
    }
}
