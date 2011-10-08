using System;

namespace CandyRush
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (CandyRushGame game = new CandyRushGame())
            {
                game.Run();
            }
        }
    }
#endif
}

