using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipProject
{
    [Serializable]
    public class TestObject1
    {
        public string Name;
        public int Number;

        public TestObject1(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
