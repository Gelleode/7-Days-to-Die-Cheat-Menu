using Game7D2D.Utilities;
using UnityEngine;

namespace Game7D2D
{
    public class Load
    {
        public static GameObject Heck;
        public static void Start()
        {
            Heck = new GameObject();
            Object.DontDestroyOnLoad(Heck);
            Heck.AddComponent<Manager>();
        }

        public static void Unload()
        {
            _unload();
        }

        private static void _unload()
        {
            Object.Destroy(Heck);
        }
    }
}
