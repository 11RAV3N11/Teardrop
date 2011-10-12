using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Experia.Framework.Audio
{
    public class AudioManager
    {
        public static AudioManager Instance { get { return Experia.Framework.Generics.Singleton<AudioManager>.Instance; } }

        protected float m_MasterVolume = 1.0f;
        public float MasterVolume
        {
            get { return m_MasterVolume; }
            set
            {
                m_MasterVolume = MathHelper.Clamp(value, 0.0f, 1.0f);
            }
        }
    }
}
