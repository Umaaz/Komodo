namespace Komodo.Scraper.Fetcher.Types
{
    public abstract class Result
    {
        protected Result(string title, string url)
        {
            Title = title;
            Url = url;
        }

        public string Title { get; set; }
        public string Url { get; set; }
    }
}
