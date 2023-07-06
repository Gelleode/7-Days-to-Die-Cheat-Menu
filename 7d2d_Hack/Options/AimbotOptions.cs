using Game7D2D.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game7D2D.Options
{
    public class AimbotOptions
    {
        public bool SilentAim = false;
        public bool SilentAimInfo = true;
        public int AimpointMultiplier = 1;
        public int HitboxSize = 15;
        public TargetLimb TargetL = TargetLimb.Head;
        public KeyCode AimlockKey = KeyCode.V;
        public List<ESPObject> SilentAimObjects = new List<ESPObject>();
        public bool OnlyVisible = false;
        public bool Aimlock = false;
        public bool Mouse1Aimbot = false;
        public bool AimlockLimitFOV = false;
        public int AimlockFOV = 200;
        public bool AimlockDrawFOV = true;
        public bool SilentAimLimitFOV = false;
        public int SilentAimFOV = 200;
        public bool SilentAimDrawFOV = true;
        public bool ExpandHitboxes = true;
        public int HitChance = 100;
        public bool HitEnemy = true;
        public bool HitPLayer = false;
    }
}
