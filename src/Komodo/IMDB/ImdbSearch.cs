using System;
using System.Collections.Generic;
using Komodo.Scraper.Fetcher;

namespace Komodo.Scraper.IMDB
{
    public class ImdbSearch : Search
    {
        public ImdbSearch(string title) : base(title)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
        }

        public new IList<Result> Find()
        {
            throw new NotImplementedException();
        }
    }
}
