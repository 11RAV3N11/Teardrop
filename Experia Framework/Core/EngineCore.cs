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

namespace Experia.Framework
{
    public class EngineCore: Game
    {
        protected EngineFlags m_EngineFlags;
        new protected ContentLoader Content
        {
            get { return ContentLoader.Instance; }
        }
        protected SpriteBatch SpriteBatch
        {
            get { return GraphicsManager.Instance.SpriteBatch; }
        }
        new protected GraphicsDevice GraphicsDevice
        {
            get { return GraphicsManager.Instance.Device; }
        }
        protected GraphicsManager Graphics
        {
            get { return GraphicsManager.Instance; }
        }
        public EngineCore(EngineFlags flags)
        {
        }
    }
}
