using Game7D2D.Class;
using Game7D2D.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Game7D2D.Utilities;

namespace Game7D2D.Menu.Tab
{
    public class PerksTab : MonoBehaviour
    {
        public static PerkObject SelectedObject = PerkObject.Perception;
        private static Vector2 scrollPosition;
        public static ESPOptions SelectedOptions = Global.Settings.PlayerOptions;
        private static bool IsInit = false;
        public static void Tab()
        {
            if (!IsInit && !Manager.IsLoaded)
                return;
            if (Manager.IsLoaded && !IsInit)
            {
                IsInit = true;
                SkillsUtilities.InitSkills();
            }

            //GETS SKILL POINTS
            //Manager.localP.entityPlayerLocal.Progression.SkillPoints};

            GUILayout.Space(0);
            GUILayout.BeginArea(new Rect(10, 35, 260, 400), style: "box", text: "Perk Selection");
            SelectedObject = (PerkObject)GUILayout.SelectionGrid((int)SelectedObject, Main.buttons6.ToArray(), 1);
            if (GUILayout.Button("Add spell point"))
            {
                Manager.localP.entityPlayerLocal.Progression.SkillPoints++;
            }
            if (GUILayout.Button("Remove spell point"))
            {
                Manager.localP.entityPlayerLocal.Progression.SkillPoints--;
            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(280, 35, 260, 400), style: "box", text: Enum.GetName(typeof(PerkObject), SelectedObject)?.Replace("_", " "));
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            switch (SelectedObject)
            {
                case PerkObject.Perception:
                    SkillsUtilities.GetAttributeSkills(AllSkills.Perception);
                    DrawAttribute(AllSkills.Perception);
                    break;
                case PerkObject.Agility:
                    SkillsUtilities.GetAttributeSkills(AllSkills.Agility);
                    DrawAttribute(AllSkills.Agility);
                    break;
                case PerkObject.Strength:
                    SkillsUtilities.GetAttributeSkills(AllSkills.Strength);
                    DrawAttribute(AllSkills.Strength);
                    break;
                case PerkObject.Fortitude:
                    SkillsUtilities.GetAttributeSkills(AllSkills.Fortitude);
                    DrawAttribute(AllSkills.Fortitude);
                    break;
                case PerkObject.Intellect:
                    SkillsUtilities.GetAttributeSkills(AllSkills.Intellect);
                    DrawAttribute(AllSkills.Intellect);
                    break;
                case PerkObject.Crafting_Skills:
                    SkillsUtilities.GetAttributeSkills(AllSkills.CraftingBooks);
                    DrawAttribute(AllSkills.CraftingBooks);
                    break;
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        private static void DrawAttribute(List<Perks> attribute)
        {
            foreach (var perk in attribute)
            {
                GUILayout.Label($"{perk.Name} - {perk.CurLevel}");
                var newY = GUILayoutUtility.GetLastRect().y;
                var lastWidth = GUILayoutUtility.GetLastRect().width;
                var lastHeight = GUILayoutUtility.GetLastRect().height;
                perk.SelectedLevel = int.Parse(GUI.TextField(new Rect(lastWidth / 2 + 50, newY - 5, 50, lastHeight),
                    perk.SelectedLevel.ToString(), 3));
            }

            if (GUILayout.Button("Apply perks"))
            {
                foreach (var perk in attribute)
                {
                    if (perk.SelectedLevel <= 0)
                        perk.SelectedLevel = 1;
                    else if (perk.SelectedLevel > perk.MaxLevel)
                        perk.SelectedLevel = perk.MaxLevel;
                    SkillsUtilities.SetSkillLevel(perk.GameName, perk.SelectedLevel);
                }
            }
        }

        private static void DrawFGlobals(PerkObject perkObject)
        {
            GUILayout.Space(2);
            GUILayout.Label(Enum.GetName(typeof(PerkObject), SelectedObject));
        }
    }
}
