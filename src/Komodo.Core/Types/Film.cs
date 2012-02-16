using System;
using System.Collections.Generic;

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
    }
}
