using FluentNHibernate.Mapping;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Mappings
{
    public class FilmMap : ClassMap<Film>
    {
        public FilmMap()
        {
            Id(x => x.Id).Unique();
            Map(x => x.Title).Length(100);
            Map(x => x.Synopsis).Length(2000);
            Map(x => x.ReleaseDate).Length(4);
            Map(x => x.Url).Length(256);

            HasManyToMany(x => x.Directors).AsBag().Cascade.All();
            HasManyToMany(x => x.Writers).AsBag().Cascade.All();
            HasManyToMany(x => x.Genres).AsBag().Cascade.All();
            HasManyToMany(x => x.Cast).AsBag().Cascade.All();
            HasManyToMany(x => x.KeyWords).AsBag().Cascade.All();
            HasMany(x => x.Files).Element("Files");
        }
    }
}