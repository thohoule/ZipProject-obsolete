﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipProject
{
    public struct Vector2
    {
        private float x;
        private float y;

        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format("Vector2: {0}, {1}", x, y);
        }
    }
}
