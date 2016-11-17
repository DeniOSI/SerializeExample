using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SerializableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            JamesBondCar jbc = new JamesBondCar();
            JamesBondCar jbc_read = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = true;
            jbc.theRadio.stationPresets = new double[] { 5, 4, 3, 2 };
            SaveBinaryFormat(jbc, "Jbc.dat");

            OpenBinaryFormat(out jbc_read, "Jbc.dat");
            try 
	{	        
		
            Func<double[], string> print = (D) => 
                {
                    string str=default(string);
                    foreach(var value in D)
                    {
                    str += value + " ";
                    }
                    return str;
            } ;
            Console.WriteLine(jbc_read.canFly + "\n" + print(jbc_read.theRadio.stationPresets));
	}
	catch (Exception ex)
	{
		
		Console.WriteLine(ex.Message);
	}

            Console.ReadKey();
            

        }
        public static void SaveBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) 
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("Сохранение обЪекта в Binary format");
        }
        public static void OpenBinaryFormat(out JamesBondCar objectGraf, string name)
       {
            BinaryFormatter bf = new BinaryFormatter();
            using(Stream fs = File.OpenRead(name))
            {
                objectGraf = (JamesBondCar)bf.Deserialize(fs);           
            }
        }
    }
}
