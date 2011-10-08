using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Experia.Framework
{
    public enum Container { Persistent = 0, Engine = 1, UI = 2, Game = 3, Temporary = 4 }
    public class ContentLoader
    {
        protected const int ConstMaxManagers = 4;
        protected ThreadedContentManager[] _Content;

        public ContentLoader(ExperiaCore game)
        {

            _Content = new ThreadedContentManager[ConstMaxManagers];
            for (int i = 0; i < _Content.Length; i++)
                _Content[i] = new ThreadedContentManager(game.Services);
        }

        public T Load<T>(Container container, string assetLocation)
        {
            return _Content[(int)container].Load<T>(assetLocation);
        }

        protected ContentManager GetContainer(int ContainerID)
        {
            if (_Content[ContainerID] != null)
                return (_Content[ContainerID]);
            else
            {
                throw new Exception("Content Manager's have not been initialized did we call new?");
            }
        }
    }
}
