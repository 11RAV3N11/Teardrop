using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Experia.Framework
{
    
    public class ThreadedContentManager: ContentManager
    {
        static object loadLock = new object();

        public ThreadedContentManager(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public ThreadedContentManager(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory) { }

        public override T Load<T>(string assetName)
        {
            lock (loadLock)
                return base.Load<T>(assetName);
        }

        public Texture2D FromStream(Stream stream)
        {
            lock (loadLock)
            {
                IGraphicsDeviceService graphicsDeviceService = (IGraphicsDeviceService)ServiceProvider.GetService(typeof(IGraphicsDeviceService));
                return Texture2D.FromStream(graphicsDeviceService.GraphicsDevice, stream);
            }
        }
    }
}
