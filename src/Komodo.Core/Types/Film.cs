using System;
using System.Collections.Generic;
using System.Linq;

namespace Komodo.Core.Types
{
    public class Film
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual IList<Person> Directors { get; set; }
        public virtual IList<Person> Writers { get; set; }
        public virtual IList<Genre> Genres { get; set; }
        public virtual string Synopsis { get; set; }
        public virtual IList<Role> Cast { get; set; }
        public virtual IList<KeyWord> KeyWords { get; set; }
        public virtual string Url { get; set; }

        public override string ToString()
        {
            return "Title: " + Title + Environment.NewLine +
                   "Directors: " + Directors.Aggregate("", (current, director) => current + (director.Name + Environment.NewLine)) + Environment.NewLine +
                   "Writers: " + Writers.Aggregate("", (current, writer) => current + (writer.Name + Environment.NewLine)) + Environment.NewLine +
                   "Genres: " + Genres.Aggregate("", (current, genre) => current + (genre.GenreName + Environment.NewLine)) + Environment.NewLine +
                   "KeyWords: " + KeyWords.Aggregate("", (current, word) => current + (word.Word + Environment.NewLine)) + Environment.NewLine +
                   "Cast: " + Cast.Aggregate("", (current, role) => current + (role.ToString() + Environment.NewLine)) + Environment.NewLine +
                   "Synopsis: " + Synopsis + Environment.NewLine +
                   "URL: " + Url;
        }
    }
}
