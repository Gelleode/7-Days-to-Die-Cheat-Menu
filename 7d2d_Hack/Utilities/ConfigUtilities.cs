using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Options;
using Newtonsoft.Json;
using UnityEngine.Profiling;
using UnityEngine;

namespace Game7D2D.Utilities
{
    internal class ConfigUtilities
    {
        public static string SelectedConfig = "default";
        private static string ConfigPath = Application.dataPath + "/EConfigs/";
        private static string GetConfigPath(string name = "default") { return ConfigPath + name + ".config"; }
        public static void CreateEnvironment()
        {
            if (!Directory.Exists(ConfigPath))
            {
                Directory.CreateDirectory(ConfigPath);
            }
            if (!File.Exists(GetConfigPath()))
                SaveConfig();
            else
                LoadConfig();
        }
        public static void SaveConfig(string name = "default", bool setconfig = false)
        {
            string path = GetConfigPath(name);
            string json = JsonConvert.SerializeObject(Global.Settings, Formatting.Indented);
            File.WriteAllText(path, json);
            if (setconfig)
                SelectedConfig = name;
            UnityEngine.Debug.Log($"Saved config {name}");
        }
        public static void LoadConfig(string name = "default")
        {
            string json = File.ReadAllText(GetConfigPath(name));
            Config s = JsonConvert.DeserializeObject<Config>(json);
            Global.Settings = s;
            SelectedConfig = name;
            UnityEngine.Debug.Log($"Loaded config {name}");
            Colors.AddColors();
        }
        public static List<string> GetConfigs(bool Extensions = false)
        {
            List<string> files = new List<string>();
            DirectoryInfo d = new DirectoryInfo(ConfigPath);
            FileInfo[] Files = d.GetFiles("*.config");
            foreach (FileInfo file in Files)
            {
                if (Extensions)
                    files.Add(file.Name.Substring(0, file.Name.Length));
                else
                    files.Add(file.Name.Substring(0, file.Name.Length - 7));
            }
            return files;
        }
    }
}
