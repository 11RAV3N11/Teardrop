using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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

            Vector2 resolution = new Vector2(GraphicsManager.Instance.Device.Viewport.Width, GraphicsManager.Instance.Device.Viewport.Height);

            Vector2 targetPosition = new Vector2();
            targetPosition.X = (PercentPosition.X / 100f) * resolution.X;
            targetPosition.Y = (PercentPosition.Y / 100f) * resolution.Y;

            return targetPosition;
        }
    }
}
