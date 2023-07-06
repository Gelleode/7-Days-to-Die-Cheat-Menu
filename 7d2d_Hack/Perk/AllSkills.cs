using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Utilities;

namespace Game7D2D.Class
{
    public class AllSkills
    {
        public static List<Perks> Strength = InitPerks.StrengthPerkList;
        public static List<Perks> Fortitude = InitPerks.FortitudePerkList;
        public static List<Perks> Agility = InitPerks.AgilityPerkList;
        public static List<Perks> Intellect = InitPerks.IntellectPerkList;
        public static List<Perks> Perception = InitPerks.PerceptionPerkList;

        public static List<Perks> CraftingBooks = InitPerks.CraftingBooksList;

        //public static List<SkillBook> SkillBooks = InitPerks.SkillBooksList;
    }
}
