using System;
using Komodo.Scraper.Fetcher.Types;

namespace Komodo.Scraper.IMDB.Types
{
    public class ImdbResult : Result
    {
        public string PicUrl { get; set; }
        public string Year { get; set; }

        public ImdbResult(String title, String url, String year, String picUrl) : base(title, url)
        {
            Url = url;
            Title = title;
            Year = year;
            PicUrl = picUrl;
        }
    }
}
