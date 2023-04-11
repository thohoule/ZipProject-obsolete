using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipProject
{
    public class ChildClass : BaseClass
    {
        private string childName;

        public string ChildName { get { return childName; } set { childName = value; } }
    }
}
