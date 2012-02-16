using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Komodo.Core.Types;
using Komodo.Scraper.Exceptions;
using Komodo.Scraper.Fetcher.Types;
using Komodo.Scraper.IMDB;
using Komodo.Scraper.IMDB.Types;
using Komodo.Scraper.StringManipulation;

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
                case Source.Imdb: GetFilmFromImdb(title);
                    break;
            }
        }

        public void GetFilmFromImdb(string title)
        {
            //search imdb for film
            Search search;
            try
            {
                search = new ImdbSearch(title);
            }
            catch(SourceInvalidException sie)
            {
                Console.WriteLine(sie);
                return;
            }
            if(search.Results.Count == 0)
                return;
            //use top search
            var top = search.Results[0];
            GetFilmFromImdbResult((ImdbResult)top);

        }

        public void GetFilmFromImdbResult(ImdbResult resultToCollect)
        {
            var filmSource = PageFetcher.GetSource(resultToCollect.Url);
            var f = GetParts(filmSource);
            var directos = GetDirectors(f[0]);
            return;
        }

        private List<string> GetParts(string source)
        {
            var parts = Regex.Split(source, "<div");
            return parts.Where(part => part.Contains("Directors:") || part.Contains("Writers:") || part.Contains("Storyline")).ToList();
        }

        private List<Person> GetDirectors(string directorSource)
        {
            var directors = new List<Person>();
            if (!directorSource.Contains("href=\"/name/nm"))
                return null;
            while (directorSource.Contains("href=\"/name/nm"))
            {
                directorSource = directorSource.Remove(0, directorSource.IndexOf("href=\"/name/nm"));
                var parts = Extractor.Extract("href=\"/name/{X}/\"   itemprop=\"director\"     >{X}</a>", directorSource);
                directors.Add(new Person{Name = parts[1],Url = parts[0]});
                directorSource = directorSource.Remove(0, directorSource.IndexOf("href=\"/name/nm") + 5);
            }
            return directors;
        }
    }
}
