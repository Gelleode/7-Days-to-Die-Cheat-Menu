using Game7D2D.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Menu.Window;
using Game7D2D.Utilities;
using UnityEngine;
using Game7D2D.Class;

namespace Game7D2D.Menu.Tab
{
    public class MiscTab : MonoBehaviour
    {
        public static void Tab()
        {
            GUILayout.Space(0);
            GUILayout.BeginArea(new Rect(10, 35, 260, 400), style: "box", text: "Game");
            Global.Settings.MiscOptions.CreativeMenu =
                GUILayout.Toggle(Global.Settings.MiscOptions.CreativeMenu, "Creative Menu");
            Global.Settings.MiscOptions.DebugMenu =
                GUILayout.Toggle(Global.Settings.MiscOptions.DebugMenu, "Debug Menu");
            //Global.Settings.MiscOptions.FullBright = GUILayout.Toggle(Global.Settings.MiscOptions.FullBright, "Full Bright");

            Global.Settings.MiscOptions.BuildHelper = GUILayout.Toggle(Global.Settings.MiscOptions.BuildHelper, "Build Cheats");
            if (Global.Settings.MiscOptions.BuildHelper)
            {
                GUILayout.Label("Build Distance: " + Global.Settings.MiscOptions.BuildDistance);
                Global.Settings.MiscOptions.BuildDistance = (float)GUILayout.HorizontalSlider(Global.Settings.MiscOptions.BuildDistance, 1, 100);
                GUILayout.Label("Build Interval: " + Global.Settings.MiscOptions.BuildInterval);
                Global.Settings.MiscOptions.BuildInterval = (float)GUILayout.HorizontalSlider(Global.Settings.MiscOptions.BuildInterval, 0, 1);
            }

            Global.Settings.MiscOptions.Pickup = GUILayout.Toggle(Global.Settings.MiscOptions.Pickup, "Pickup Cheats");
            if (Global.Settings.MiscOptions.Pickup)
            {
                GUILayout.Label("Pick Up Distance: " + Global.Settings.MiscOptions.PickupDistance);
                Global.Settings.MiscOptions.PickupDistance = (float)GUILayout.HorizontalSlider(Global.Settings.MiscOptions.PickupDistance, 0, 50);
            }

            // It will exist as of for fun :)
            //if (GUILayout.Button("GUI Skin Changer"))
            //    Window.GUIWindow.GUISkinMenuOpen = !Window.GUIWindow.GUISkinMenuOpen;
            GUILayout.EndArea();
        }
    }
}
