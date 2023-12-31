using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.Crawling
{
    internal class SourceView_Path_finder
    {
        public readonly string AsuraAllComicPath;
        public readonly string AsuraSingle1ComicPath;
        public readonly string AsuraSingle2ComicPath;
        public readonly string AsuraSingle3ComicPath;

        public readonly string FlameAllComicPath;
        public readonly string FlameSingle1ComicPath;
        public readonly string FlameSingle2ComicPath;
        public readonly string FlameSingle3ComicPath;

        public readonly string ReaperAllComicPath;
        public readonly string ReaperSingle1ComicPath;
        public readonly string ReaperSingle2ComicPath;
        public readonly string ReaperSingle3ComicPath;

        public SourceView_Path_finder()
        {
            AsuraAllComicPath = GetFileViews("Asurascans", "Manga – Asura Scans.html");
            AsuraSingle1ComicPath = GetFileViews("Asurascans", "SSS-Class Suicide Hunter – Asura Scans.html");
            AsuraSingle2ComicPath = GetFileViews("Asurascans", "Terminally-Ill Genius Dark Knight – Asura Scans.html");
            AsuraSingle3ComicPath = GetFileViews("Asurascans", "The Reincarnated Assassin is a Genius Swordsman – Asura Scans.html");

            FlameAllComicPath = GetFileViews("Flamescans", "Manga Archive - Flame Comics.html");
            FlameSingle1ComicPath = GetFileViews("Flamescans", "In the Night Consumed by Blades, I Walk - Flame Comics.html");
            FlameSingle2ComicPath = GetFileViews("Flamescans", "Is This Hero for Real_ - Flame Comics.html");
            FlameSingle3ComicPath = GetFileViews("Flamescans", "I'll be Taking a Break for Personal Reasons - Flame Comics.html");

            ReaperAllComicPath = GetFileViews("Reaperscans", "Latest Comics - Reaper Scans.html");
            ReaperSingle1ComicPath = GetFileViews("Reaperscans", "Never Die Extra - Reaper Scans.html");
            ReaperSingle2ComicPath = GetFileViews("Reaperscans", "SSS-Class Suicide Hunter - Reaper Scans.html");
            ReaperSingle3ComicPath = GetFileViews("Reaperscans", "The Reincarnated Assassin is a Genius Swordsman - Reaper Scans.html");
        }
        /// <summary>
        /// Get's the root directory of the currently executed method
        /// </summary>
        /// <returns></returns>
        public string GetRootPath()
        {
            var pwd = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            return pwd.Parent.Parent.Parent.FullName;
        }

        /// <summary>
        /// Returns the root path combined with SourceViews
        /// </summary>
        /// <returns></returns>
        public string GetSourceViews()
        {
            return Path.Join(GetRootPath(), "SourceViews");
        }

        /// <summary>
        /// Returns a dynamic path depending on the scanlator name and the comic name.
        /// </summary>
        /// <param name="fragments"></param>
        /// <returns></returns>
        public string GetFileViews(params string[] fragments)
        {
            var first = new string[] { GetSourceViews() };
            return Path.Join(first.Concat(fragments).ToArray());
        }
    }
}
