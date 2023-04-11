using System;
using System.Collections.Generic;
using System.IO;
using MyZip;
using MyZip.Serializer;
using MyZip.Utility;

namespace ZipProject
{
    public static class SerializerTest
    {
        public static void Test()
        {
            //Save();
            Load();
        }

        public static void Save()
        {
            ComplexObject complex = new ComplexObject();
            complex.Name = "Jimmy";
            complex.NonData = "Bobyy";
            complex.Vec = new Vector2(2.4f, 5.7f);
            complex.Inher = new ChildClass()
            {
                ChildName = "reptar",
                Number = 996,
                IsGreat = true
            };
            complex.TestList = new List<ComplexObject>()
            {
                new ComplexObject()
                {
                    Name = "Steve",
                    Vec = new Vector2(666, 777)
                },

                new ComplexObject()
                {
                    Name = "Sally",
                    Vec = new Vector2(55.5f, 44.4f)
                }
            };

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "Cupcake.tyy"));

            using (MyZipArchive.Writer writer = new MyZipArchive.Writer(archive, true))
            {
                var data = DataSerializer.SerializeIntoData(complex);
                writer.WriteFileToArchive("Temp", MyByteConverter.ToByteArray(data));

                writer.Compress();
            }
        }

        public static void Load()
        {
            ComplexObject complex = new ComplexObject();

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "Cupcake.tyy"));

            PrimitiveData data;
            using (MyZipArchive.Reader reader = new MyZipArchive.Reader(archive))
            {
                byte[] rawData;
                reader.ReadInternalFile("Temp", out rawData);

                data = MyByteConverter.ToObject<PrimitiveData>(rawData);
            }

            DataSerializer.DeserializeFromData(ref complex, data);

            Console.WriteLine(complex.Name);
            Console.WriteLine("NonData: " + complex.NonData);
            Console.WriteLine(complex.Vec);

            Console.WriteLine(complex.Inher.IsGreat);
            Console.WriteLine(complex.Inher.Number);
            Console.WriteLine((complex.Inher as ChildClass).ChildName);

            foreach (var obj in complex.TestList)
            {
                Console.WriteLine(obj.Name);
                Console.WriteLine(obj.Vec);
            }

            Console.ReadKey();
        }
    }
}
