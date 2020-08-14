using System;
using System.Windows.Forms;
using Ultima;
using UoFiddler.Controls.Classes;
using UoFiddler.Controls.Plugin;
using UoFiddler.Controls.Plugin.Interfaces;
using UoFiddler.Plugin.GumpPreview.UserControls;

namespace UoFiddler.Plugin.GumpPreview
{
    public class GumpPreviewPluginBase : PluginBase
    {
        private GumpPreviewControl _gumpPreviewControl;
        private TabPage _tabPage;
        private ToolStripMenuItem _toolStripMenuItem;

        public GumpPreviewPluginBase()
        {
            PluginEvents.DesignChangeEvent += Events_DesignChangeEvent;
            PluginEvents.ModifyItemShowContextMenuEvent += Events_ModifyItemShowContextMenuEvent;
        }

        /// <summary>
        /// Name of the plugin
        /// </summary>
        public override string Name { get; } = "GumpPreview";

        /// <summary>
        /// Description of the Plugin's purpose
        /// </summary>
        public override string Description { get; } = "Plugin to preview the gump made with POL strings";

        /// <summary>
        /// Author of the plugin
        /// </summary>
        public override string Author { get; } = "Daviex";

        /// <summary>
        /// Version of the plugin
        /// </summary>
        public override string Version { get; } = "0.0.1";

        /// <summary>
        /// Host of the plugin.
        /// </summary>
        public override IPluginHost Host { get; set; }

        public override void Initialize()
        {
            // make something useful
        }

        public override void Dispose()
        {
            _gumpPreviewControl.Dispose();
            _tabPage.Dispose();
            _toolStripMenuItem.Dispose();            
        }

        public override void ModifyTabPages(TabControl tabControl)
        {
            _tabPage = new TabPage
            {
                Tag = tabControl.TabCount + 1, // at end used for undock/dock feature to define the order
                Text = "GumpPreview"
            };

            _gumpPreviewControl = new UserControls.GumpPreviewControl
            {
                Dock = DockStyle.Fill
            };
            _tabPage.Controls.Add(_gumpPreviewControl);
            tabControl.TabPages.Add(_tabPage);
        }

        public override void ModifyPluginToolStrip(ToolStripDropDownButton toolStrip)
        {
            _toolStripMenuItem = new ToolStripMenuItem
            {
                Text = "GumpPreview"
            };
            _toolStripMenuItem.Click += ItemClick;
            toolStrip.DropDownItems.Add(_toolStripMenuItem);
        }

        private static void ItemClick(object sender, EventArgs e)
        {
        }

        private static void Events_DesignChangeEvent()
        {
            // do something useful here
        }

        private void Events_ModifyItemShowContextMenuEvent(ContextMenuStrip strip)
        {
        }
    }
}
