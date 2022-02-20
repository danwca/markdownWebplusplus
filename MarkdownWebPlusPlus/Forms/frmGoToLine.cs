using System;
using System.Windows.Forms;
using Kbg.NppPluginNET;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace com.danw.MarkdownWebPlusPlus.Forms
{
    public class frmGoToLine : AbstractRenderer

    {
        private readonly IScintillaGateway editor;

        public frmGoToLine(MarkdownWeb markdownViewer) : base(markdownViewer)
        {
            //InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int line;
            //if (!int.TryParse(textBox1.Text, out line))
               // return;
            //editor.EnsureVisible(line - 1);
            //editor.GotoLine(line - 1);
            //editor.GrabFocus();
        }

        public override void ScrollByRatioVertically(double scrollRatio)
        {
            throw new NotImplementedException();
        }
    }
}
