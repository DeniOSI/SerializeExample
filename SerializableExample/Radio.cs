using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializableExample
{
    [Serializable]
    class Radio
    {
        public bool hasTwerts;
        public bool hasBuffers;
        public double[] stationPresets;
        [NonSerialized]
        public string radioID = "XF-552RF6";
    }
}
