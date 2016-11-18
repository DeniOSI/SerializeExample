using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializableExample
{
    [Serializable]//Опция серилизации объектов
   public class JamesBondCar: Car
    {
        public bool canFly;
        public bool canSubmerge;
        public void JBCInfo()
        {
            Console.WriteLine(canFly + " " + canSubmerge + " ");
        }
    }
}
