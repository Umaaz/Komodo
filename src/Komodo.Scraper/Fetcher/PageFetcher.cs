using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Komodo.Scraper.Exceptions;

namespace Komodo.Scraper.Fetcher
{
    public class PageFetcher
    {
        public static HtmlDocument GetPage(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (!ValidateUrl(ref url))
                throw new ArgumentException("url validation failed");
            if (!Net.Checker.CheckNetConnection(url))
                throw new ConnectionFailedException("Unable to connect to imdb.com");
            var hweb = new HtmlWeb();
            var doc = hweb.Load(url);
            if (hweb.StatusCode != HttpStatusCode.OK)
                throw new ConnectionFailedException("Unable to connect to imdb.com");
            return doc;
        }

        private static bool ValidateUrl(ref string url)
        {
            if (Regex.IsMatch(url, @"\b(http(s)?://)(www.)?.*\.(co\.uk|com|org|edu)(/?)(?!\.).*"))
                return true;
            if (Regex.IsMatch(url, @"(www.)?.*\.(co\.uk|com|org|edu)(/?)(?!\.).*"))
            {
                url = "http://" + url;
                return true;
            }
            return false;
        }

        public static string GetSource(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            HttpWebResponse response;
            string source;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                var sr = new StreamReader(response.GetResponseStream());
                source = sr.ReadToEnd();
            }
            catch (WebException)
            {
                return null;
            }
            return source;
        }
    }
}
