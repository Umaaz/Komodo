using Komodo.Core.Types.Model;
using Lucene.Net.Documents;

namespace Komodo.Core.Database.Index
{
    public static class DocFactory
    {
        public static Document CreateFilmDocument(Film film)
        {
            var d = new Document();
            var nf = NewField("Id", film.Id.ToString());
            if(nf != null)
                d.Add(nf);
            nf = NewField("Title", film.Title);
            if (nf != null)
                d.Add(nf);
            nf = NewField("Synopsis", film.Synopsis);
            if (nf != null)
                d.Add(nf);
            nf = NewField("ReleaseDate", film.ReleaseDate);
            if (nf != null)
                d.Add(nf);
            
            foreach (var director in film.Directors)
            {
                nf = NewField("Director", director.Name);
                if (nf != null)
                    d.Add(nf);
            }

            foreach (var person in film.Writers)
            {
                nf = NewField("Person", person.Name);
                if (nf != null)
                    d.Add(nf);
            }

            foreach (var genre in film.Genres)
            {
                nf = NewField("Genre", genre.GenreName);
                if (nf != null)
                    d.Add(nf);
            }
            
            foreach (var role in film.Cast)
            {
                nf = NewField("Cast", role.ToString());
                if (nf != null)
                    d.Add(nf);
            }
            
            foreach (var keyWord in film.KeyWords)
            {
                nf = NewField("Keyword", keyWord.Word);
                if (nf != null)
                    d.Add(nf);
            }
            
            return d;
        }

        private static Field NewField(string name, string value)
        {
            if (value == null || name == null)
                return null;
            return new Field(name, value,Field.Store.YES,Field.Index.ANALYZED);
        }
    }
}
