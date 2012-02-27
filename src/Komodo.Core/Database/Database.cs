using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;

namespace Komodo.Core.Database
{
    public static class Database
    {
        private const string File = "Films.sdf";

        private const string FilmTable = "CREATE TABLE Film (FilmID int (4) NOT NULL,"
                                         + "Title nvarchar(40) NOT NULL,"
                                         + "Synopsis nvarchar(400),"
                                         + "Url nvarchar(255),"
                                         + "CONSTRAINT pk_film PRIMARY KEY (FilmID))";

        private const string PersonTable =   "CREATE TABLE Person (PersonID int (4) NOT NULL,"
                                           + "Name nvarchar(40) NOT NULL,"
                                           + "CONSTRAINT pk_person PRIMARY KEY (PersonID))";

        private const string RoleTable = "CREATE TABLE Role (RoleID int (4) NOT NULL,"
                                         + "FilmID int (4) NOT NULL,"
                                         + "CharacterName nvarchar (20),"
                                         + "PersonID int (4) NOT NULL,"
                                         + "CONSTRAINT pk_roleID PRIMARY KEY (RoleID),"
                                         + "CONSTRAINT fk_role_film FOREIGN KEY (FilmID) REFERENCES Film (FilmID),"
                                         + "CONSTRAINT fk_role_person FOREIGN KEY (PersonID) REFERENCES Person (PersonID))";
        
        private static string[] _tables = new[] { FilmTable, PersonTable, RoleTable };

        public static void BuildDatabase()
        {
            if(System.IO.File.Exists(File))
                return;
            var connectionString = string.Format("DataSource=\"{0}\"", File);
            var en = new SqlCeEngine(connectionString);
            en.CreateDatabase();
            BuildTables();
        }

        public static void BuildTables()
        {
            var cn = new SqlCeConnection(string.Format("DataSource=\"{0}\"", File));
            cn.Open();
            var commands = _tables.Select(table => new SqlCeCommand(table, cn)).ToList();
            foreach (var sqlCeCommand in commands)
            {
                sqlCeCommand.ExecuteNonQuery();
            }
            cn.Close();

        }
    }
}
