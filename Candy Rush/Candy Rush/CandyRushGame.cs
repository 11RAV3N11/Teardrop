using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Experia.Framework;

namespace CandyRush
{
    /// <summary>This is the main type for your game</summary>
    public class CandyRushGame: ExperiaCore
    {
        SpriteBatch spriteBatch;

        bool m_GameStarted = false;

        public CandyRushGame(): base(EngineFlags.Debug | EngineFlags.MultiCore)
        {
            ContentLoader.Instance.Initialize(this);
            base.Graphics = new Graphics(this, base.Content);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Graphics.EnableSprites();
            EntityManager.Instance.GetDrawableGameObjects.Add(new Zombie());
            Zombie temp = new Zombie();
            temp.Sprite.Texture = ContentLoader.Instance.Load<Texture2D>(Container.Game, @"Content\\Maru");
            temp.Sprite.Position = new Vector2(100f, 200f);
            EntityManager.Instance.GetDrawableGameObjects.Add(temp);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (m_GameStarted)
            {
                EntityManager.Instance.Update();
            }
            else
            {
                EntityManager.Instance.Initialize(Graphics);
                m_GameStarted = true;
            }
                // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            EntityManager.Instance.Draw(base.Graphics);
            base.Draw(gameTime);
        }
    }
}
