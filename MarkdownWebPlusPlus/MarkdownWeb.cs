using com.danw.MarkdownWebPlusPlus.Forms;
using com.danw.MarkdownWebPlusPlus.Properties;
using Kbg.NppPluginNET;
using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static com.danw.MarkdownWebPlusPlus.MarkdownViewerConfiguration;
using static Kbg.NppPluginNET.PluginInfrastructure.Win32;

/// <summary>
/// 
/// </summary>
namespace com.danw.MarkdownWebPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class MarkdownWeb 
    {
        /// <summary>
        /// 
        /// </summary>
        public struct FileInformation
        {
            /// <summary>
            /// 
            /// </summary>
            public string FileDirectory { get; set; }
            /// <summary>
            /// 
            /// </summary>
            private string fileName;
            /// <summary>
            /// 
            /// </summary>
            public string FileName {
                get {
                    return this.fileName;
                }
                set {
                    this.fileName = value;
                    this.FileExtension = Path.GetExtension(this.fileName);
                    this.FileExtension = this.FileExtension.StartsWith(".") ? this.FileExtension.Substring(1, this.FileExtension.Length - 1) : this.FileExtension;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string FileExtension { get; private set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public IScintillaGateway Editor { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public INotepadPPGateway Notepad { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public FileInformation FileInfo { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        protected AbstractRenderer renderer;

        /// <summary>
        /// 
        /// </summary>
        protected bool rendererVisible = false;

        /// <summary>
        /// 
        /// </summary>
        protected bool updateRenderer = true;

        /// <summary>
        /// 
        /// </summary>
        public int commandId = 0;
        public int controlId = 1;

        /// <summary>
        /// 
        /// </summary>
        public int commandIdSynchronize = 2;

        /// <summary>
        /// 
        /// </summary>
        public int commandIdOptions = 4;

        /// <summary>
        /// 
        /// </summary>
        public int commandIdAbout = 5;

        /// <summary>
        /// 
        /// </summary>
        protected MarkdownViewerConfiguration configuration;
        
        /// <summary>
        /// 
        /// </summary>
        public Options Options {
            get {
                return this.configuration.options;
            }
        }

 
        /// <summary>
        /// 
        /// </summary>
        public MarkdownWeb()
        {
            //Get some global references to the editor and Notepad++ engines
            this.Editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            this.Notepad = new NotepadPPGateway();
            //Init the actual renderer
            this.renderer = new MarkdownWebRenderer(this);
            /*
            frmGoToLine controlPanel;
            controlPanel = new frmGoToLine(this.Editor);
            Bitmap tbBmp_tbTab = Properties.Resources.star_bmp;
            Icon tbIcon = null;

            using (Bitmap newBmp = new Bitmap(16, 16))
            {
                Graphics g = Graphics.FromImage(newBmp);
                ColorMap[] colorMap = new ColorMap[1];
                colorMap[0] = new ColorMap();
                colorMap[0].OldColor = Color.Fuchsia;
                colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                ImageAttributes attr = new ImageAttributes();
                attr.SetRemapTable(colorMap);
                //g.DrawImage(tbBmp_tbTab, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                g.DrawImage(Resources.markdown_16x16_solid_bmp, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                tbIcon = Icon.FromHandle(newBmp.GetHicon());
            }

            NppTbData _nppTbData = new NppTbData();
            _nppTbData.hClient = controlPanel.Handle;
            _nppTbData.pszName = "Go To Line #";
            // the dlgDlg should be the index of funcItem where the current function pointer is in
            // this case is 15.. so the initial value of funcItem[15]._cmdID - not the updated internal one !
            _nppTbData.dlgID = controlId;
            // define the default docking behaviour
            _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
            _nppTbData.hIconTab = (uint)tbIcon.Handle;
            _nppTbData.pszModuleName = Main.PluginName;
            IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
            Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            // Following message will toogle both menu item state and toolbar button
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMHIDE, 0, controlPanel.Handle);
            */

 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public void OnNotification(ScNotification notification)
        {
            //Listen to any UI update to get informed about all file changes, chars added/removed etc.
            if (this.renderer.Visible)
            {
                //Check for updates
                if (notification.Header.Code == (uint)SciMsg.SCN_UPDATEUI)
                {
                    //Update the view
                    Update((notification.Updated & (uint)SciMsg.SC_UPDATE_V_SCROLL) != 0);
                }
                else if (notification.Header.Code == (uint)NppMsg.NPPN_BUFFERACTIVATED)
                {
                    //Update the scintilla handle in all cases to keep track of which instance is active
                    UpdateEditorInformation();
                    this.Editor.CurrentBufferID = notification.Header.IdFrom;
                    Update(true, true);
                }
                else if (notification.Header.Code == (uint)SciMsg.SCN_MODIFIED && !this.updateRenderer)
                {
                    bool isInsert = (notification.ModificationType & (uint)SciMsg.SC_MOD_INSERTTEXT) != 0;
                    bool isDelete = (notification.ModificationType & (uint)SciMsg.SC_MOD_DELETETEXT) != 0;

                    //Track if any text modifications have been made
                    this.updateRenderer = isInsert || isDelete;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateScrollBar"></param>
        /// <param name="updateRenderer"></param>
        public void Update(bool updateScrollBar = false, bool updateRenderer = false)
        {
            //Validate that the current file may be rendered
            if (this.configuration.ValidateFileExtension(this.FileInfo.FileExtension, this.FileInfo.FileName))
            {
                //Update the view
                this.updateRenderer = updateRenderer ? updateRenderer : this.updateRenderer;
                UpdateMarkdownViewer();
                //Update the scroll bar of the Viewer Panel only in case of vertical scrolls
                if (true || this.configuration.options.synchronizeScrolling && updateScrollBar)
                {
                    UpdateScrollBar();
                }
            }
            else
            {
                this.renderer.Render($@"<p>
Your configuration settings do not include the currently selected file extension.<br />
The rendered file extensions are <b>'{this.configuration.options.fileExtensions}'</b>.<br />
The current file is <i>'{this.FileInfo.FileName}'</i>.
                </p>", this.FileInfo);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void UpdateScrollBar()
        {
            try
            {
                ScrollInfo scrollInfo = this.Editor.GetScrollInfo(ScrollInfoMask.SIF_RANGE | ScrollInfoMask.SIF_TRACKPOS | ScrollInfoMask.SIF_PAGE, ScrollInfoBar.SB_VERT);
                double totalRange = scrollInfo.nMax - scrollInfo.nMin + 1;
                double scrollRatio;

                // Is "Enable scrolling beyond last line" checked?
                if (Editor.GetEndAtLastLine() == false)
                {
                    var actualThumbHeight = totalRange / (totalRange / scrollInfo.nPage - 1);
                    var actualTrackPos = scrollInfo.nTrackPos * actualThumbHeight / scrollInfo.nPage;

                    scrollRatio = Math.Min(1, actualTrackPos / (totalRange - actualThumbHeight));
                }
                else
                {
                    scrollRatio = scrollInfo.nTrackPos / (totalRange - scrollInfo.nPage);
                }

                this.renderer.ScrollByRatioVertically(scrollRatio);
            }
            catch { }            
        }

        /// <summary>
        /// 
        /// </summary>
        public void CommandMenuInit()
        {
            this.configuration = new MarkdownViewerConfiguration();

            //Register our commands
            PluginBase.SetCommand(this.commandId, Main.PluginName, MarkdownViewerCommand, new ShortcutKey(true, false, true, System.Windows.Forms.Keys.M));
            //Separator
            PluginBase.SetCommand(this.commandId + 1, "---", null);
            //Synchronized scrolling
            PluginBase.SetCommand(this.commandIdSynchronize, "Synchronize scrolling (Editor -> Viewer)", SynchronizeScrollingCommand, this.configuration.options.synchronizeScrolling);
            //Separator
            PluginBase.SetCommand(this.commandIdSynchronize + 1, "---", null);
            //Options
            PluginBase.SetCommand(this.commandIdOptions, "Options", OptionsCommand);
            //About
            PluginBase.SetCommand(this.commandIdAbout, "About", AboutCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        public void OptionsCommand()
        {
            using (MarkdownWebOptions options = new MarkdownWebOptions(ref this.configuration))
            {
                if (options.ShowDialog(Control.FromHandle(PluginBase.GetCurrentScintilla())) == DialogResult.OK)
                {
                    //Update after something potentially changed in the settings dialog
                    Update(true, true);
                }
            }
        }

        /// <summary>
        /// Show the AboutDialog as modal to the Notepad++ window
        /// </summary>
        public void AboutCommand()
        {
            using (AboutDialog about = new AboutDialog())
            {
                about.ShowDialog(Control.FromHandle(PluginBase.GetCurrentScintilla()));
            }
        }

        /// <summary>
        /// Check/Uncheck the configuration item
        /// </summary>
        protected void SynchronizeScrollingCommand()
        {
            this.configuration.options.synchronizeScrolling = !this.configuration.options.synchronizeScrolling;
            Win32.CheckMenuItem(Win32.GetMenu(PluginBase.nppData._nppHandle), PluginBase._funcItems.Items[this.commandIdSynchronize]._cmdID, Win32.MF_BYCOMMAND | (this.configuration.options.synchronizeScrolling ? Win32.MF_CHECKED : Win32.MF_UNCHECKED));
            if (this.configuration.options.synchronizeScrolling)
            {
                UpdateScrollBar();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToolBarIcon()
        {
            toolbarIcons toolbarIcons = new toolbarIcons();
            toolbarIcons.hToolbarBmp = Resources.markdown_16x16_solid.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(toolbarIcons));
            Marshal.StructureToPtr(toolbarIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[this.commandId]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        /// <summary>
        /// 
        /// </summary>
        public void MarkdownViewerCommand()
        {
            bool visibility = !this.renderer.Visible;
            ToggleToolbarIcon(visibility);
            //Show
            if (visibility)
            {
                UpdateEditorInformation();
                Update(true, true);
                Editor.SetFocus(true);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        protected void UpdateEditorInformation()
        {
            this.Editor.SetScintillaHandle(PluginBase.GetCurrentScintilla());
            this.FileInfo = new FileInformation() {
                FileName = this.Notepad.GetCurrentFileName(),
                FileDirectory = this.Notepad.GetCurrentDirectory()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="show"></param>
        /// <returns></returns>
        public void ToggleToolbarIcon(bool show = true)
        {
            //To show or not to show
            NppMsg msg = show ? NppMsg.NPPM_DMMSHOW : NppMsg.NPPM_DMMHIDE;
            //
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)msg, 0, this.renderer.Handle);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SETMENUITEMCHECK, PluginBase._funcItems.Items[this.commandId]._cmdID, show ? 1 : 0);
            //
            this.rendererVisible = this.renderer.Visible;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void UpdateMarkdownViewer()
        {
            try
            {
                if (this.updateRenderer)
                {
                    this.updateRenderer = false;
                    this.renderer.Render(this.Editor.GetText(this.Editor.GetLength() + 1), this.FileInfo);
                }
            }
            catch
            {
                this.renderer.Render("<p>Couldn't render the currently selected file!</p>", this.FileInfo);
            }
        }

        /// <summary>
        /// Save the configuration
        /// </summary>
        public void PluginCleanUp()
        {
            this.configuration.Save();
        }
    }
}
