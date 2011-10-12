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
using Experia.Framework.Audio;

namespace Experia.Framework
{
    class AudioEffect
    {
        protected SoundEffect m_SoundEffect = null;
        protected SoundEffectInstance m_SoundEffectInstance = null;

        public float Volume = 0.0f;
        public float Pitch = 0.0f;
        public float Pan = 0.0f;
        

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

        /// <summary>
        /// Sets the Volume level with the max at 1.0 and min at 0.0
        /// </summary>
        public void AudioEffectVolume(float volume)
        {
            volume = MathHelper.Clamp(volume, 0.0f, 1.0f);
            Volume = volume * AudioManager.Instance.MasterVolume; //<-- This does not actually change the sound [AP]
        }

        /// <summary>
        /// Sets the Pan level with the max at 1.0 and min at 0.0
        /// </summary>
        public void PanAudioEffect(float pan)
        {
            pan = MathHelper.Clamp(pan, 0.0f, 1.0f);
            m_SoundEffectInstance.Pan = pan;
        }

        /// <summary>
        /// Sets the Pitch level with the max at 1.0 and min at 0.0
        /// </summary>
        public void PitchAudioEffect(float pitch)
        {
            pitch = MathHelper.Clamp(pitch, 0.0f, 1.0f);
            m_SoundEffectInstance.Pitch = pitch;
        }
    }
}
