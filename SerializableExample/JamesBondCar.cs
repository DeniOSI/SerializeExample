using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializableExample
{
    [Serializable]
    class JamesBondCar: Car
    {
        public bool canFly;
        public bool canSubmerge;
    }
}
