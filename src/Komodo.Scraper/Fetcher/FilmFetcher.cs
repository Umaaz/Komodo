using System;
using System.Collections.Generic;
using Komodo.Core.Types;
using Komodo.Core.Types.Model;
using Komodo.Scraper.Fetcher.Types;
using Komodo.Scraper.IMDB;

namespace Komodo.Scraper.Fetcher
{
    public class FilmFetcher
    {
        public enum Source
        {
            Imdb
        };

        public Film Film { get; set; }
        public IList<Result> Results { get; set; }

        public FilmFetcher(string title, Source source = Source.Imdb)
        {
            if(string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
            switch(source)
            {
                case Source.Imdb:
                    Film = ImdbFilmFetcher.GetFilmFromImdb(title);
                    break;
            }
        }
    }
}
