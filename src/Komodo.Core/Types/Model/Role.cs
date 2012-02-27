using System;

namespace Komodo.Core.Types.Model
{
    public class Role
    {
        public Guid Id { get; set; }
        public string CharacterName { get; set; }
        public Person Actor { get; set; }

        public override string ToString()
        {
            return CharacterName + " played by " + Actor.Name;
        }
    }
}
