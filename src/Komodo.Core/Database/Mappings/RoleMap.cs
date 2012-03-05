using FluentNHibernate.Mapping;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.CharacterName).Length(30);
            References(x => x.Actor).Cascade.All();
        }
    }
}
