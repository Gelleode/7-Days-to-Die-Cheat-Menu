﻿using Game7D2D.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game7D2D.Menu.Window
{
    public class GUIWindow
    {
        private static Vector2 scrollPosition3 = new Vector2(0, 0);
        public static bool GUISkinMenuOpen = false;

        public static void Window(int windowID)
        {
            scrollPosition3 = GUILayout.BeginScrollView(scrollPosition3, style: "SelectedButtonDropdown");
            if (AssetUtilities.GetSkins().Count == 0)
                GUILayout.Label("put gui skins in *GameFolder*/7DaysToDie_Data/GUISkins/");
            foreach (string skin in AssetUtilities.GetSkins())
            {
                string s = skin;
                if (s == Global.Settings.MiscOptions.UISkin)
                    s = $"<b>{s}</b>";
                if (GUILayout.Button(s))
                    AssetUtilities.LoadGUISkinFromName(skin);
            }

            GUILayout.EndScrollView();
            GUILayout.Space(2);
            if (GUILayout.Button("Load Default GUI"))
            {
                Global.Settings.MiscOptions.UISkin = "";
                AssetUtilities.Skin = AssetUtilities.VanillaSkin;
            }

            if (GUILayout.Button("Close Window"))
                GUISkinMenuOpen = !GUISkinMenuOpen;
            GUI.DragWindow();
        }
    }
}
