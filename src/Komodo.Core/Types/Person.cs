using System;

namespace Komodo.Core.Types
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Url { get; set; }
    }
}
