using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework
{
    public delegate void GraphicsRebuildArgs(GraphicsPacket graphics);
    public class GraphicsPacket
    {
        public enum Flags { FXAA, MultiSampling, SuperSampling, LegitVsync, FakeVsync }
        public GraphicsDevice Device { get { return m_GraphicsDeviceManager.GraphicsDevice; } }
        public SpriteBatch SpriteBatch;
        public event GraphicsRebuildArgs HookGraphicsRebuild;

        protected bool m_DeviceChanged;
        protected Vector2[] m_v2Resolutions;
        protected PresentationParameters m_PresentationParams;
        protected GraphicsDeviceManager m_GraphicsDeviceManager;

        public GraphicsPacket(ExperiaCore game, ContentLoader contentLoader)
        {
            m_GraphicsDeviceManager = new GraphicsDeviceManager(game);
            m_v2Resolutions = new Vector2[2];
            m_PresentationParams = new PresentationParameters();
            m_DeviceChanged = true;
            
            /*++++++Renderers/Shaders++++++*/
        }
        public void EnableSprites()
        {
            if(SpriteBatch == null)
                SpriteBatch = new SpriteBatch(m_GraphicsDeviceManager.GraphicsDevice);
        }
        public void ScreenResolution(Vector2 v2Resolution)
        {
            m_v2Resolutions[0] = v2Resolution;
            m_PresentationParams.BackBufferWidth = (int)v2Resolution.X;
            m_PresentationParams.BackBufferHeight = (int)v2Resolution.Y;
            m_DeviceChanged = true;
        }
        public void BufferResolution(Vector2 v2Resolution)
        {
            m_v2Resolutions[1] = v2Resolution;
            m_DeviceChanged = true;
        }
        public void AntiAliasing(Flags aaType, bool bEnabled)
        {
            switch (aaType)
            {
                case Flags.MultiSampling:
                    m_GraphicsDeviceManager.PreferMultiSampling = bEnabled;
                    m_PresentationParams.MultiSampleCount = 4;
                    m_DeviceChanged = true;
                    break;
                case Flags.FXAA:
                    //Implementation

                    m_DeviceChanged = true;
                    break;
                case Flags.SuperSampling:
                    //Implementation

                    m_DeviceChanged = true;
                    break;
            }
        }
        public void VerticalSync(Flags vsyncType)
        {
            if (vsyncType == Flags.LegitVsync)
            {
                m_GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;
            }
            else
            {
                //Implementation for Fake Vsync
            }
        }
        public void Update()
        {
            if (m_DeviceChanged)
            {

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
