namespace Experia.Framework.UI
{
    public abstract class BaseMenuScreen
    {
        public bool Active;
        public readonly string KeyString;
        public BaseMenuScreen(string KeyString)
        {
            this.KeyString = KeyString;
        }
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Draw();
    }
}
