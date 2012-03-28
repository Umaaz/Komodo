using System;
using System.Collections.Generic;
using System.Linq;
using Komodo.Core.Types.Model;
using NHibernate;
using NHibernate.Linq;

namespace Komodo.Core.Database.Commands
{
    public class Get
    {
        private readonly ISession _session;

        public Get()
        {
            _session = Context.GetSession();
        }

        public Film GetFilm(Guid id)
        {
            return _session.Get<Film>(id);
        }

        public List<Film> GetFilms()
        {
            return _session.Query<Film>().ToList();
        }

        public IQueryable<Film> GetQueryableFilms()
        {
            return _session.Query<Film>();
        }
    }
}
