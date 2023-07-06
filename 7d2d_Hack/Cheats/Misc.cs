using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Attributes;
using Game7D2D.Menu;
using Game7D2D.Utilities;
using UnityEngine;

namespace Game7D2D.Cheats
{
    [Comp]
    public class Misc : MonoBehaviour
    {
        public static Misc Instance;

        void Start() => Instance = this;

        void Update()
        {
            if (Manager.IsLoaded)
            {
                Constants.cBuildIntervall = Global.Settings.MiscOptions.BuildInterval;
                Constants.cDigAndBuildDistance = Global.Settings.MiscOptions.BuildDistance;
                Constants.cCollectItemDistance = Global.Settings.MiscOptions.PickupDistance;

                GamePrefs.Set(EnumGamePrefs.CreativeMenuEnabled, Global.Settings.MiscOptions.CreativeMenu);
                GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, Global.Settings.MiscOptions.DebugMenu);
            }
        }

        public static void SetCreativeMenu()
        {
            GamePrefs.Set(EnumGamePrefs.CreativeMenuEnabled, Global.Settings.MiscOptions.CreativeMenu);
        }
        public static void SetDebugMenu()
        {
            GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, Global.Settings.MiscOptions.DebugMenu);
        }
    }
}
