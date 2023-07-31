using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game7D2D.Overrides
{
    public class hkEntityPlayer : MonoBehaviour
    {
        public bool OV_IsDrawMapIcon()
        {
            Debug.Log("OV_IsDrawMapIcon");
            return true;
        }

    }
}
