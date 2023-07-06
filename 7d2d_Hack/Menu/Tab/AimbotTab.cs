using Game7D2D.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Utilities;
using UnityEngine;

namespace Game7D2D.Menu.Tab
{
    public class AimbotTab : MonoBehaviour
    {
        public static void Tab()
        {
            GUILayout.Space(0);
            GUILayout.BeginArea(new Rect(10, 35, 260, 400), style: "box", text: "Aimlock");
            Global.Settings.AimbotOptions.Aimlock = GUILayout.Toggle(Global.Settings.AimbotOptions.Aimlock, "Aimlock");
            if (Global.Settings.AimbotOptions.Aimlock)
            {
                if (GUILayout.Button("Aimlock Key: " + Global.Settings.AimbotOptions.AimlockKey.ToString()))
                    Global.Settings.AimbotOptions.AimlockKey = KeyCode.None;
                    
                Global.Settings.AimbotOptions.HitPLayer = GUILayout.Toggle(Global.Settings.AimbotOptions.HitPLayer, "Players");
                Global.Settings.AimbotOptions.HitEnemy = GUILayout.Toggle(Global.Settings.AimbotOptions.HitEnemy, "Enemies");

                //G.Settings.AimbotOptions.OnlyVisible = GUILayout.Toggle(G.Settings.AimbotOptions.OnlyVisible, "Only Aim At Visible Targets");
                Global.Settings.AimbotOptions.AimlockLimitFOV = GUILayout.Toggle(Global.Settings.AimbotOptions.AimlockLimitFOV, "Pixel FOV Limit");
                if (Global.Settings.AimbotOptions.AimlockLimitFOV)
                {
                    GUILayout.Label("Pixels: " + Global.Settings.AimbotOptions.AimlockFOV);
                    Global.Settings.AimbotOptions.AimlockFOV = (int)GUILayout.HorizontalSlider(Global.Settings.AimbotOptions.AimlockFOV, 1, 1200);
                    Global.Settings.AimbotOptions.AimlockDrawFOV = GUILayout.Toggle(Global.Settings.AimbotOptions.AimlockDrawFOV, "Draw Pixel FOV Circle");
                }

            }
            GUILayout.EndArea();

            if (Global.Settings.AimbotOptions.AimlockKey == KeyCode.None)
            {
                Event e = Event.current;
                Global.Settings.AimbotOptions.AimlockKey = e.keyCode;
            }

            #region SilentAim which is not implemented at all xd
            //GUILayout.BeginArea(new Rect(280, 35, 260, 400), style: "box", text: "Silent Aimbot");
            //scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            //Global.Settings.AimbotOptions.SilentAim = GUILayout.Toggle(Global.Settings.AimbotOptions.SilentAim, "Silent Aim");
            
            //if (Global.Settings.AimbotOptions.SilentAim)
            //{
            //    //// here is where i was gonna add silent aim objects
            //    //GUILayout.Space(4);
            //    //foreach (ESPObject obj in Enum.GetValues(typeof(ESPObject)))
            //    //{
            //    //    bool included = G.Settings.AimbotOptions.SilentAimObjects.Contains(obj);
            //    //    bool checkbox = GUILayout.Toggle(included, "Target " + Enum.GetName(typeof(ESPObject), obj));

            //    //    if (included && !checkbox)
            //    //        G.Settings.AimbotOptions.SilentAimObjects.Remove(obj);
            //    //    else if (!included && checkbox)
            //    //        G.Settings.AimbotOptions.SilentAimObjects.Add(obj);
            //    //}
            //    //GUILayout.Space(4);

            //    //G.Settings.AimbotOptions.SilentAimInfo = GUILayout.Toggle(G.Settings.AimbotOptions.SilentAimInfo, "Show Vulnerable Targets");
            //    Global.Settings.AimbotOptions.ExpandHitboxes = GUILayout.Toggle(Global.Settings.AimbotOptions.ExpandHitboxes, "Expand Hitboxes");
            //    if (Global.Settings.AimbotOptions.ExpandHitboxes)
            //    {
            //        GUILayout.Label("Aimpoint Multiplier: " + Global.Settings.AimbotOptions.AimpointMultiplier);
            //        Global.Settings.AimbotOptions.AimpointMultiplier = (int)GUILayout.HorizontalSlider(Global.Settings.AimbotOptions.AimpointMultiplier, 1, 3);
            //        GUILayout.Space(2);

            //        GUILayout.Label("Hitbox Width: " + Global.Settings.AimbotOptions.HitboxSize + "m");
            //        Global.Settings.AimbotOptions.HitboxSize = (int)GUILayout.HorizontalSlider(Global.Settings.AimbotOptions.HitboxSize, 1, 15);
            //        GUILayout.Space(2);
            //    }

            //    GUILayout.Label("Chance To Hit: " + Global.Settings.AimbotOptions.HitChance + "%");
            //    Global.Settings.AimbotOptions.HitChance = (int)GUILayout.HorizontalSlider(Global.Settings.AimbotOptions.HitChance, 1, 100);
            //    GUILayout.Space(2);

            //    if (GUILayout.Button("Silent Aim Limb: " + Enum.GetName(typeof(TargetLimb), Global.Settings.AimbotOptions.TargetL)))
            //        Global.Settings.AimbotOptions.TargetL = Global.Settings.AimbotOptions.TargetL.Next();

            //    Global.Settings.AimbotOptions.SilentAimLimitFOV = GUILayout.Toggle(Global.Settings.AimbotOptions.SilentAimLimitFOV, "Pixel FOV Limit");
            //    if (Global.Settings.AimbotOptions.SilentAimLimitFOV)
            //    {
            //        GUILayout.Label("Pixels: " + Global.Settings.AimbotOptions.SilentAimFOV);
            //        Global.Settings.AimbotOptions.SilentAimFOV = (int)GUILayout.HorizontalSlider(Global.Settings.AimbotOptions.SilentAimFOV, 1, 1200);
            //        Global.Settings.AimbotOptions.SilentAimDrawFOV = GUILayout.Toggle(Global.Settings.AimbotOptions.SilentAimDrawFOV, "Draw Pixel FOV Circle");
            //    }
            //}
            //GUILayout.EndScrollView();
            //GUILayout.EndArea();
            #endregion 

        }
    }
}
