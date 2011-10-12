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
    class AudioPlayer
    {
        public Song Media = null;

        public float Volume = 0.0f;
        public float Pitch = 0.0f;
        public float Pan = 0.0f;

        public void LoadSong(string Location, ContentManager Content)
        {
            Media = Content.Load<Song>(Location);
        }

        /// <summary>
        /// Sets the current state and Playes the selected sound effect
        /// </summary>
        public void PlaySong()
        {
            if (MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(Media);
        }

        /// <summary>
        /// Sets the current state and Pauses the selected sound effect
        /// </summary>
        public void PauseSong()
        {
            if (MediaPlayer.State == MediaState.Playing)
                MediaPlayer.Pause();
        }

        /// <summary>
        /// Sets the current state and Resumes the selected sound effect
        /// </summary>
        public void ResumeSong()
        {
            if (MediaPlayer.State == MediaState.Paused)
                MediaPlayer.Resume();
        }

        /// <summary>
        /// Sets the current state and Stops the selected sound effect
        /// </summary>
        public void StopSong()
        {
            if (MediaPlayer.State == MediaState.Playing || MediaPlayer.State == MediaState.Paused)
                MediaPlayer.Stop();
        }

        /// <summary>
        /// Sets the Volume level with the max at 1.0 and min at 0.0
        /// </summary>
        public void SongVolume(float volume)
        {
            volume = MathHelper.Clamp(volume, 0.0f, 1.0f);
            Volume = volume * AudioEngine.Instance.MasterVolume;
        }
    }
}
