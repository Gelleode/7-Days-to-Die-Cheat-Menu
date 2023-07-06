using Game7D2D.Class;
using Game7D2D.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Utilities;
using UnityEngine;

namespace Game7D2D.Menu.Tab
{
    public class VisualsTab : MonoBehaviour
    {
        public static ESPObject SelectedObject = ESPObject.Player;
        private static Vector2 scrollPosition;
        public static ESPOptions SelectedOptions = Global.Settings.PlayerOptions;
        public static void Tab()
        {
            GUILayout.Space(0);
            GUILayout.BeginArea(new Rect(10, 35, 260, 400), style: "box", text: "ESP Selection");
            SelectedObject = (ESPObject)GUILayout.SelectionGrid((int)SelectedObject, Main.buttons2.ToArray(), 1);
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(280, 35, 260, 400), style: "box", text: Enum.GetName(typeof(ESPObject), SelectedObject));
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            switch (SelectedObject)
            {
                case ESPObject.Player:
                    SelectedOptions = Global.Settings.PlayerOptions;
                    DrawGlobals(Global.Settings.PlayerOptions, "Players");
                    Global.Settings.PlayerOptions.Visible = GUILayout.Toggle(Global.Settings.PlayerOptions.Visible, "Visible (Trace)");
                    DrawGlobals2(Global.Settings.PlayerOptions);
                    break;
                case ESPObject.Enemy:
                    SelectedOptions = Global.Settings.EnemyOptions;
                    DrawGlobals(Global.Settings.EnemyOptions, "Zombies");
                    Global.Settings.EnemyOptions.Bones = GUILayout.Toggle(Global.Settings.EnemyOptions.Bones, "Bones");
                    DrawGlobals2(Global.Settings.EnemyOptions);
                    break;
                case ESPObject.Item:
                    DrawGlobals(Global.Settings.ItemOptions, "Items");
                    SelectedOptions = Global.Settings.ItemOptions;
                    DrawGlobals2(Global.Settings.ItemOptions);
                    break;
                case ESPObject.Animal:
                    SelectedOptions = Global.Settings.AnimalOptions;
                    DrawGlobals(Global.Settings.AnimalOptions, "Animals");
                    DrawGlobals2(Global.Settings.AnimalOptions);
                    break;
                case ESPObject.NPC:
                    SelectedOptions = Global.Settings.NPCOptions;
                    DrawGlobals(Global.Settings.NPCOptions, "NPC");
                    DrawGlobals2(Global.Settings.NPCOptions);
                    break;
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        private static void DrawGlobals(ESPOptions options, string objname)
        {
            GUILayout.Space(2);
            options.Enabled = GUILayout.Toggle(options.Enabled, objname + " - Enabled");
            options.Box = GUILayout.Toggle(options.Box, "Box");
            // Couldn't make it work Yet
            //options.Glow = GUILayout.Toggle(options.Glow, "Glow");
            options.Tracers = GUILayout.Toggle(options.Tracers, "Snaplines");
            options.Name = GUILayout.Toggle(options.Name, "Name");
            options.Distance = GUILayout.Toggle(options.Distance, "Distance");
        }

        private static void DrawGlobals2(ESPOptions options)
        {
            if (GUILayout.Button("Cham Type: " + Enum.GetName(typeof(ShaderType), options.ChamType)))
                options.ChamType = options.ChamType.Next();
            GUILayout.Space(2);
            GUILayout.Label("Max Render Distance: " + options.MaxDistance);
            options.MaxDistance = (int)GUILayout.HorizontalSlider(options.MaxDistance, 0, 3000);
            GUILayout.Space(2);
            GUILayout.Label("Font Size: " + options.FontSize);
            options.FontSize = (int)GUILayout.HorizontalSlider(options.FontSize, 0, 24);
        }
    }
}
