using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Experia.Framework.Audio
{
    public class AudioPlayer
    {
        protected Song m_Song = null;

        public void LoadSong(string Location, ContentContainer container)
        {
            m_Song = ContentLoader.Instance.Load<Song>(container, Location);
        }

        /// <summary>
        /// Sets the current state and Playes the selected sound effect
        /// </summary>
        public void PlaySong()
        {
            if (MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(m_Song);
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

        public float Volume
        {
            get
            {
                return MediaPlayer.Volume;
            }
            set
            {
                value = MathHelper.Clamp(value, 0.0f, 1.0f);
                MediaPlayer.Volume = value;
            }
        }
    }
}
