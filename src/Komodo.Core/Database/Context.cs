using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Komodo.Core.Types.Model;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Komodo.Core.Database
{
    public static class Context
    {
        private static ISession _session;
        private static ISessionFactory _sessionFactory;

        public static ISession GetSession()
        {
            return _session ?? (_session = _sessionFactory.OpenSession());
        }

        public static void Bootstrap()
        {
            var cnxString = Properties.Settings.Default.ConnectionString;
            const string dbPath = "Media.sdf";
            var configuration = Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(cnxString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Film>());
                                                     // .Conventions.AddFromAssemblyOf<Film>());

            if (!File.Exists(dbPath))
            {
                var engine = new System.Data.SqlServerCe.SqlCeEngine(cnxString);
                engine.CreateDatabase();

                configuration.ExposeConfiguration(c => new SchemaExport(c).Create(false, true));
            }
            _sessionFactory = configuration.BuildSessionFactory();
        }
    }
}
