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

namespace Sound_Engine
{
    class AudioEffects
    {
        public SoundEffect KeyWord = null;
        public SoundEffectInstance keyWord = null;

        public float Volume = 0.0f;
        public float Pitch = 0.0f;
        public float Pan = 0.0f;
        

        public void LoadAudioEffect(string Location, ContentManager Content)
        {
            KeyWord = Content.Load<SoundEffect>(Location);
            keyWord = KeyWord.CreateInstance();
        }

        /// <summary>
        /// Sets the current state and Playes the selected sound effect
        /// </summary>
        public void PlayAudioEffect()
        {
            if ( keyWord.State != SoundState.Playing)
                 keyWord.Play();
        }

        /// <summary>
        /// Sets the current state and Pauses the selected sound effect
        /// </summary>
        public void PauseAudioEffect()
        {
            if (keyWord.State == SoundState.Playing)
                keyWord.Pause();
        }

        /// <summary>
        /// Sets the current state and Resumes the selected sound effect
        /// </summary>
        public void ResumeAudioEffect()
        {
            if (keyWord.State == SoundState.Paused)
                keyWord.Resume();
        }

        /// <summary>
        /// Sets the current state and Stops the selected sound effect
        /// </summary>
        public void StopAudioEffect()
        {
            if ( keyWord.State == SoundState.Playing ||  keyWord.State == SoundState.Paused)
                 keyWord.Stop();
        }

        /// <summary>
        /// Sets the Volume level with the max at 1.0 and min at 0.0
        /// </summary>
        public void AudioEffectVolume(float volume)
        {
            volume = MathHelper.Clamp(volume, 0.0f, 1.0f);
            Volume = volume * AudioEngine.Instance.MasterVolume;
        }

        /// <summary>
        /// Sets the Pan level with the max at 1.0 and min at 0.0
        /// </summary>
        public void PanAudioEffect(float pan)
        {
            pan = MathHelper.Clamp(pan, 0.0f, 1.0f);
            keyWord.Pan = pan;
        }

        /// <summary>
        /// Sets the Pitch level with the max at 1.0 and min at 0.0
        /// </summary>
        public void PitchAudioEffect(float pitch)
        {
            pitch = MathHelper.Clamp(pitch, 0.0f, 1.0f);
            keyWord.Pitch = pitch;
        }
    }
}
