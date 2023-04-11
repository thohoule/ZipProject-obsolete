using System;
using System.Collections.Generic;
using MyZip.Serializer;
using MyZip.Utility;

namespace ZipProject
{
    public static class SerializerTest2
    {
        public static void Test()
        {
            var obj = new TestObject3(7, new List<string>() { "Hello", "Lemon" });

            var data = DataSerializer.SerializeIntoData(obj);

            var obj2 = DataSerializer.DeserializeFromData<TestObject3>(data);

            Console.WriteLine(string.Format("Age: {0}", obj2.Age));
            Console.WriteLine("List");

            foreach (var item in obj2.Names)
                Console.WriteLine(string.Format("-{0}", item));
        }

        public static void Test2()
        {
            var obj = new TestObject3(7, new List<string>() { "Hello", "Lemon" });

            if (obj.Names.GetType().IsSerializable)
                Console.WriteLine("Good");
            else
                Console.WriteLine("Bad");

            var data = MyByteConverter.ToByteArray(obj.Names);

            var list = MyByteConverter.ToObject<List<string>>(data);

            foreach (var item in list)
                Console.WriteLine(string.Format("-{0}", item));
        }
    }
}
