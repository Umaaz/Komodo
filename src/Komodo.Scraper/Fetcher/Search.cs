using System.Collections.Generic;

namespace Komodo.Scraper.Fetcher
{
    public abstract class Search
    {
        public IList<Result> Results { get; set; }

        protected Search(string title)
        {
            
        }

        public abstract void Find();
    }
}
