using Game7D2D.Attributes;
using System;
using System.Reflection;
using UnityEngine;

namespace Game7D2D.Utilities
{
    public static class AttributeUtilities
    {
        public static void LinkAttributes()
        {
            foreach (Type T in Assembly.GetExecutingAssembly().GetTypes())
            {
                // Collect and add components marked with the attribute
                if (T.IsDefined(typeof(Comp), false))
                    Load.Heck.AddComponent(T);
            }
        }
    }
}
