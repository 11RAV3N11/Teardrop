using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experia.Framework.Graphics
{
    public class Primitive2D
    {
        public static Primitive2D Instance { get { return Experia.Framework.Generics.Singleton<Primitive2D>.Instance; } }
        protected Primitive2D() { }

    }
}
