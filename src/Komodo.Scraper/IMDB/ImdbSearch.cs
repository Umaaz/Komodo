using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Komodo.Scraper.Exceptions;
using Komodo.Scraper.Fetcher;
using Komodo.Scraper.IMDB.Types;
using Komodo.Scraper.Net;
using Komodo.Scraper.StringManipulation;

namespace Komodo.Scraper.IMDB
{
    public sealed class ImdbSearch : Search
    {
        public enum ImdbSortType
        {
            moviemeter,
            alpha,
            user_rating,
            num_votes,
            boxoffice_gross_us,
            runtime,
            year,
            release_date_us
        };
        
        public static ImdbSortType SortBy = ImdbSortType.moviemeter;
        public static bool Ascending = true;

        public string FilmTitle { get; set; }
        public IList<string> s { get; set; }

        public ImdbSearch(string title) : base(title)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
            FilmTitle = title;
            Find();
        }

        protected override void Find()
        {
            var source = PageFetcher.GetSource("http://www.imdb.com/search/title?sort=" + SortBy + "," + (Ascending ? "asc" : "desc") + "&title=" + FilmTitle.Replace(" ","%20") + "&title_type=feature,tv_movie");
            var resultsAsStrings = new List<string>();
            var firstSplit = Regex.Split(source, "<tr class=\"even detailed\">");
            for (var i = 1; i < firstSplit.Length; i++)
            {
                resultsAsStrings.AddRange(Regex.Split(firstSplit[i], "<tr class=\"odd detailed\">"));
            }
            foreach (var resultsAsString in resultsAsStrings)
            {
                Results.Add(StringSourceToImdbResult(resultsAsString));
            }
        }

        private IMDB.Types.ImdbResult StringSourceToImdbResult(string resultsAsString)
        {
            if (string.IsNullOrEmpty(resultsAsString) || string.IsNullOrWhiteSpace(resultsAsString))
                throw new ArgumentNullException("resultsAsString");
            if (!Regex.IsMatch(resultsAsString, @"<a href=""/title/\w\w[0-9]{7}/"" title=""[^""]*""><img src=""[^""]*"" height=""[0-9]*"" width=""[0-9]*"" alt=""[^""]*"" title=""[^""]*""></a>"))
                throw new SourceInvalidException("given source did not contain match expression");
            var holdString = resultsAsString.Remove(resultsAsString.IndexOf("</a>"));
            holdString = holdString.Remove(0, holdString.IndexOf("<a href"));
            var items = Extractor.Extract("<a href=\"/title/{X}/\" title=\"{X}({X})\"><img src=\"{X}\"", holdString);
            return new ImdbResult(HtmlEscapeCharConverter.Decode(items[1]),Constants.ImdbFilmPrefixUrl + items[0],items[2],items[3]);
        }
    }
}
