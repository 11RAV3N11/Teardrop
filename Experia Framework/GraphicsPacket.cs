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
        public GraphicsDevice Device { get { return Manager.GraphicsDevice; } }
        
        public event GraphicsRebuildArgs HookGraphicsRebuild;

        protected bool _bDeviceChanged;
        protected Vector2[] _v2Resolutions;
        protected PresentationParameters _presentationParams;
        protected GraphicsDeviceManager Manager;

        public GraphicsPacket(ExperiaCore game, ContentLoader contentLoader)
        {
            Manager = new GraphicsDeviceManager(game);
            _v2Resolutions = new Vector2[2];
            _presentationParams = new PresentationParameters();
            _bDeviceChanged = true;
            
            /*++++++Renderers/Shaders++++++*/

        }
        public void ScreenResolution(Vector2 v2Resolution)
        {
            _v2Resolutions[0] = v2Resolution;
            _presentationParams.BackBufferWidth = (int)v2Resolution.X;
            _presentationParams.BackBufferHeight = (int)v2Resolution.Y;
            _bDeviceChanged = true;
        }
        public void BufferResolution(Vector2 v2Resolution)
        {
            _v2Resolutions[1] = v2Resolution;
            _bDeviceChanged = true;
        }
        public void AntiAliasing(Flags aaType, bool bEnabled)
        {
            switch (aaType)
            {
                case Flags.MultiSampling:
                    Manager.PreferMultiSampling = bEnabled;
                    _presentationParams.MultiSampleCount = 4;
                    _bDeviceChanged = true;
                    break;
                case Flags.FXAA:
                    //Implementation

                    _bDeviceChanged = true;
                    break;
                case Flags.SuperSampling:
                    //Implementation

                    _bDeviceChanged = true;
                    break;
            }
        }
        public void VerticalSync(Flags vsyncType)
        {
            if (vsyncType == Flags.LegitVsync)
            {
                Manager.SynchronizeWithVerticalRetrace = true;
            }
            else
            {
                //Implementation for Fake Vsync
            }
        }
        public void Update()
        {
            if (_bDeviceChanged)
            {

                Manager.ApplyChanges();

                if (HookGraphicsRebuild != null)


                //++Recreate Our Shader Materials++//

                _bDeviceChanged = false;
            }
        }
    }
}
