using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Komodo.Core.Types;
using Komodo.Scraper.Exceptions;
using Komodo.Scraper.Fetcher;
using Komodo.Scraper.IMDB.Types;
using Komodo.Scraper.StringManipulation;

namespace Komodo.Scraper.IMDB
{
    public class ImdbFilmFetcher
    {
        public static Film GetFilmFromImdb(string title)
        {
            //search imdb for film
            Search search;
            try
            {
                search = new ImdbSearch(title);
            }
            catch (SourceInvalidException sie)
            {
                Console.WriteLine(sie);
                return null;
            }
            if (search.Results.Count == 0)
                return null;
            //use top search
            var top = search.Results[0];
            return GetFilmFromImdbResult((ImdbResult)top);
        }

        private static Film GetFilmFromImdbResult(ImdbResult resultToCollect)
        {
            var film = new Film();
            var filmSource = PageFetcher.GetSource(resultToCollect.Url);
            var parts = GetDivParts(filmSource);
            if (parts.Count != 5)
                return null;
            film.Title = resultToCollect.Title;
            film.Url = resultToCollect.Url;
            film.Directors = GetDirectors(parts[0]);
            film.Writers = GetWriters(parts[1]);
            film.Synopsis = GetStoryline(parts[2]);
            film.KeyWords = GetKeyWords(parts[3]);
            film.Genres = GetGenres(parts[4]);
            parts = GetTableParts(filmSource);
            if (parts.Count != 1)
                return null;
            film.Cast = GetCast(parts[0]);
            return film;
        }

        private static List<Role>  GetCast(string castSource)
        {
            var cast = new List<Role>();
            var parts = Regex.Split(castSource, "<tr class=");
            foreach (var part in parts.Skip(1))
            {
                var bit = part.Remove(0, part.IndexOf("<td class=\"name\">"));
                var actorBit = bit.Remove(bit.IndexOf("</td>"));
                actorBit = actorBit.Remove(0, actorBit.IndexOf("href"));
                var bits = Extractor.ExtractAndDecode(@"href=""/name/{X}/""    >{X}<", actorBit);
                var p = new Person {Name = bits[1], Url = bits[0]};
                
                bit = part.Remove(0, part.IndexOf("<td class=\"character\""));
                var characterBit = bit.Remove(bit.IndexOf("</div>")+2);
                if (characterBit.Contains("href="))
                {
                    characterBit = characterBit.Remove(0, characterBit.IndexOf("<div>") + 5);
                    characterBit = characterBit.Remove(0, characterBit.IndexOf(">"));
                }
                else
                {
                    characterBit = characterBit.Remove(0, characterBit.IndexOf("<div>"));
                }
                bits = Extractor.ExtractAndDecode(">{X}<", characterBit);
                cast.Add(new Role{Actor = p, CharacterName = bits[0]});
            }
            return cast;
        }

        private static List<KeyWord>  GetKeyWords(string keyWordSource)
        {
            var keywords = new List<KeyWord>();
            var x = keyWordSource.IndexOf("</h4>") + 5;
            keyWordSource = keyWordSource.Remove(0, x);
            keyWordSource = keyWordSource.Replace("<span>|</span>", "");
            var bits = Regex.Split(keyWordSource, "<a");
            foreach (var bit in bits)
            {
                if(!Regex.IsMatch(bit, ">(.*)<"))
                    continue;
                var p = Extractor.Extract(">{X}<", bit);
                if (Regex.IsMatch(p[0], "see more", RegexOptions.IgnoreCase))
                    continue;
                keywords.Add(new KeyWord{Word =p[0]});
            }
            return keywords;
        }

        private static List<Genre> GetGenres(string genreSource)
        {
            var genres = new List<Genre>();
            var x = genreSource.IndexOf("</h4>") + 5;
            genreSource = genreSource.Remove(0, x);
            genreSource = genreSource.Replace("<span>|</span>", "");
            var bits = Regex.Split(genreSource, "<a");
            foreach (var bit in bits)
            {
                if (!Regex.IsMatch(bit, ">(.*)<"))
                    continue;
                var p = Extractor.Extract(">{X}<", bit);
                if (Regex.IsMatch(p[0], "see more", RegexOptions.IgnoreCase))
                    continue;
                genres.Add(new Genre {GenreName = p[0]});
            }
            return genres;
        }

        private static string GetStoryline(string storylineSource)
        {
            return (Extractor.ExtractAndDecode("<p>{X}<em", storylineSource)[0]);
        }

        private static List<string> GetTableParts(string source)
        {
            return Regex.Split(source, "<table class=\"cast_list\">").Where(part => Regex.IsMatch(part, "castlist")).Select(p => p.Remove(p.IndexOf("</table>"))).ToList();
        }
        
        private static List<string> GetDivParts(string source)
        {
            var parts = Regex.Split(source, "<div");
            return parts.Where(part => Regex.IsMatch(part, "Director(s)?:") || Regex.IsMatch(part, "Writer(s)?:") || Regex.IsMatch(part, "Storyline") || Regex.IsMatch(part, "Genre(s)?:") || Regex.IsMatch(part, "Plot Keyword(s)?:")).ToList();
        }

        private static List<Person> GetDirectors(string directorSource)
        {
            var directors = new List<Person>();
            if (!directorSource.Contains("href=\"/name/nm"))
                return null;
            while (directorSource.Contains("href=\"/name/nm"))
            {
                directorSource = directorSource.Remove(0, directorSource.IndexOf("href=\"/name/nm"));
                var parts = Extractor.ExtractAndDecode("href=\"/name/{X}/\"   itemprop=\"director\"     >{X}</a>", directorSource);
                directors.Add(new Person { Name = parts[1], Url = parts[0] });
                directorSource = directorSource.Remove(0, directorSource.IndexOf("href=\"/name/nm") + 5);
            }
            return directors;
        }

        private static List<Person> GetWriters(string writersSource)
        {
            var writers = new List<Person>();
            if (!Regex.IsMatch(writersSource, @"<a\s*onclick=""[^""]*""\s*href=""[^""]*""\s*>[^<]*</a>"))
                return null;
            while(writersSource.Contains("href=\"/name/nm"))
            {
                writersSource = writersSource.Remove(0, writersSource.IndexOf("href=\"/name/nm"));
                var parts = Extractor.ExtractAndDecode("href=\"/name/{X}/\"    >{X}</a>", writersSource);
                writers.Add(new Person { Name = parts[1], Url = parts[0] });
                writersSource = writersSource.Remove(0, writersSource.IndexOf("href=\"/name/nm") + 5);
            }
            return writers;
        }
    }
}
