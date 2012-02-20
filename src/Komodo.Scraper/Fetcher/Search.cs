using System.Collections.Generic;
using Komodo.Scraper.Fetcher.Types;

namespace Komodo.Scraper.Fetcher
{
    public abstract class Search
    {
        public IList<Result> Results { get; set; }

        protected Search(string title)
        {
            Results = new List<Result>();
        }

        protected abstract void Find();
    }
}
