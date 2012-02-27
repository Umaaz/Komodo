using System;
using System.Collections.Generic;
using System.Linq;

namespace Komodo.Core.Types.Model
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<Person> Directors { get; set; }
        public IList<Person> Writers { get; set; }
        public IList<Genre> Genres { get; set; }
        public string Synopsis { get; set; }
        public IList<Role> Cast { get; set; }
        public IList<KeyWord> KeyWords { get; set; }
        public string Url { get; set; }

        public List<string> Files { get; set; }

        public Film()
        {
            Directors = new List<Person>();
            Writers = new List<Person>();
            Genres = new List<Genre>();
            Cast = new List<Role>();
            KeyWords = new List<KeyWord>();
            Files = new List<string>();
        }

        public override string ToString()
        {
            return "Title: " + Title + Environment.NewLine +
                   "Directors: " + Directors.Aggregate("", (current, director) => current + (director.Name + Environment.NewLine)) + Environment.NewLine +
                   "Writers: " + Writers.Aggregate("", (current, writer) => current + (writer.Name + Environment.NewLine)) + Environment.NewLine +
                   "Genres: " + Genres.Aggregate("", (current, genre) => current + (genre.GenreName + Environment.NewLine)) + Environment.NewLine +
                   "KeyWords: " + KeyWords.Aggregate("", (current, word) => current + (word.Word + Environment.NewLine)) + Environment.NewLine +
                   "Cast: " + Cast.Aggregate("", (current, role) => current + (role.ToString() + Environment.NewLine)) + Environment.NewLine +
                   "Synopsis: " + Synopsis + Environment.NewLine +
                   "URL: " + Url + Environment.NewLine +
                   "Files: " + Files.Aggregate("", (current, file) => current + (file + Environment.NewLine));
        }
    }
}
