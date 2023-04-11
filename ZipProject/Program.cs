using System;
using System.Collections.Generic;
using System.IO;
using MyZip;
using MyZip.Utility;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Security.Cryptography;

namespace ZipProject
{
    class Program
    {
        private const string KEY = "Unlock the bay doors";

        static void Main(string[] args)
        {
            //SaveTest();
            //AppendTest();
            //UpdateTest();
            //UpdateAndAppendTest();
            //CompressSave();
            //EncryptionSave();
            //EncryptionUpdateAndAppendTest();

            //LoadTest();
            //LoadTest2();
            //CompressLoad();
            //EncryptedLoad();
            //EncryptedLoad2();

            //SerializerTest.Test();
            //SerializerTest2.Test();
            SerializerTest2.Test2();

            Console.ReadKey();
        }

        #region Normal
        static void SaveTest()
        {
            TestObject1 obj1 = new TestObject1("Nill", 20);
            TestObject2 obj2 = new TestObject2("Bob", 5.67f, "Main");

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            using (MyZipArchive.Writer writer = new MyZipArchive.Writer(archive, true))
            {
                writer.WriteFileToArchive("Sally", MyByteConverter.ToByteArray(obj1));
                writer.WriteFileToArchive("Bertha", MyByteConverter.ToByteArray(obj2));

                writer.Compress();
            }
        }

        public static void AppendTest()
        {
            TestObject1 obj3 = new TestObject1("John", 105);

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            using (MyZipArchive.Writer writer = new MyZipArchive.Writer(archive, false))
            {
                writer.WriteFileToArchive("Molly", MyByteConverter.ToByteArray(obj3));

                writer.Compress();
            }
        }

        public static void UpdateTest()
        {
            TestObject1 obj1 = new TestObject1("Ron", 99);

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            using (MyZipArchive.Writer writer = new MyZipArchive.Writer(archive, false))
            {
                writer.Edit("Sally", MyByteConverter.ToByteArray(obj1));

                writer.Compress();
            }
        }

        public static void UpdateAndAppendTest()
        {
            TestObject1 obj1 = new TestObject1("Ron", 99);
            TestObject1 obj3 = new TestObject1("John", 105);

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            using (MyZipArchive.Writer writer = new MyZipArchive.Writer(archive, false))
            {
                writer.Edit("Sally", MyByteConverter.ToByteArray(obj1));

                writer.WriteFileToArchive("Molly", MyByteConverter.ToByteArray(obj3));

                writer.Compress();
            }
        }
        #endregion

        #region Compress
        public static void CompressSave()
        {
            TestObject1 obj1 = new TestObject1("Nill", 20);
            TestObject2 obj2 = new TestObject2("Bob", 5.67f, "Main");

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            using (MyZipArchive.CompressionWriter writer = new MyZipArchive.CompressionWriter(archive, true))
            {
                writer.WriteFileToArchive("Sally", MyByteConverter.ToByteArray(obj1));
                writer.WriteFileToArchive("Bertha", MyByteConverter.ToByteArray(obj2));

                writer.Compress();
            }
        }
        #endregion

        #region Encryption
        public static void EncryptionSave()
        {
            TestObject1 obj1 = new TestObject1("Nill", 20);
            TestObject2 obj2 = new TestObject2("Bob", 5.67f, "Main");

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            using (MyZipArchive.EncryptionWriter writer = new MyZipArchive.EncryptionWriter(archive, true, KEY))
            {
                writer.WriteFileToArchive("Sally", MyByteConverter.ToByteArray(obj1));
                writer.WriteFileToArchive("Bertha", MyByteConverter.ToByteArray(obj2));

                writer.Compress();
            }
        }

