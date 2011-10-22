﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework
{
    
    public class GraphicsManager
    {
        /*********************************************************************/
        public delegate void GraphicsRebuildArgs(GraphicsManager graphics);
        public static GraphicsManager Instance { get { return Experia.Framework.Generics.Singleton<GraphicsManager>.Instance; } }
        /*********************************************************************/
        public GraphicsDevice Device { get { return m_GraphicsDeviceManager.GraphicsDevice; } }
        /*********************************************************************/
        public SpriteBatch SpriteBatch;
        public Color BackBufferColor;
        public event GraphicsRebuildArgs HookGraphicsRebuild
        {
            add
            {
                m_HookGraphicsRebuild += value;
                m_DeviceChanged = true;
            }

            remove
            {
                m_HookGraphicsRebuild -= value;
            }
        }
        public bool EnableFullScreen
        {
            get
            {
                return m_GraphicsDeviceManager.IsFullScreen;
            }
            set
            {
                m_GraphicsDeviceManager.IsFullScreen = value;
            }
        }
        /*********************************************************************/
        protected bool m_DeviceChanged;
        protected event GraphicsRebuildArgs m_HookGraphicsRebuild;
        protected Vector2[] m_v2Resolutions;
        protected PresentationParameters m_PresentationParams;
        protected GraphicsDeviceManager m_GraphicsDeviceManager;
        protected Color m_backBufferStockColor = Color.CornflowerBlue;
        protected Color m_renderTargetStockColor = Color.Purple;
        protected Matrix m_SpriteScale;
        /*********************************************************************/
        protected GraphicsManager() { }

        /// <summary>Prepares the GraphicsManager internally for work, needs to be called in your XnaGame Constructor.</summary>
        /// <param name="game">Your XnaGame</param>
        public void Initialize(Game game)
        {
            m_GraphicsDeviceManager = new GraphicsDeviceManager(game);
            m_v2Resolutions = new Vector2[2];
            m_PresentationParams = new PresentationParameters();
            m_DeviceChanged = true;
            BackBufferColor = Color.CornflowerBlue;
        }
        public void BeginSpriteDraw()
        {
            SpriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.AnisotropicClamp,
                DepthStencilState.Default,
                RasterizerState.CullCounterClockwise,
                null, m_SpriteScale);
        }
        public void BeginSpriteDraw(BlendState blendState)
        {
            SpriteBatch.Begin(SpriteSortMode.Deferred,
                blendState,
                SamplerState.AnisotropicClamp,
                DepthStencilState.Default,
                RasterizerState.CullCounterClockwise,
                null, m_SpriteScale);
        }
        public void EndSpriteDraw()
        {
            SpriteBatch.End();
        }
        /// <summary>Prepares and sets up the SpriteBatch - Call in your Initialize Method</summary>
        public void EnableSprites()
        {
            if (SpriteBatch == null)
                SpriteBatch = new SpriteBatch(m_GraphicsDeviceManager.GraphicsDevice);
        }
        public Vector2 ScreenResolution
        {
            get
            {
                return m_v2Resolutions[0];
            }
            set
            {
                m_v2Resolutions[0].X = value.X;
                m_v2Resolutions[0].Y = value.Y;

                m_PresentationParams.BackBufferWidth = (int)value.X;
                m_PresentationParams.BackBufferHeight = (int)value.Y; 

                m_GraphicsDeviceManager.PreferredBackBufferWidth = m_PresentationParams.BackBufferWidth;
                m_GraphicsDeviceManager.PreferredBackBufferHeight = m_PresentationParams.BackBufferHeight;
                m_GraphicsDeviceManager.ApplyChanges();
            }
        }
        public Vector2 SpriteResolution
        {
            get
            {
                return m_v2Resolutions[1];
            }
            set
            {
                m_v2Resolutions[1] = value;
                m_DeviceChanged = true;
            }
        }
        public void AntiAliasing(AntiAliasingFlags aaType, bool bEnabled)
        {
            switch (aaType)
            {
                case AntiAliasingFlags.MSAA:
                    m_GraphicsDeviceManager.PreferMultiSampling = bEnabled;
                    m_PresentationParams.MultiSampleCount = 4;
                    m_DeviceChanged = true;
                    break;
                case AntiAliasingFlags.FXAA:
                    //Implementation

                    m_DeviceChanged = true;
                    break;
                case AntiAliasingFlags.SSAA:
                    //Implementation

                    m_DeviceChanged = true;
                    break;
            }
        }
        public void VerticalSync(VerticleSyncFlags vsyncType)
        {
            if (vsyncType == VerticleSyncFlags.LockedVsync)
            {
                m_GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;
            }
            else if (vsyncType == VerticleSyncFlags.UnlockedVsync)
            {
                //Implementation for Fake Vsync
            }
        }
        public void ClearBackbuffer()
        {
            Device.Clear(BackBufferColor);
        }
        public void Update()
        {
            if (m_DeviceChanged)
            {
                Vector2 screenScale = m_v2Resolutions[0] / m_v2Resolutions[1] ;
                m_SpriteScale = Matrix.CreateScale(screenScale.X, screenScale.Y, 1.0f);

                if (m_HookGraphicsRebuild != null)
                {
                    m_HookGraphicsRebuild.Invoke(this);
                }


                //++Recreate Our Shader Materials++//
                m_DeviceChanged = false;
            }
        }
    }
}
