using FluentNHibernate.Mapping;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Mappings
{
    public class GenreMap : ClassMap<Genre>
    {
        public GenreMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.GenreName).Unique().Length(20);
        }
    }
}
