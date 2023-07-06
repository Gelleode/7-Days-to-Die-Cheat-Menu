using Game7D2D.Class;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game7D2D.Cheats;
using UnityEngine;

namespace Game7D2D.Utilities
{
    class Manager : MonoBehaviour
    {
        //Entities
        public static LocalPlayer localP;
        public static EntityPlayerLocal eLocalPlayer;
        
        public static bool IsLoaded
        {
            get => _isLoaded;
            set
            {
                _isLoaded = value;
                if (value)
                {
                    localP = FindObjectOfType<LocalPlayer>();
                    eLocalPlayer = FindObjectOfType<EntityPlayerLocal>();
                };
            }
        }

        private static bool _isLoaded;

        public void Start()
        {
            #region Create ESP Line Material
            Tools.DrawMaterial = new Material(Shader.Find("Hidden/Internal-Colored"))
            {
                hideFlags = (HideFlags)61
            };
            Tools.DrawMaterial.SetInt("_SrcBlend", 5);
            Tools.DrawMaterial.SetInt("_DstBlend", 10);
            Tools.DrawMaterial.SetInt("_Cull", 0);
            Tools.DrawMaterial.SetInt("_ZWrite", 0);
            #endregion
            Debug.Log("Manager Started");
            AttributeUtilities.LinkAttributes();
            Debug.Log("Adding Attributes");
            ConfigUtilities.CreateEnvironment();
            Debug.Log("Getting Config");
            AssetUtilities.GetAssets();
            Debug.Log("Getting Assets");
            Colors.AddColors();
            Debug.Log("Start Coroutine");
            StartCoroutine(UpdateESPObjects());
            Debug.Log("Manager End");
        }

        void OnGUI()
        {
            #region Set Camera Once
            if (Global.MainCamera == null)
                Global.MainCamera = Camera.main;
            #endregion
        }

        #region Updates ESP Objects
        IEnumerator UpdateESPObjects()
        {
            // every 4 seconds refresh all world objects. DO NOT do this each frame
            while (true)
            {
                Debug.Log("Coroutine check");
                IsLoaded = GameManager.Instance.gameStateManager.IsGameStarted();
                if (IsLoaded)
                {

                    List<ESPObj> TempObjects = new List<ESPObj>();

                    #region Items
                    if (Global.Settings.ItemOptions.Enabled)
                    {
                        foreach (EntityItem i in FindObjectsOfType<EntityItem>())
                        {
                            ESPObj obj = new ESPObj(ESPObject.Item, i, i.gameObject, Global.Settings.ItemOptions);
                            TempObjects.Add(obj);
                            ESP.ApplyChams(obj, Colors.GetColor("Item_Chams_Visible_Color"), Colors.GetColor("Item_Chams_Occluded_Color"));
                        }
                        //foreach (EntitySupplyCrate i in FindObjectsOfType<EntitySupplyCrate>())
                        //{
                        //    ESPObj obj = new ESPObj(ESPObject.Item, i, i.gameObject, Global.Settings.ItemOptions);
                        //    TempObjects.Add(obj);
                        //    ESP.ApplyChams(obj, Colors.GetColor("Item_Chams_Visible_Color"), Colors.GetColor("Item_Chams_Occluded_Color"));
                        //}
                    }
                    #endregion
                    #region Enemies
                    if (Global.Settings.EnemyOptions.Enabled || (Global.Settings.AimbotOptions.Aimlock && Global.Settings.AimbotOptions.HitEnemy))
                    {
                        foreach (EntityEnemy i in FindObjectsOfType<EntityEnemy>().Where(s => s.IsAlive()))
                        {
                            ESPObj obj = new ESPObj(ESPObject.Enemy, i, i.gameObject, Global.Settings.EnemyOptions);
                            TempObjects.Add(obj);
                            if (Global.Settings.EnemyOptions.Enabled)
                                ESP.ApplyChams(obj, Colors.GetColor("Enemy_Chams_Visible_Color"), Colors.GetColor("Enemy_Chams_Occluded_Color"));
                        }
                    }
                    #endregion
                    #region Players
                    if (Global.Settings.PlayerOptions.Enabled || (Global.Settings.AimbotOptions.Aimlock && Global.Settings.AimbotOptions.HitPLayer))
                    {
                        foreach (EntityPlayer i in FindObjectsOfType<EntityPlayer>())
                        {
                            if (eLocalPlayer.EntityName == i.EntityName)
                                continue;
                            ESPObj obj = new ESPObj(ESPObject.Player, i, i.gameObject, Global.Settings.PlayerOptions);
                            TempObjects.Add(obj);
                            if (Global.Settings.PlayerOptions.Enabled)
                                ESP.ApplyChams(obj, Colors.GetColor("Player_Chams_Visible_Color"), Colors.GetColor("Player_Chams_Occluded_Color"));
                        }
                    }
                    #endregion
                    #region Animals
                    if (Global.Settings.AnimalOptions.Enabled)
                    {
                        foreach (EntityAnimal i in FindObjectsOfType<EntityAnimal>())
                        {
                            ESPObj obj = new ESPObj(ESPObject.Animal, i, i.gameObject, Global.Settings.AnimalOptions);
                            TempObjects.Add(obj);
                            if (Global.Settings.AnimalOptions.Enabled)
                                ESP.ApplyChams(obj, Colors.GetColor("Animal_Chams_Visible_Color"), Colors.GetColor("Animal_Chams_Occluded_Color"));
                        }
                    }
                    #endregion
                    #region NPC
                    if (Global.Settings.NPCOptions.Enabled)
                    {
                        foreach (EntityNPC i in FindObjectsOfType<EntityNPC>())
                        {
                            ESPObj obj = new ESPObj(ESPObject.NPC, i, i.gameObject, Global.Settings.AnimalOptions);
                            TempObjects.Add(obj);
                            ESP.ApplyChams(obj, Colors.GetColor("NPC_Chams_Visible_Color"), Colors.GetColor("NPC_Chams_Occluded_Color"));
                        }
                    }
                    #endregion
                    ESP.EObjects = TempObjects;

                }
                yield return new WaitForSeconds(4f);
            }
        }
        #endregion
    }
}
