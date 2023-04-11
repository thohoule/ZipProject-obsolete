using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipProject
{
    [Serializable]
    public class TestObject2
    {
        public string Name;
        public float Ducky;
        public string Address;

        public TestObject2(string name, float ducky, string address)
        {
            Name = name;
            Ducky = ducky;
            Address = address;
        }
    }
}
