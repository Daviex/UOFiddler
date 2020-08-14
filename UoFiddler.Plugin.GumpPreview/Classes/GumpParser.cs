using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ultima;

namespace UoFiddler.Plugin.GumpPreview.Classes
{
    /*
     {
     "page 0",
     "gumppic 240 0 100",
     "text 270 30 48 0",
     "text 270 50 48 31"
     }
    */
    public class GumpParser
    {
        #region Param parser
        private static Dictionary<string, Func<string, LayoutEntry>> _gumpCommandsParsing = new Dictionary<string, Func<string, LayoutEntry>>()
        {
            {"nomove", x => NoParamCommand(x)},
            {"nodispose", x => NoParamCommand(x)},
            {"noclose", x => NoParamCommand(x)},
            {"page", x => PageCommand(x)},
            {"gumppic", x => GumpPicCommand(x)},
            {"tilepic", x => TilePicCommand(x)},
            {"resizepic", x => ResizePicCommand(x)},
            {"text", x => TextCommand(x)},
            {"textentry", x => TextEntryCommand(x)},
            {"button", x => ButtonCommand(x)},
            {"group", x => GroupCommand(x)}/*,
            {"radio", },
            {"checkbox", },
            {"htmlgump", },
            {"checkertrans", }*/
        };

        private static LayoutEntry NoParamCommand(string param)
        {
            return new LayoutEntry
            {
                Type = TypeLayout.NoParam
            };
        }

        private static LayoutEntry PageCommand(string param)
        {
            Match match = Regex.Match(param, @"page\s([0-9]*)");
            return new LayoutEntry
            {
                Type = TypeLayout.Page,
                PageId = Convert.ToInt32(match.Groups[1].Value ?? "-1")
            };
        }

        private static LayoutEntry GumpPicCommand(string param)
        {
            Match match = Regex.Match(param, @"gumppic\s([0-9]*)\s([0-9]*)\s([0-9]*)");
            return new LayoutEntry
            {
                Type = TypeLayout.Gump,
                X = Convert.ToInt32(match.Groups[1].Value ?? "-1"),
                Y = Convert.ToInt32(match.Groups[2].Value ?? "-1"),
                Id = Convert.ToInt32(match.Groups[3].Value ?? "-1")
            };
        }

        private static LayoutEntry TilePicCommand(string param)
        {
            Match match = Regex.Match(param, @"tilepic\s([0-9]*)\s([0-9]*)\s([0-9]*)");
            return new LayoutEntry
            {
                Type = TypeLayout.Tile,
                X = Convert.ToInt32(match.Groups[1].Value ?? "-1"),
                Y = Convert.ToInt32(match.Groups[2].Value ?? "-1"),
                Id = Convert.ToInt32(match.Groups[3].Value ?? "-1")
            };
        }

        private static LayoutEntry ResizePicCommand(string param)
        {
            Match match = Regex.Match(param, @"resizepic\s([0-9]*)\s([0-9]*)\s([0-9]*)\s([0-9]*)\s([0-9]*)");
            return new LayoutEntry
            {
                Type = TypeLayout.ResizePic,
                X = Convert.ToInt32(match.Groups[1].Value ?? "-1"),
                Y = Convert.ToInt32(match.Groups[2].Value ?? "-1"),
                Id = Convert.ToInt32(match.Groups[3].Value ?? "-1"),
                Width = Convert.ToInt32(match.Groups[4].Value ?? "-1"),
                Height = Convert.ToInt32(match.Groups[5].Value ?? "-1")
            };
        }

        private static LayoutEntry TextCommand(string param)
        {
            Match match = Regex.Match(param, @"text\s([0-9]*)\s([0-9]*)\s([0-9]*)\s([0-9]*)");
            return new LayoutEntry
            {
                Type = TypeLayout.Text,
                X = Convert.ToInt32(match.Groups[1].Value ?? "-1"),
                Y = Convert.ToInt32(match.Groups[2].Value ?? "-1"),
                Color = Convert.ToInt16(match.Groups[3].Value ?? "0"),
                Id = Convert.ToInt32(match.Groups[4].Value ?? "-1")
            };
        }

