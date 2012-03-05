using System;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Commands
{
    public class Get
    {
        public static Film GetFilm(Guid id)
        {
            return Context.GetSession().Get<Film>(id);
        }
    }
}
