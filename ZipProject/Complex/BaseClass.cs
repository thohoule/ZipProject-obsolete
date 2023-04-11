using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipProject
{
    public abstract class BaseClass
    {
        private bool isGreat;
        private float number;

        public bool IsGreat { get { return isGreat; } set { isGreat = value; } }
        public float Number { get { return number; } set { number = value; } }
    }
}
