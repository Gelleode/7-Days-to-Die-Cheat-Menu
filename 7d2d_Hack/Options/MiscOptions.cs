using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Utilities;
using UnityEngine;

namespace Game7D2D.Options
{
    public class MiscOptions
    {
        private bool _creativeMenu = false;
        private bool _debugMenu = false;
        public bool ConsoleCommands = false;
        public bool DisplayAllPlayers = false;
        public bool BuildHelper = false;
        public float BuildDistance = 5f;
        public float BuildInterval = 0.2f;
        public bool Pickup = false;
        public float PickupDistance = 3.5f;
        public bool ShowAllPlayersOnMap = false;

        public string UISkin = "";

        public Dictionary<string, Color32> GlobalColors = new Dictionary<string, Color32>();

        public bool CreativeMenu
        {
            get { return _creativeMenu; }
            set
            {
                _creativeMenu = value;
                Cheats.Misc.SetCreativeMenu();
            }
        }
        public bool DebugMenu
        {
            get { return _debugMenu; }
            set
            {
                _debugMenu = value;
                Cheats.Misc.SetDebugMenu();
            }
        }
    }
}
