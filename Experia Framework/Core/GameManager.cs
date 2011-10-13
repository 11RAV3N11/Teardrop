using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experia.Framework
{
    public class GameManager
    {
        public static GameManager Instance { get { return Experia.Framework.Generics.Singleton<GameManager>.Instance; } }
    }
}
