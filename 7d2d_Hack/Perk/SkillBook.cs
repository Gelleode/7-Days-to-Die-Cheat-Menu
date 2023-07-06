using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game7D2D.Class
{
    public class SkillBook
    {
        public string GameName;
        public bool Read;

        public SkillBook(string gameName, bool read)
        {
            GameName = gameName;
            Read = read;
        }
    }
}
