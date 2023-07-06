using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Game7D2D.Class
{
    public class CraftingBook
    {
        public int CurLevel;
        public int MaxLevel;
        public string Name;
        public string GameName;
        public int SelectedLevel;

        public CraftingBook(string name, string gameName, int curLevel, int maxLevel)
        {
            CurLevel = curLevel;
            MaxLevel = maxLevel;
            Name = name;
            GameName = gameName;
            SelectedLevel = maxLevel;
        }
    }
}
