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
using System.Reflection;
using Experia.Framework;
using Experia.Framework.UI;

namespace CandyRush
{
    /// <summary>This is the main type for your game</summary>
    public class CandyRushGame: EngineCore
    {
        
        public CandyRushGame(): base(EngineFlags.Debug | EngineFlags.MultiCore)
        {
            ContentLoader.Instance.Initialize(this);
            GraphicsManager.Instance.Initialize(this);
            GraphicsManager.Instance.ScreenResolution = new Vector2(1280f, 720f);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GraphicsManager.Instance.EnableSprites();
            InputManager.Instance.EnableMouse(Content.Load<Texture2D>(ContentContainer.Engine, @"Content\\pumpkin"), true);
            FileIO.Instance.CreateHardwareProfile(GraphicsManager.Instance.Device);
            GameStateManager.Instance.ChangeState(GameState.PlayingGame);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            MenuManager.Instance.AddMenu<MainMenu>("Main Menu");

            //Assembly currentAssembly = Assembly.GetExecutingAssembly();
            var a = Activator.CreateInstance("Candy Rush", "CandyRush.Zombie");
            EntityManager.Instance.AddGameEntity(a.Unwrap());
            EntityManager.Instance.DrawableGameObjects[0].Sprite.Position = new Vector2(200f, 100f);
            //Type

            EntityManager.Instance.LoadEntities(GraphicsManager.Instance);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GraphicsManager.Instance.Update();
            InputManager.Instance.Update(GraphicsManager.Instance.Device.Viewport);
            GameStateManager.Instance.Update(this);
            WorldManager.Instance.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            Graphics.ClearBackbuffer();
            GraphicsManager.Instance.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
            GameStateManager.Instance.Draw(Graphics);
            WorldManager.Instance.Draw(Graphics);
            InputManager.Instance.Mouse.Draw(GraphicsManager.Instance);
            GraphicsManager.Instance.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
