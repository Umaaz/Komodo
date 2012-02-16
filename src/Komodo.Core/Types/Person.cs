using System;

namespace Komodo.Core.Types
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
    }
}
