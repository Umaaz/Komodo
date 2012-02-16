using System;
using System.Collections.Generic;
using Komodo.Core.Types;

namespace Komodo.Scraper.Fetcher
{
    public class FilmFetcher
    {
        public Film Film { get; set; }
        public IList<Result> Results { get; set; }

        public FilmFetcher(string title)
        {
            if(string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
        }
    }
}