        private static LayoutEntry TextEntryCommand(string param)
        {
            Match match = Regex.Match(param, @"textentry\s([0-9]*)\s([0-9]*)\s([0-9]*)\s([0-9]*)\s([0-9]*)\s([0-9]*)\s([0-9]*)");
            return new LayoutEntry
            {
                Type = TypeLayout.TextEntry,
                X = Convert.ToInt32(match.Groups[1].Value ?? "-1"),
                Y = Convert.ToInt32(match.Groups[2].Value ?? "-1"),
                Width = Convert.ToInt32(match.Groups[3].Value ?? "-1"),
                Height = Convert.ToInt32(match.Groups[4].Value ?? "-1"),
                Color = Convert.ToInt16(match.Groups[5].Value ?? "0"),
                ReturnValue = Convert.ToInt32(match.Groups[6].Value ?? "-1"),
                Id = Convert.ToInt32(match.Groups[7].Value ?? "-1")
            };
        }

        private static LayoutEntry ButtonCommand(string param)
        {
            Match match = Regex.Match(param, @"button(\s)(?(1)([0-9]*)(\s)(?(3)([0-9]*)(\s)(?(5)([0-9]*)(\s)(?(7)([0-9]*)(\s)(?(9)([0-9]*)(\s)(?(11)([0-9]*)(\s?)(?(13)([0-9]*)|)|)|)|)|)|)|)");
            return new LayoutEntry
            {
                Type = TypeLayout.Button,
                X = Convert.ToInt32(!string.IsNullOrEmpty(match.Groups[2].Value) ? match.Groups[2].Value : "-1"),
                Y = Convert.ToInt32(!string.IsNullOrEmpty(match.Groups[4].Value) ? match.Groups[4].Value : "-1"),
                ReleasedId = Convert.ToInt32(!string.IsNullOrEmpty(match.Groups[6].Value) ? match.Groups[6].Value : "-1"),
                PressedId = Convert.ToInt32(!string.IsNullOrEmpty(match.Groups[8].Value) ? match.Groups[8].Value : "-1"),
                Quit = match.Groups[10].Value == "1",
                PageId = Convert.ToInt32(!string.IsNullOrEmpty(match.Groups[12].Value) ? match.Groups[12].Value : "-1"),
                ReturnValue = Convert.ToInt32(!string.IsNullOrEmpty(match.Groups[14].Value) ? match.Groups[14].Value : "-1")
            };
        }

        private static LayoutEntry GroupCommand(string param)
        {
            Match match = Regex.Match(param, @"group\s([0-9]*)");
            return new LayoutEntry
            {
                Type = TypeLayout.Group,
                Id = Convert.ToInt32(match.Groups[1].Value ?? "-1")
            };
        }
        #endregion

        public static List<LayoutEntry> LoadLayout(string layoutString)
        {
            MatchCollection layoutsLines = new Regex("(?<!\\/\\/)\"(.*)\"(,|\n)").Matches(layoutString);
            List<LayoutEntry> entries = new List<LayoutEntry>();

            foreach (Match layout in layoutsLines)
            {
                string commandWithParam = layout.Groups[1].Value;
                string command = commandWithParam.Split(' ')[0];

                entries.Add(_gumpCommandsParsing[command](commandWithParam));
            }
            return entries;
        }

        public static List<string> LoadData(string dataString)
        {
            MatchCollection dataLines = new Regex("\"(.*)\"(,|\n)").Matches(dataString);
            List<string> entries = new List<string>();

            foreach (Match data in dataLines)
            {
                entries.Add(data.Groups[1].Value??"");
            }

            return entries;
        }

        public enum TypeLayout
        {
            NoParam = -1,
            Page = 0,
            Gump = 1,
            Tile = 2,
            ResizePic = 3,
            Text = 4,
            TextEntry = 5,
            Button = 6,
            Group = 7
        }

        public struct LayoutEntry
        {
            public TypeLayout Type;
            public int X { get; set; }
            public int Y { get; set; }
            public int Id { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public short Color { get; set; }          
            public int ReturnValue { get; set; }
            public int ReleasedId { get; set; }
            public int PressedId { get; set; }
            public bool Quit { get; set; }
            public int PageId { get; set; }
        }
    }
}
