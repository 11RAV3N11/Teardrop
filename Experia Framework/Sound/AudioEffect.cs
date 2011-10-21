using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Experia.Framework.Audio
{
    public class AudioEffect
    {
        protected SoundEffect m_SoundEffect = null;
        protected SoundEffectInstance m_SoundEffectInstance = null;        

        public void LoadAudioEffect(string Location, ContentContainer container)
        {
            m_SoundEffect = ContentLoader.Instance.Load<SoundEffect>(container, Location);
            m_SoundEffectInstance = m_SoundEffect.CreateInstance();
        }

        /// <summary>
        /// Sets the current state and Playes the selected sound effect
        /// </summary>
        public void PlayAudioEffect()
        {
            if ( m_SoundEffectInstance.State != SoundState.Playing)
                 m_SoundEffectInstance.Play();
        }

        /// <summary>
        /// Sets the current state and Pauses the selected sound effect
        /// </summary>
        public void PauseAudioEffect()
        {
            if (m_SoundEffectInstance.State == SoundState.Playing)
                m_SoundEffectInstance.Pause();
        }

        /// <summary>
        /// Sets the current state and Resumes the selected sound effect
        /// </summary>
        public void ResumeAudioEffect()
        {
            if (m_SoundEffectInstance.State == SoundState.Paused)
                m_SoundEffectInstance.Resume();
        }

        /// <summary>
        /// Sets the current state and Stops the selected sound effect
        /// </summary>
        public void StopAudioEffect()
        {
            if ( m_SoundEffectInstance.State == SoundState.Playing ||  m_SoundEffectInstance.State == SoundState.Paused)
                 m_SoundEffectInstance.Stop();
        }

        public float Volume
        {
            get
            {
                return m_SoundEffectInstance.Volume;
            }
            set
            {
                value = MathHelper.Clamp(value, 0.0f, 1.0f);
                m_SoundEffectInstance.Volume = value;
            }
        }

        public float Pan
        {
            get
            {
                return m_SoundEffectInstance.Pan;
            }
            set
            {
                value = MathHelper.Clamp(value, 0.0f, 1.0f);
                m_SoundEffectInstance.Pan = value;
            }
        }

        public float Pitch
        {
            get
            {
                return m_SoundEffectInstance.Pitch;
            }
            set
            {
                value = MathHelper.Clamp(value, 0.0f, 1.0f);
                m_SoundEffectInstance.Pitch = value;
            }
        }
    }
}
