using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game7D2D.Utilities
{
    public class AssetUtilities
    {
        public static Dictionary<string, Shader> Shaders = new Dictionary<string, Shader>();
        public static GUISkin Skin;
        public static GUISkin VanillaSkin;
        public static AudioClip BonkClip;

        public static void GetAssets()
        {
            Debug.Log("Getting Assets");
            if (!Directory.Exists(Application.dataPath + "/GUISkins/"))
            {
                Debug.Log("Directory doesn't exist");
                Directory.CreateDirectory(Application.dataPath + "/GUISkins/");
                Debug.Log("Create dir");
            }

            // will use assets from 7DaysToDie/7DaysToDie_Data/Cheeky.assets
            AssetBundle Bundle = AssetBundle.LoadFromMemory(File.ReadAllBytes(Application.dataPath + "/Cheeky.assets"));

            foreach (Shader s in Bundle.LoadAllAssets<Shader>())
                Shaders.Add(s.name, s);

            BonkClip = Bundle.LoadAllAssets<AudioClip>().First();
            VanillaSkin = Bundle.LoadAllAssets<GUISkin>().First();
            foreach (var s in VanillaSkin.customStyles)
            {
                Debug.Log($"{s.name} GUIStyle");
            }
            if (!String.IsNullOrEmpty(Global.Settings.MiscOptions.UISkin))
                LoadGUISkinFromName(Global.Settings.MiscOptions.UISkin);
            else
                Skin = VanillaSkin;
        }

        public static void LoadGUISkinFromName(string name)
        {
            // will use assets from 7DaysToDie/7DaysToDie_Data/GUISkins/(name).assets
            if (File.Exists(Application.dataPath + "/GUISkins/" + name + ".assets"))
            {
                AssetBundle tempAsset = AssetBundle.LoadFromMemory(File.ReadAllBytes(Application.dataPath + "/GUISkins/" + name + ".assets"));
                Skin = tempAsset.LoadAllAssets<GUISkin>().First();
                tempAsset.Unload(false);
                Global.Settings.MiscOptions.UISkin = name;
            }
            else
            {
                Skin = VanillaSkin;
                Global.Settings.MiscOptions.UISkin = "";
            }
        }
        public static List<string> GetSkins(bool Extensions = false)
        {
            //just kinda reads from the guiskins folder
            List<string> files = new List<string>();
            DirectoryInfo d = new DirectoryInfo(Application.dataPath + "/GUISkins/");
            FileInfo[] Files = d.GetFiles("*.assets");
            foreach (FileInfo file in Files)
            {
                if (Extensions)
                    files.Add(file.Name.Substring(0, file.Name.Length));
                else
                    files.Add(file.Name.Substring(0, file.Name.Length - 7)); // - 7 removes .assets
            }
            return files;
        }
    }
}
