using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipProject
{
    [Serializable]
    public class TestObject3
    {
        public int Age;
        public List<string> Names;

        public TestObject3()
        {

        }

        public TestObject3(int age, List<string> names)
        {
            Age = age;
            Names = names;
        }
    }
}
