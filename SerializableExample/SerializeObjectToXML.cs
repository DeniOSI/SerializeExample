using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace SerializableExample
{
    class SerializeObjectToXML
    {
        public void SaveToXML(object objGraf, string FileName)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(JamesBondCar), new Type[] { typeof(Radio), typeof(Car) });
            using (Stream fst = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            
            {
                xmls.Serialize(fst, objGraf);
            }
            Console.WriteLine("Object is serialize");

        }
        public void OpenFromXML(out object objGraf, string FileName)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(JamesBondCar), new Type[] { typeof(Radio), typeof(Car) });
            using (Stream fst = File.Open(FileName, FileMode.Open, FileAccess.Read))
            {
               objGraf =  xmls.Deserialize(fst);
            }
            Console.WriteLine("Object is desirialize");

        }
    }
}
