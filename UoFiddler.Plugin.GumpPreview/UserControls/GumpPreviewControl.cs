using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ultima;
using UoFiddler.Controls.Classes;
using UoFiddler.Controls.Helpers;
using UoFiddler.Plugin.GumpPreview.Classes;

namespace UoFiddler.Plugin.GumpPreview.UserControls
{
    public partial class GumpPreviewControl : UserControl
    {
        private bool _loaded;
        private List<GumpParser.LayoutEntry> _currentLayoutEntries;
        private List<string> _currentDataEntries;
        private int _currentPage = 0;

        public GumpPreviewControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            ControlEvents.FilePathChangeEvent += OnFilePathChangeEvent;
        }

        /// <summary>
        /// Reload when loaded
        /// </summary>
        private void Reload()
        {
            if (!_loaded)
            {
                return;
            }

            _loaded = false;
            OnLoad(this, EventArgs.Empty);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (FormsDesignerHelper.IsInDesignMode())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Options.LoadedUltimaClass["Art"] = true;
            Options.LoadedUltimaClass["Hues"] = true;
            Options.LoadedUltimaClass["Gumps"] = true;

            GumpPictureBox.Image = new Bitmap(GumpPictureBox.Width, GumpPictureBox.Height);

            _currentPage = 0;
            DrawGump();

            _loaded = true;
            Cursor.Current = Cursors.Default;
        }

        private void OnFilePathChangeEvent()
        {
            Reload();
        }

        private void OnClickPreview(object sender, EventArgs e)
        {
            if (!_loaded)
            {
                return;
            }

            _currentLayoutEntries = GumpParser.LoadLayout(LayoutTextBox.Text);
            _currentDataEntries = GumpParser.LoadData(DataTextBox.Text);

            DrawGump();
        }

        private void OnResizePreviewPic(object sender, EventArgs e)
        {
            GumpPictureBox.Image = new Bitmap(GumpPictureBox.Width, GumpPictureBox.Height);

            DrawGump();
        }

        private void DrawGump()
        {
            if (_currentLayoutEntries == null)
            {
                return;
            }

            using (Graphics graphPic = Graphics.FromImage(GumpPictureBox.Image))
            {
                graphPic.Clear(Color.AliceBlue);

                foreach(GumpParser.LayoutEntry entry in _currentLayoutEntries)
                {
                    if (entry.Type == GumpParser.TypeLayout.Page && entry.PageId != _currentPage)
                    {
                        break;
                    }

                    switch(entry.Type)
                    {
                        case GumpParser.TypeLayout.Gump:
                            {
                                graphPic.DrawImage(Gumps.GetGump(entry.Id), new Point(entry.X, entry.Y));
                                break;
                            }
                        case GumpParser.TypeLayout.Tile:
                            {
                                graphPic.DrawImage(Art.GetStatic(entry.Id), new Point(entry.X, entry.Y));
                                break;
                            }
                        case GumpParser.TypeLayout.ResizePic:
                            {
                                List<Bitmap> gmp = new List<Bitmap>();
                                for(int i = 0; i < 9; i++)
                                {
                                    gmp.Add(new Bitmap(Gumps.GetGump(entry.Id + i)));
                                }
                                int width = gmp[0].Width + gmp[1].Width + gmp[2].Width;
                                int height = gmp[2].Height + gmp[3].Height + gmp[6].Height;

                                Bitmap myTest = new Bitmap(width, height);
                                using (Graphics g = Graphics.FromImage(myTest))
                                {
                                    g.Clear(Color.Transparent);
                                    
                                    int x = 0;
                                    int y = 0;
                                    for(int i = 0; i < 9; i++)
                                    {
                                        g.DrawImage(gmp[i], x, y, gmp[i].Width, gmp[i].Height);
                                        x += gmp[i].Width;

                                        if(i>0 && i%3==2)
                                        {
                                            x = 0;
                                            y += gmp[i].Height;
                                        }
                                    }
                                }

                                Bitmap result = new Bitmap(entry.Width, entry.Height);
                                using (Graphics g = Graphics.FromImage(result))
                                {
                                    g.DrawImage(myTest, 0, 0, entry.Width, entry.Height);
                                }
                                graphPic.DrawImage(result, new Point(entry.X, entry.Y));
                                break;
                            }
                        case GumpParser.TypeLayout.Text:
                            {
                                string text = entry.Id < _currentDataEntries.Count ? _currentDataEntries[entry.Id] : "";
                                graphPic.DrawString(text, new Font("Arial", 10), new SolidBrush(Hues.HueToColor(entry.Color)), new Point(entry.X, entry.Y));
                                break;
                            }
                        case GumpParser.TypeLayout.Button:
                            {
                                graphPic.DrawImage(Gumps.GetGump(entry.ReleasedId), new Point(entry.X, entry.Y));
                                break;
                            }
                    }
                }
            }
            GumpPictureBox.Invalidate();
        }
    }
}
