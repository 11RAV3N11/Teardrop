using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework
{
    public class ExperiaHelper
    {
        protected ExperiaHelper() { }
        public static ExperiaHelper Instance { get { return Experia.Framework.Generics.Singleton<ExperiaHelper>.Instance; } }
        public Vector2 PositionByResolution(Vector2 PercentPosition)
        {
            PercentPosition.X = MathHelper.Clamp(PercentPosition.X, 0f, 100f);
            PercentPosition.Y = MathHelper.Clamp(PercentPosition.Y, 0f, 100f);

            Vector2 resolution = GraphicsManager.Instance.SpriteResolution;

            Vector2 targetPosition = new Vector2();
            targetPosition.X = (PercentPosition.X / 100f) * resolution.X;
            targetPosition.Y = (PercentPosition.Y / 100f) * resolution.Y;

            return targetPosition;
        }

        public Guid HardwareGuidGen(GraphicsDevice graphics)
        {
            int a = graphics.Adapter.DeviceId.GetHashCode();
            int b = Environment.ProcessorCount.GetHashCode();
            int c = Environment.OSVersion.GetHashCode();
            int d = a + b + c;
            return new Guid(a, (short)b, (short)c, (byte)d, (byte)a, (byte)b, (byte)c, (byte)(a + a), (byte)(b + b), (byte)(c + c), (byte)(d + d));;
        }
    }
}
