using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Class;

namespace Game7D2D.Options
{
    public class ESPOptions
    {
        public bool Enabled = false;
        public bool Glow = false;
        public bool Box = true;
        public bool Bones = false;
        public bool Distance = true;
        public bool Name = true;
        public bool Tracers = false;
        public int MaxDistance = 400;
        public int FontSize = 11;
        public ShaderType ChamType = ShaderType.Material;

        public bool Visible = false; // Indicates if enemy is hittable (trace ray)  
    }
}