        public static void EncryptionUpdateAndAppendTest()
        {
            TestObject1 obj1 = new TestObject1("Ron", 99);
            TestObject1 obj3 = new TestObject1("John", 105);

            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            using (MyZipArchive.EncryptionWriter writer = new MyZipArchive.EncryptionWriter(archive, false, KEY))
            {
                writer.Edit("Sally", MyByteConverter.ToByteArray(obj1));

                writer.WriteFileToArchive("Molly", MyByteConverter.ToByteArray(obj3));

                writer.Compress();
            }
        }
        #endregion

        #region Normal Load
        static void LoadTest()
        {
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            byte[] data;

            using (var reader = new MyZipArchive.Reader(archive))
            {
                if (reader.ReadInternalFile("Sally", out data))
                {
                    TestObject1 testRead = MyByteConverter.ToObject<TestObject1>(data);
                    Console.WriteLine(testRead.Name);
                }

                if (reader.ReadInternalFile("Bertha", out data))
                {
                    TestObject2 testRead = MyByteConverter.ToObject<TestObject2>(data);
                    Console.WriteLine(testRead.Name);
                }
            }

            Console.ReadKey();
        }

        static void LoadTest2()
        {
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            byte[] data;

            using (var reader = new MyZipArchive.Reader(archive))
            {
                if (reader.ReadInternalFile("Sally", out data))
                {
                    TestObject1 testRead = MyByteConverter.ToObject<TestObject1>(data);
                    Console.WriteLine(testRead.Name);
                }

                if (reader.ReadInternalFile("Bertha", out data))
                {
                    TestObject2 testRead = MyByteConverter.ToObject<TestObject2>(data);
                    Console.WriteLine(testRead.Name);
                }

                if (reader.ReadInternalFile("Molly", out data))
                {
                    TestObject1 testRead = MyByteConverter.ToObject<TestObject1>(data);
                    Console.WriteLine(testRead.Name);
                }
            }

            Console.ReadKey();
        }
        #endregion

        #region Compress Load
        static void CompressLoad()
        {
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            byte[] data;

            using (var reader = new MyZipArchive.CompressionReader(archive))
            {
                if (reader.ReadInternalFile("Sally", out data))
                {
                    TestObject1 testRead = MyByteConverter.ToObject<TestObject1>(data);
                    Console.WriteLine(testRead.Name);
                }

                if (reader.ReadInternalFile("Bertha", out data))
                {
                    TestObject2 testRead = MyByteConverter.ToObject<TestObject2>(data);
                    Console.WriteLine(testRead.Name);
                }
            }

            Console.ReadKey();
        }
        #endregion

        #region Encryption load
        static void EncryptedLoad()
        {
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));
            
            byte[] data;

            using (var reader = new MyZipArchive.EncryptionReader(archive, KEY))
            {
                if (reader.ReadInternalFile("Sally", out data))
                {
                    TestObject1 testRead = MyByteConverter.ToObject<TestObject1>(data);
                    Console.WriteLine(testRead.Name);
                }

                if (reader.ReadInternalFile("Bertha", out data))
                {
                    TestObject2 testRead = MyByteConverter.ToObject<TestObject2>(data);
                    Console.WriteLine(testRead.Name);
                }
            }

            Console.ReadKey();
        }

        static void EncryptedLoad2()
        {
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            MyZipArchive archive = new MyZipArchive(path, Path.Combine(path, "ElephantFart.txt"));

            byte[] data;

            using (var reader = new MyZipArchive.EncryptionReader(archive, KEY))
            {
                if (reader.ReadInternalFile("Sally", out data))
                {
                    TestObject1 testRead = MyByteConverter.ToObject<TestObject1>(data);
                    Console.WriteLine(testRead.Name);
                }

                if (reader.ReadInternalFile("Bertha", out data))
                {
                    TestObject2 testRead = MyByteConverter.ToObject<TestObject2>(data);
                    Console.WriteLine(testRead.Name);
                }

                if (reader.ReadInternalFile("Molly", out data))
                {
                    TestObject1 testRead = MyByteConverter.ToObject<TestObject1>(data);
                    Console.WriteLine(testRead.Name);
                }
            }

            Console.ReadKey();
        }
        #endregion
    }
}
