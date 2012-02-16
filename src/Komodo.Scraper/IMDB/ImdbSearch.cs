using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Komodo.Scraper.Fetcher;

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
        public HtmlDocument Page { get; set; }
        public HtmlNode f { get; set; }
        public string s { get; set; }

        public ImdbSearch(string title) : base(title)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
            FilmTitle = title;
            Find();
        }

        public override void Find()
        {
            var page = PageFetcher.GetPage("http://www.imdb.com/search/title?sort=" + SortBy + "," + (Ascending? "asc":"desc") + "&title=" + FilmTitle + "&title_type=feature,tv_movie");
            Page = page;
            var node = page.DocumentNode.SelectSingleNode(".//tr[@class='even detailed']");
            f = node;
            s = PageFetcher.GetSource("http://www.imdb.com/search/title?sort=" + SortBy + "," + (Ascending ? "asc" : "desc") + "&title=" + FilmTitle + "&title_type=feature,tv_movie");
            var oddResults = page.DocumentNode.SelectNodes(".//tr[@class='odd detailed']");
            var evenResults = page.DocumentNode.SelectNodes(".//tr[@class='even detailed']");
            HtmlNodeCollection results;

        }
    }
}
