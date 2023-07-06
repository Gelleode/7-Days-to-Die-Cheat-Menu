using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Options;
using UnityEngine;

namespace Game7D2D.Class
{
    public class ESPObj
    {
        public ESPObject Target;
        public object Object;
        public GameObject GObject;
        public ESPOptions Options;

        public ESPObj(ESPObject t, object o, GameObject go, ESPOptions opt)
        {
            Target = t;
            Object = o;
            GObject = go;
            Options = opt;
        }
    }
}
