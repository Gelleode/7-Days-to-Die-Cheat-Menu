using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Game7D2D.Class;
using Platform;
using UnityEngine;

namespace Game7D2D.Utilities
{
    public static class SkillsUtilities
    {
        public static List<ProgressionValue> ProgressionValues = new List<ProgressionValue>();

        public static void InitSkills()
        {
            Manager.localP.entityPlayerLocal.Progression.GetDict().CopyValuesTo(ProgressionValues);
        }

        public static void GetAttributeSkills(List<Perks> attributePerksList)
        {
            foreach (var perk in attributePerksList)
            {
                perk.CurLevel = GetSkillLevel(perk.GameName);
            }
        }

        public static int GetSkillLevel(string Name) => ProgressionValues.Find(x => x.Name == Name).Level;

        public static void SetSkillLevel(string name,  int level) => ProgressionValues.Find(x => x.Name == name).Level = level;
    }
}
