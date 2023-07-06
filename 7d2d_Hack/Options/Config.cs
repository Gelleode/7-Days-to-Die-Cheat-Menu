using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game7D2D.Options
{
    public class Config
    {
        public ESPOptions EnemyOptions = new ESPOptions();
        public ESPOptions AnimalOptions = new ESPOptions();
        public ESPOptions PlayerOptions = new ESPOptions();
        public ESPOptions NPCOptions = new ESPOptions();
        public ESPOptions ItemOptions = new ESPOptions();

        public AimbotOptions AimbotOptions = new AimbotOptions();

        public MiscOptions MiscOptions = new MiscOptions();
        
    }
}
