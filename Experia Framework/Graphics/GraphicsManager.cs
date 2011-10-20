﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework
{
    public delegate void GraphicsRebuildArgs(GraphicsManager graphics);
    //Suppressing Code Review for IDisposable, only time something needs to be disposed is on app exit.
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class GraphicsManager
    {
        public GraphicsDevice Device { get { return m_GraphicsDeviceManager.GraphicsDevice; } }
        public static GraphicsManager Instance { get { return Experia.Framework.Generics.Singleton<GraphicsManager>.Instance; } }
        public SpriteBatch SpriteBatch;
        //Suppressing Analysis for Event Rebuild, does not match own design
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        public event GraphicsRebuildArgs HookGraphicsRebuild;
        protected bool m_DeviceChanged;
        protected Vector2[] m_v2Resolutions;
        protected PresentationParameters m_PresentationParams;
        protected GraphicsDeviceManager m_GraphicsDeviceManager;
        protected GraphicsManager() { }
        public void Initialize(Game game)
        {
            m_GraphicsDeviceManager = new GraphicsDeviceManager(game);
            m_v2Resolutions = new Vector2[2];
            m_PresentationParams = new PresentationParameters();
            m_DeviceChanged = true;
        }

        public void EnableSprites()
        {
            if (SpriteBatch == null)
                SpriteBatch = new SpriteBatch(m_GraphicsDeviceManager.GraphicsDevice);
        }
        public void ScreenResolution(Vector2 v2Resolution)
        {
            m_v2Resolutions[0] = v2Resolution;
            m_PresentationParams.BackBufferWidth = (int)v2Resolution.X;
            m_PresentationParams.BackBufferHeight = (int)v2Resolution.Y;
            m_DeviceChanged = true;
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
