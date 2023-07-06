﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Attributes;
using Game7D2D.Class;
using Game7D2D.Menu.Tab;
using Game7D2D.Utilities;
using UnityEngine;
using UnityEngine.UI;
using Game7D2D.Menu.Window;

namespace Game7D2D.Menu
{
    [Comp]
    public class Main : MonoBehaviour
    {
        public static MenuTab SelectedTab = MenuTab.Visuals;
        public static bool MenuOpen = false;

        public static Color GUIColor;
        private List<GUIContent> buttons = new List<GUIContent>();
        public static List<GUIContent> buttons2 = new List<GUIContent>();
        public static List<GUIContent> buttons3 = new List<GUIContent>();
        public static List<GUIContent> buttons4 = new List<GUIContent>();
        public static List<GUIContent> buttons5 = new List<GUIContent>();
        public static List<GUIContent> buttons6 = new List<GUIContent>();
        public static Rect CursorPos = new Rect(0, 0, 20f, 20f);


        private int i = -40;
        private Texture _cursorTexture;
        private Rect windowRect = new Rect(80, 80, 550, 450);
        private Rect itemRect = new Rect(400, 465, 200, 250);
        private Rect guiRect = new Rect(100, 755, 200, 250);


        readonly string Name = "GayCheat";
        readonly string Version = "v6.6.6";


        void Start()
        {
            Debug.Log("Main Started");
            GUIColor = GUI.color;
            foreach (MenuTab val in Enum.GetValues(typeof(MenuTab)))
                buttons.Add(new GUIContent(Enum.GetName(typeof(MenuTab), val)));
            foreach (ESPObject val in Enum.GetValues(typeof(ESPObject)))
                buttons2.Add(new GUIContent(Enum.GetName(typeof(ESPObject), val)));
            foreach (MiscOptions val in Enum.GetValues(typeof(MiscOptions)))
                buttons3.Add(new GUIContent(Enum.GetName(typeof(MiscOptions), val).Replace("_", " ")));
            foreach (SettingsOptions val in Enum.GetValues(typeof(SettingsOptions)))
                buttons4.Add(new GUIContent(Enum.GetName(typeof(SettingsOptions), val)));
            foreach (AimbotOptions val in Enum.GetValues(typeof(AimbotOptions)))
                buttons5.Add(new GUIContent(Enum.GetName(typeof(AimbotOptions), val)));
            foreach (PerkObject val in Enum.GetValues(typeof(PerkObject)))
                buttons6.Add(new GUIContent(Enum.GetName(typeof(PerkObject), val).Replace("_", " ")));
            Debug.Log("Main Start End");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                Debug.Log("Insert pressed");
                if (MenuOpen == false)
                    MenuOpen = true;
                else
                {
                    MenuOpen = false;
                    i = -40;
                }
            }
        }

        void OnGUI()
        {
            if (MenuOpen)
            {
                GUI.skin = AssetUtilities.Skin;

                //if (_cursorTexture == null)
                //    _cursorTexture = Resources.Load("i'm too stupid to find this on my own") as Texture;

                GUI.depth = -1;


                GUIStyle guiStyle = new GUIStyle("label");
                guiStyle.margin = new RectOffset(10, 10, 5, 5);
                guiStyle.fontSize = 22;
                if (i < 0)
                    i++;
                windowRect = GUILayout.Window(0, windowRect, MenuWindow, Enum.GetName(typeof(MenuTab), SelectedTab));
                if (Window.GUIWindow.GUISkinMenuOpen)
                    guiRect = GUILayout.Window(5, guiRect, Window.GUIWindow.Window, "GUI Skins");

                GUILayout.BeginArea(new Rect(0, i, Screen.width, 40), style: "NavBox");
                GUILayout.BeginHorizontal();
                GUI.color = new Color32(34, 177, 76, 255);
                GUILayout.Label($"<b>{Name}</b> <size=15>{Version}</size>", guiStyle);
                GUI.color = GUIColor;
                SelectedTab = (MenuTab)GUILayout.Toolbar((int)SelectedTab, buttons.ToArray(), style: "TabBtn");
                GUILayout.EndHorizontal();
                GUILayout.EndArea();

                GUI.depth = -2;
                CursorPos.x = Input.mousePosition.x;
                CursorPos.y = Screen.height - Input.mousePosition.y;

                //GUI.DrawTexture(CursorPos, _cursorTexture);
                //Cursor.lockState = CursorLockMode.None;

                GUI.skin = null;
            }
        }

        void MenuWindow(int windowID)
        {
            #region Display Selected Tab
            switch (SelectedTab)
            {
                case MenuTab.Visuals:
                    VisualsTab.Tab();
                    break;
                case MenuTab.Aimbot:
                    AimbotTab.Tab();
                    break;
                case MenuTab.Misc:
                    MiscTab.Tab();
                    break;
                case MenuTab.Perks:
                    PerksTab.Tab();
                    break;
                case MenuTab.Settings:
                    SettingsTab.Tab();
                    break;
            }
            #endregion
            GUI.DragWindow();
        }

    }
}
