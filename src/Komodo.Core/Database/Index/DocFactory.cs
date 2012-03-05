using Komodo.Core.Types.Model;
using Lucene.Net.Documents;

namespace Komodo.Core.Database.Index
{
    public static class DocFactory
    {
        public static Document CreateFilmDocument(Film film)
        {
            var d = new Document();
            d.Add(NewField("Id",film.Id.ToString()));
            d.Add(NewField("Title",film.Title));
            d.Add(NewField("Synopsis",film.Synopsis));
            d.Add(NewField("ReleaseDate",film.ReleaseDate));

            foreach (var director in film.Directors)
            {
                d.Add(NewField("Director", director.Name));
            }

            foreach (var person in film.Writers)
            {
                d.Add(NewField("Person", person.Name));
            }

            foreach (var genre in film.Genres)
            {
                d.Add(NewField("Genre", genre.GenreName));
            }
            
            foreach (var role in film.Cast)
            {
                d.Add(NewField("Cast",role.ToString()));
            }
            
            foreach (var keyWord in film.KeyWords)
            {
                d.Add(NewField("Keyword",keyWord.Word));
            }
            
            return d;
        }

        private static Field NewField(string name, string value)
        {
            return new Field(name, value,Field.Store.YES,Field.Index.ANALYZED);
        }
    }
}
