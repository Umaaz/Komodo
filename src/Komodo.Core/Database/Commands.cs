using System.Data.SqlServerCe;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database
{
    public static class Commands
    {
        public static bool AddFilm(Film film)
        {
            var rtn = false;


            return rtn;
        }

        public static bool AddPerson(Person person)
        {
            using(var cn = new SqlCeConnection(Constants.ConnectionString()))
            {
                var insert = "INSERT INTO person (Name, Url) VALUES (@name, @url)";
                cn.Open();
                using (var command = new SqlCeCommand(insert, cn))
                {
                    command.Parameters.AddWithValue("@name", person.Name);
                    command.Parameters.AddWithValue("@url", person.Url);
                    command.ExecuteNonQuery();
                }
                var cmd = new SqlCeCommand("SELECT * FROM person", cn);
                var x = cmd.ExecuteReader();
                cn.Close();
            }

            return false;
        }
    }
}
