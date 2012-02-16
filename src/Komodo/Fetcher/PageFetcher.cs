using System;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Komodo.Scraper.Exceptions;

namespace Komodo.Scraper.Fetcher
{
    public class PageFetcher
    {
        public HtmlDocument Page { get; private set; }
        public string Url { get; set; }

        public PageFetcher(string url)
        {
            Url = url;
            if (url == null)
                throw new ArgumentNullException("url");
            if(!ValidateUrl())
                throw new ArgumentException("url validation failed");
            var page = GetPage();
            if (page == null)
                throw new FetcherBuildFailedException("Unable to build fetcher for url specified");
            Page = page;
        }

        public HtmlDocument GetPage()
        {
            if (!Net.Checker.CheckNetConnection(Url))
                throw new ConnectionFailedException("Unable to connect to imdb.com");
            var hweb = new HtmlWeb();
            var doc = hweb.Load(Url);
            if (hweb.StatusCode != HttpStatusCode.OK)
                throw new ConnectionFailedException("Unable to connect to imdb.com");
            return doc;
        }

        public bool ValidateUrl()
        {
            if (Regex.IsMatch(Url, @"\b(http(s)?://)(www.)?.*\.(co\.uk|com|org|edu)(/?)(?!\.).*"))
                return true;
            if (Regex.IsMatch(Url, @"(www.)?.*\.(co\.uk|com|org|edu)(/?)(?!\.).*"))
            {
                Url = "http://" + Url;
                return true;
            }
            return false;
        }
    }
}
