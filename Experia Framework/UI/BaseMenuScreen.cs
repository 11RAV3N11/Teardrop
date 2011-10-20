namespace Experia.Framework.UI
{
    public abstract class BaseMenuScreen
    {
        public bool Display;
        public BaseMenuScreen()
        {
            Display = true;
        }
        public abstract void Update();
        public abstract void Draw(GraphicsManager graphics);
    }
}
