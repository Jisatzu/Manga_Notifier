﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga_Notifier
{
    public class Asurascans : IScanlators
    {
        private readonly string url;
        private List<Series_Info> seriesInfo;
        public Asurascans(string url) { 
            this.url = url;
            seriesInfo = new List<Series_Info>();
        }

        public List<string> GetAllComics(string responsBody)
        {
            HtmlDocument htmlDocument = new();
            List<string> comicSeriesInfos = new();
            htmlDocument.LoadHtml(responsBody);
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div/div[@class='bsx']/a/@href");
            foreach (HtmlNode node in nodes)
            {
                comicSeriesInfos.Add(node.GetAttributeValue("href", string.Empty));
            }
            return comicSeriesInfos;
        }

        public void ParseURLS(string webPage)
        {
            Series_Info series_Info = new();
            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(webPage);
            HtmlNode node = htmlDocument.DocumentNode.SelectSingleNode("//li[1]/div/div/a[@href]");

            series_Info.Name = htmlDocument.DocumentNode.SelectSingleNode("//h1").InnerText.Trim();
            series_Info.Id = int.Parse(htmlDocument.DocumentNode.SelectSingleNode("//div[@class='bookmark']").GetAttributeValue("data-id", "-999"));
            series_Info.URL = node.GetAttributeValue("href", string.Empty);
            series_Info.ChapterName = node.SelectSingleNode("./span[@class='chapternum']").InnerText.Trim();
        }
    }
}