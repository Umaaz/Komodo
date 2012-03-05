using System;

namespace Komodo.Core.Types.Model
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
