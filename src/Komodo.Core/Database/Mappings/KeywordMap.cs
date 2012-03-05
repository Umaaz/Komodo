using FluentNHibernate.Mapping;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Mappings
{
    public class KeywordMap : ClassMap<KeyWord>
    {
        public KeywordMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Word).Unique().Length(20);
        }
    }
}
