using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Class;

namespace Game7D2D.Perk
{
    public class PerkBookSet
    {
        public List<SkillBook> BookSet;
        public string Name;
        public string FinalGN;
        public bool FinalBook;

        public PerkBookSet(string name, string finalGN, List<SkillBook> bookSet)
        {
            BookSet = bookSet;
            Name = name;
            FinalGN = finalGN;
        }
    }
}
