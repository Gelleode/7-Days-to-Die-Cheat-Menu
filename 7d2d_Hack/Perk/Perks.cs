using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game7D2D.Class
{
    public class Perks
    {
        public string Name;
        public string GameName;
        public int CurLevel;
        public int MaxLevel;
        public int SelectedLevel;

        public Perks(string name, string gameName, int curLevel, int maxLevel)
        {
            Name = name;
            GameName = gameName;
            CurLevel = curLevel;
            MaxLevel = maxLevel;
            SelectedLevel = maxLevel;
        }
    }
}
