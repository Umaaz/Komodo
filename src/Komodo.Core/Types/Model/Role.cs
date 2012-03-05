using System;

namespace Komodo.Core.Types.Model
{
    public class Role
    {
        public virtual Guid Id { get; set; }
        public virtual string CharacterName { get; set; }
        public virtual Person Actor { get; set; }

        public override string ToString()
        {
            return CharacterName + Actor.Name;
        }
    }
}
