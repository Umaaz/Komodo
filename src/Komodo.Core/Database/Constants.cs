namespace Komodo.Core.Database
{
    public static class Constants
    {
        public const string File = "Films.sdf";

        public const string FilmTable = "CREATE TABLE Film (FilmID integer (4) IDENTITY(1,1),"
                                         + "Title nvarchar(40) NOT NULL,"
                                         + "Synopsis nvarchar(400),"
                                         + "Url nvarchar(255),"
                                         + "CONSTRAINT pk_film PRIMARY KEY (FilmID))";
        
        public const string PersonTable = "CREATE TABLE Person (PersonID integer (4) IDENTITY(1,1),"
                                           + "Name nvarchar(40) NOT NULL,"
                                           + "Url nvarchar(255),"
                                           + "CONSTRAINT pk_person PRIMARY KEY (PersonID))";

        public const string RoleTable = "CREATE TABLE Role (RoleID integer (4) IDENTITY(1,1),"
                                         + "FilmID integer (4) NOT NULL,"
                                         + "CharacterName nvarchar (20),"
                                         + "PersonID integer (4) NOT NULL,"
                                         + "CONSTRAINT pk_roleID PRIMARY KEY (RoleID),"
                                         + "CONSTRAINT fk_role_film FOREIGN KEY (FilmID) REFERENCES Film (FilmID),"
                                         + "CONSTRAINT fk_role_person FOREIGN KEY (PersonID) REFERENCES Person (PersonID))";

        public static string ConnectionString()
        {
            return string.Format("DataSource=\"{0}\"", File);
        }
    }
}
