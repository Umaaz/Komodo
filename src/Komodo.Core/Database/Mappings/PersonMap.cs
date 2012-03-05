using FluentNHibernate.Mapping;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name).Length(30).Unique();
            Map(x => x.Url).Length(256);
        }
    }
}
