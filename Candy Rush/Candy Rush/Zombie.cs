using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Experia.Framework;
using Experia.Framework.Entities;

namespace CandyRush
{
    class Zombie: BaseDrawableGameEntity2D
    {
        public Sprite Sprite = new Sprite();
        public override void Initialize(Graphics graphics)
        {
            if(Sprite.Texture == null)
            Sprite.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.Game, @"Content\\Zombie");
        }
        public override void Update()
        {
            if (this != EntityManager.Instance.GetDrawableGameObjects[0])
                Sprite.Color = Color.Red;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.SpriteBatch.Begin();
            Sprite.Draw(graphics.SpriteBatch, Sprite);
            graphics.SpriteBatch.End();
        }
    }
}
