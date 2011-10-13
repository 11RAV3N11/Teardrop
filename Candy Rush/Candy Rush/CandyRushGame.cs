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
using Experia.Framework.Audio;

namespace CandyRush
{
    /// <summary>This is the main type for your game</summary>
    public class CandyRushGame: EngineCore
    {
        SpriteBatch spriteBatch;
        Font2D m_TestFont;

        //AudioEffect gunshot;
        AudioPlayer skrillex;

        bool m_GameStarted = false;

        public CandyRushGame(): base(EngineFlags.Debug | EngineFlags.MultiCore)
        {
            ContentLoader.Instance.Initialize(this);
            GraphicsManager.Instance.Initialize(this);
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
            GraphicsManager.Instance.EnableSprites();
            EntityManager.Instance.AddGameEntity(new Zombie());
            Zombie temp = new Zombie();
            temp.Sprite.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.Game, @"Content\\Maru");
            temp.Sprite.Position = new Vector2(100f, 200f);
            EntityManager.Instance.AddGameEntity(temp);
            m_TestFont = new Font2D(@"Content\\Chiller");
            m_TestFont.Color = Color.Orange;

             //TODO: Add your initialization logic here

            //gunshot = new AudioEffect();
            //gunshot.LoadAudioEffect(@"content\\gunshot", ContentContainer.Game);
            //gunshot.PlayAudioEffect();
            //gunshot.Volume = 1.0f;

            skrillex = new AudioPlayer();
            skrillex.LoadSong(@"content\\slats", ContentContainer.Game);
            skrillex.PlaySong();
            skrillex.Volume = 1.0f;

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
                EntityManager.Instance.Initialize(GraphicsManager.Instance);
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
            EntityManager.Instance.Draw(GraphicsManager.Instance);
            GraphicsManager.Instance.SpriteBatch.Begin();
            m_TestFont.Draw(GraphicsManager.Instance.SpriteBatch, "Candy Rush!", new Vector2(0f + m_TestFont.MeasureString("Candy Rush!").X, 100f));
            GraphicsManager.Instance.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
