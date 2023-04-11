using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipProject
{
    public class ComplexObject
    {
        private string name;
        [NonSerialized]
        private string nonData;
        private Vector2 vec;
        private List<ComplexObject> testList;

        private BaseClass inher;

        public string Name { get { return name; } set { name = value; } }
        public string NonData { get { return nonData; } set { nonData = value; } }
        public Vector2 Vec { get { return vec; } set { vec = value; } }
        public List<ComplexObject> TestList { get { return testList; } set { testList = value; } }

        public BaseClass Inher { get { return inher; } set { inher = value; } }
    }
}
