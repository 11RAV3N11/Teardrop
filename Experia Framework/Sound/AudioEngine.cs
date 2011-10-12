using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Sound_Engine
{
    public class AudioEngine
    {
        public static AudioEngine Instance { get { return Experia.Framework.Generics.Singleton<AudioEngine>.Instance; } }

        private float _MasterVolume = 1.0f;
        public float MasterVolume
        {
            get { return _MasterVolume; }
            set
            {
                _MasterVolume = MathHelper.Clamp(value, 0.0f, 1.0f);
            }
        }
    }
}
