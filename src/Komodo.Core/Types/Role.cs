using System;

namespace Komodo.Core.Types
{
    public class Role
    {
        public virtual Guid Id { get; set; }
        public virtual string CharacterName { get; set; }
        public virtual Person Actor { get; set; }
    }
}
