using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experia.Framework.Interfaces
{
    public interface IGameObject
    {
        bool Enabled { get; set; }
        bool Disposed { get; }
    }
}
