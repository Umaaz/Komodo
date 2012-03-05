using Komodo.Core.Database.Validations;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Commands
{
    public class Add
    {
        public static bool AddFilm(Film film)
        {
            var mayCommit = true;
            var session = Context.GetSession();
            using(var tx = session.BeginTransaction())
            {
                if (session.Get<Film>(film.Id) != null)
                    return false;
                var validator = new FilmValidator();
                var results = validator.Validate(film);
                if (results.IsValid)
                {
                    session.Save(film);
                    Index.Indexer.Index(film);
                }
                else
                    mayCommit = false;
                if(mayCommit)
                    tx.Commit();
            }
            return mayCommit;
        }
    }
}
