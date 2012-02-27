using System.Data.SqlServerCe;
using System.Linq;

namespace Komodo.Core.Database
{
    public static class Database
    {

        private static readonly string[] Tables = new[] { Constants.FilmTable, Constants.PersonTable, Constants.RoleTable };

        public static void BuildDatabase()
        {
            if(System.IO.File.Exists(Constants.File))
                return;
            var en = new SqlCeEngine(Constants.ConnectionString());
            en.CreateDatabase();
            BuildTables();
        }

        public static void ReBuildDatabase()
        {
            if (System.IO.File.Exists(Constants.File))
                System.IO.File.Delete(Constants.File);
            BuildDatabase();
        }

        public static void BuildTables()
        {
            var cn = new SqlCeConnection(Constants.ConnectionString());
            cn.Open();
            var commands = Tables.Select(table => new SqlCeCommand(table, cn)).ToList();
            foreach (var sqlCeCommand in commands)
            {
                sqlCeCommand.ExecuteNonQuery();
            }
            cn.Close();
        }
    }
}
