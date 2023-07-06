using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Attributes;
using Game7D2D.Class;
using Game7D2D.Utilities;
using UnityEngine;
using static AIDirectorPlayerInventory;
using UnityEngine.Profiling;

namespace Game7D2D.Cheats
{
    [Comp]
    public class ESP : MonoBehaviour
    {
        public static List<ESPObj> EObjects = new List<ESPObj>();
        private Vector2 scroll = new Vector2(0, 0);

        void OnGUI()
        {
            if (!Manager.IsLoaded)
                return;
            #region Item Clump Boxes
            //if (G.Settings.ItemOptions.Enabled && G.Settings.GlobalOptions.ListClumpedItems && !G.BeingSpied)
            //{
            //    for (int i = 0; i < ItemClumps.Count; i++)
            //    {
            //        ItemClumpObject itemClumpObject = ItemClumps[i];

            //        Vector3 pos = G.MainCamera.WorldToScreenPoint(itemClumpObject.WorldPos);
            //        pos.y = Screen.height - pos.y;
            //        if (pos.z >= 0 && (Vector3.Distance(Player.player.transform.position, itemClumpObject.WorldPos) <= G.Settings.ItemOptions.MaxDistance))
            //        {
            //            string s = "";
            //            foreach (InteractableItem item in itemClumpObject.ClumpedItems)
            //            {
            //                Color c1 = ItemTool.getRarityColorHighlight(item.asset.rarity);
            //                Color32 c = new Color32((byte)(c1.r * 255), (byte)(c1.g * 255), (byte)(c1.b * 255), 255);
            //                s += $"<color=#{Colors.ColorToHex(c)}>{item.asset.itemName}</color>\n";
            //            }
            //            Vector2 TextHeight = GUIStyle.none.CalcSize(new GUIContent($"<size=10>{s}</size>"));
            //            GUILayout.BeginArea(new Rect(pos.x, pos.y, TextHeight.x + 10, TextHeight.y), style: "box");
            //            GUILayout.Label($"<size=10>{s}</size>");
            //            GUILayout.EndArea();
            //        }
            //    }
            //}
            //GUI.skin = null;
            #endregion
            for (int i = 0; i < EObjects.Count; i++)
            {
                ESPObj obj = EObjects[i];
                #region Checks

                if (obj.GObject == null || !Tools.InScreenView(Global.MainCamera.WorldToViewportPoint(obj.GObject.transform.position)) || !obj.Options.Enabled || Tools.GetDistance(obj.GObject.transform.position) > obj.Options.MaxDistance)
                    continue;

                if (obj.Target == ESPObject.Player && !((EntityPlayer)obj.Object).IsAlive())
                    continue;
                if (obj.Target == ESPObject.Enemy && !((EntityEnemy)obj.Object).IsAlive())
                    continue;
                if (obj.Target == ESPObject.Animal && !((EntityAnimal)obj.Object).IsAlive())
                    continue;
                if (obj.Target == ESPObject.NPC)
                    continue;
                //if (obj.Target == ESPObject.Item && !T.IsItemWhitelisted((InteractableItem)obj.Object, G.Settings.MiscOptions.ESPWhitelist))
                //    continue;
                //if (obj.Target == ESPObject.Item && G.Settings.GlobalOptions.ListClumpedItems && Items.IsAlreadyClumped((InteractableItem)obj.Object))
                //    continue;

                #endregion

                #region Globals
                string LabelText = $"<size={obj.Options.FontSize}>";
                string OutlineText = $"<size={obj.Options.FontSize}>";
                Color32 color = Colors.GetColor(Enum.GetName(typeof(ESPObject), obj.Target) + "_ESP");
                if (obj.Options.Distance)
                {
                    LabelText += $"<color=white>[{Tools.GetDistance(obj.GObject.transform.position)}]</color> ";
                    OutlineText += $"[{Tools.GetDistance(obj.GObject.transform.position)}] ";
                }
                #endregion

                #region Label Shit
                switch (obj.Target)
                {
                    case ESPObject.Player:
                        EntityPlayer player = (EntityPlayer)obj.Object;
                        if (player.IsFriendOfLocalPlayer || player.IsInPartyOfLocalPlayer)
                            color = Colors.GetColor("Friendly_Player_ESP");
                        else
                            color = Colors.GetColor("Marked_Player_ESP");

                        if (obj.Options.Name)
                        {
                            LabelText += player.EntityName;
                            OutlineText += player.EntityName;
                        }
                        if (Global.Settings.PlayerOptions.Visible && Tools.VisibleFromCamera(player))
                        {
                            LabelText += $"<color=white> [V]</color>";
                            OutlineText += " [V]";
                        }
                        break;
                    //case ESPObject.Item:
                    //    if (obj.Options.Name)
                    //    {
                    //        LabelText += ((InteractableItem)obj.Object).asset.itemName;
                    //        OutlineText += ((InteractableItem)obj.Object).asset.itemName;
                    //    }
                    //    break;
                    case ESPObject.Enemy:
                        EntityEnemy enemy = (EntityEnemy)obj.Object;
                        if (obj.Options.Name)
                        {
                            LabelText += enemy.EntityName;
                            OutlineText += enemy.EntityName;
                        }
                        break;
                    default:
                        if (obj.Options.Name)
                        {
                            LabelText += Enum.GetName(typeof(ESPObject), obj.Target);
                            OutlineText += Enum.GetName(typeof(ESPObject), obj.Target);
                        }
                        break;
                }
                #endregion

                #region Draw
                LabelText += "</size>";
                OutlineText += "</size>";

                if (obj.Options.Tracers) Tools.DrawSnapline(obj.GObject.transform.position, color);
                if (!String.IsNullOrEmpty(LabelText))
                    Tools.DrawESPLabel(obj.GObject.transform.position, color, Color.black, LabelText, OutlineText);

                if (obj.Options.Bones)
                {
                    Tools.DrawBones((EntityEnemy)obj.Object);
                }

                if (obj.Options.Box)
                {

                    Vector3 p = obj.GObject.transform.position;
                    Vector3 s = obj.GObject.transform.localScale;
                    if (p != null & s != null)
                        Tools.Draw3DBox(new Bounds(p + new Vector3(0, 1.0f, 0), s + new Vector3(0, .5f, 0)), color);

                    //Whenever i tried to use GetComponent<Collider>() i got this :(
                    //NullReferenceException: Object reference not set to an instance of an object

                    //Tools.Draw3DBox(((EntityAlive)obj.Object).getBoundingBox(), color);

                }

                #endregion
            }
        }

        public static void ApplyChams(ESPObj gameObject, Color vis, Color invis)
        {
            switch (gameObject.Options.ChamType)
            {
                case ShaderType.Flat:
                    Tools.ApplyShader(AssetUtilities.Shaders["Chams"], gameObject.GObject, vis, invis);
                    break;
                case ShaderType.Material:
                    Tools.ApplyShader(AssetUtilities.Shaders["chamsLit"], gameObject.GObject, vis, invis);
                    break;
                default:
                    Tools.RemoveShaders(gameObject.GObject);
                    break;
            }
        }
    }
}
