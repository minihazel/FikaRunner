using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaRunner
{
    public class ProfileData
    {
        public class ProfileStructure
        {
            public InfoSection? info { get; set; }
            public CharactersSection? characters { get; set; }
            public Dictionary<string, object>? dialogues { get; set; }
            public InraidSection? inraid { get; set; }
            public object[]? insurance { get; set; }
        }

        public class InfoSection
        {
            public string? id { get; set; }
            public string? scavId { get; set; }
            public int? aid { get; set; }
            public string? username { get; set; }
            public bool? wipe { get; set; }
            public string? edition { get; set; }
        }

        public class CharactersSection
        {
            public CharacterData? pmc { get; set; }
            public CharacterData? scav { get; set; }
        }

        public class InfoData
        {
            public string? Side { get; set; }
            public int? Level { get; set; }
        }

        public class CharacterData
        {
            public InfoData? Info { get; set; }
            public object? savage { get; set; }
            public object? Encyclopedia { get; set; }
            public object? Hideout { get; set; }
            public object[]? WishList { get; set; }
        }

        public class InraidSection
        {
            public string? location { get; set; }
            public string? character { get; set; }
        }

        public class UserInfo
        {
            public string? id { get; set; }
            public string? scavId { get; set; }
            public int? aid { get; set; }
            public string? username { get; set; }
            public bool? wipe { get; set; }
            public string? edition { get; set; }
        }
    }
}
