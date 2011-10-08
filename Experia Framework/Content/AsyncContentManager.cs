using System.Threading;
using System.Windows.Threading;
using Microsoft.Xna.Framework.Content;

namespace Experia.Framework
{
    static class AsyncContentManager
    {
        /// <summary>
        /// Loads the asset asynchronously on another thread.
        /// </summary>
        /// <typeparam name="T">The type of the asset to load</typeparam>
        /// <param name="contentManager">The content manager that will load the asset</param>
        /// <param name="assetName">The path and name of the asset (without the extension) relative to the root directory of the content manager</param>
        /// <param name="action">Callback that is called when the asset is loaded</param>
        public static void Load<T>(this ContentManager contentManager, string assetName, System.Action<T> action)
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                T asset = contentManager.Load<T>(assetName);
                if (action != null)
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(action, asset); //<-- Not Supported by the 360 from my understanding

                    //Todo Create a Difference from "SynchronizationContext" for the 360 this requires more research on my part
                    
                }
            });
        }
    }
}
