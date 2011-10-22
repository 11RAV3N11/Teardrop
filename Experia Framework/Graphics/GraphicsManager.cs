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
        public event GraphicsRebuildArgs HookGraphicsRebuild;
        /*********************************************************************/
        protected bool m_DeviceChanged;
        protected Vector2[] m_v2Resolutions;
        protected PresentationParameters m_PresentationParams;
        protected GraphicsDeviceManager m_GraphicsDeviceManager;
        protected Color m_backBufferStockColor = Color.CornflowerBlue;
        protected Color m_renderTargetStockColor = Color.Purple;
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
                m_DeviceChanged = true;
            }
        }
        public void SpriteResolution(Vector2 v2Resolution)
        {
            m_v2Resolutions[1] = v2Resolution;
            m_DeviceChanged = true;
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
                m_GraphicsDeviceManager.PreferredBackBufferWidth = m_PresentationParams.BackBufferWidth;
                m_GraphicsDeviceManager.PreferredBackBufferHeight = m_PresentationParams.BackBufferHeight;
                m_GraphicsDeviceManager.ApplyChanges();

                if (HookGraphicsRebuild != null)
                {
                    HookGraphicsRebuild.Invoke(this);
                }


                //++Recreate Our Shader Materials++//
                m_DeviceChanged = false;
            }
        }
    }
}
