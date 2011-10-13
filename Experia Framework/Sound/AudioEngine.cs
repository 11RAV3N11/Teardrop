using Microsoft.Xna.Framework;

namespace Experia.Framework.Audio
{
    public class AudioManager
    {
        public static AudioManager Instance { get { return Experia.Framework.Generics.Singleton<AudioManager>.Instance; } }
        protected AudioManager() { }
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
