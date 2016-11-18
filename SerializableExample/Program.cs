using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary; //ОБЯЗАТЕЛЬНО
using System.IO;
using System.Xml.Serialization;
namespace SerializableExample
{
    class Program
    {
        static void Main(string[] args)
        {

            #region BinarySearilize
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = true;
            jbc.theRadio.stationPresets = new double[] { 5, 4, 3, 2 };
            SaveBinaryFormat(jbc, "Jbc.dat"); //метод выполняющий бинарную серилизацию 
            #endregion

            #region BinaryDesirialize
            JamesBondCar jbc_read = new JamesBondCar();
            OpenBinaryFormat(out jbc_read, "Jbc.dat");//метод реализации десерилизацию бинарную
            try
            {

                Func<double[], string> print = (D) => //лямбда выполняющая преобразование массива в строку
                    {
                        string str = default(string);
                        foreach (var value in D)
                        {
                            str += value + " ";
                        }
                        return str;
                    };
                Console.WriteLine(jbc_read.canFly + "\n" + print(jbc_read.theRadio.stationPresets));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            #endregion

            #region XMLSerialize

            SerializeObjectToXML sotx = new SerializeObjectToXML();
            sotx.SaveToXML(jbc, "option.xml");  
            #endregion

            JamesBondCar jbcxml = new JamesBondCar();
            object objxml;
            sotx.OpenFromXML(out objxml , "option.xml");
            jbcxml = (JamesBondCar)objxml;
            jbcxml.JBCInfo();
            Console.ReadKey();
            

        }
        public static void SaveBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter(); //экземпляр бинарного серилизатора
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) //файл.поток для записи серилизации
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
