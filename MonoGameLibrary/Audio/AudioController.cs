using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace MonoGameLibrary.Audio
{
    public class AudioController : IDisposable
    {
        // Tracks the sound effect instances created so they can be paused, unpaused and/or disposed.
        private readonly List<SoundEffectInstance> _activeSoundEffectInstance;

        // Tracks the volume for the song playback when muting and unmuting
        private float _previousSongVolume;

        //Tracks thbe volume for the sound effect playback when muting and unmuting
        private float _previousSoundEffectVolume;

        // Gets a value that indicates if audio is muted.
        public bool IsMuted { get; private set; }

        //Gets or sets the global volume of songs
        //If IsMuted is true, the getter will always return back to 0.0f, and the 
        //setter will ignore setting the volume

        public float SongVolume
        {
            get
            {
                if(IsMuted)
                {
                    return 0.0f;
                }
                return MediaPlayer.Volume;
            }
            set
            {
                if(IsMuted)
                {
                    return;
                }
                MediaPlayer.Volume = Math.Clamp(value, 0.0f, 1.0f);
            }
        }

        /// Gets or Sets the global volume of sound effects.
        /// If IsMuted is true, the getter will always return back 0.0f and the
        /// setter will ignore setting the volume.
        
        public float SoundEffectVolume
        {
            get
            {
                if(IsMuted)
                {
                    return 0.0f;
                }
                return SoundEffect.MasterVolume;
            }
            set
            {
                if(IsMuted)
                {
                    return;
                }
                SoundEffect.MasterVolume = Math.Clamp(value, 0.0f, 1.0f);
            }
        }

        //Gets a value that indicates if this audio controller has been disposed
        public bool IsDisposed { get; private set; }

        // Creates a new audio controller instance
        public AudioController()
        {
            _activeSoundEffectInstance = new List<SoundEffectInstance>();
        }

        // Finalizer called when object is collected by the garbage collector.
        ~AudioController() => Dispose(false);

        // Updates this audio controller

        public void Update()
        {
            for (int i = _activeSoundEffectInstance.Count - 1; i >= 0; i--)
            {
                SoundEffectInstance instance = _activeSoundEffectInstance[i];

                if(instance.State == SoundState.Stopped)
                {
                    if(!instance.IsDisposed)
                    {
                        instance.Dispose();
                    }
                    _activeSoundEffectInstance.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Plays the given sound effect.
        /// </summary>
        /// <param name="soundEffect">The sound effect to play.</param>
        /// <returns>The sound effect instance created by this method.</returns>
        public SoundEffectInstance PlaySoundEffect(SoundEffect soundEffect)
        {
            return PlaySoundEffect(soundEffect, 1.0f, 0.0f, 0.0f, false);
        }

        /// <summary>
        /// Plays the given sound effect with the specified properties.
        /// </summary>
        /// <param name="soundEffect">The sound effect to play.</param>
        /// <param name="volume">The volume, ranging from 0.0 (silence) to 1.0 (full volume).</param>
        /// <param name="pitch">The pitch adjustment, ranging from -1.0 (down an octave) to 0.0 (no change) to 1.0 (up an octave).</param>
        /// <param name="pan">The panning, ranging from -1.0 (left speaker) to 0.0 (centered), 1.0 (right speaker).</param>
        /// <param name="isLooped">Whether the the sound effect should loop after playback.</param>
        /// <returns>The sound effect instance created by playing the sound effect.</returns>
        /// <returns>The sound effect instance created by this method.</returns>
        public SoundEffectInstance PlaySoundEffect(SoundEffect soundEffect, float volume, float pitch, float pan, bool isLooped)
        {
            // Create an instance from the sound effect given
            SoundEffectInstance soundEffectInstance = soundEffect.CreateInstance();

            // Apply the volume, pitch, pan, and loop values specified
            soundEffectInstance.Volume = volume;
            soundEffectInstance.Pitch = pitch;
            soundEffectInstance.Pan = pan;
            soundEffectInstance.IsLooped = isLooped;

            // Tell the instance to play
            soundEffectInstance.Play();

            // Add it to the active instances for tracking
            _activeSoundEffectInstance.Add(soundEffectInstance);
            return soundEffectInstance;
        }

        /// <summary>
        /// Plays the given song.
        /// </summary>
        /// <param name="song">The song to play.</param>
        /// <param name="isRepeating">Optionally specify if the song should repeat.  Default is true.</param>
        public void PlaySong(Song song, bool isRepeating = true)
        {
            // Check if the media player is already playing, if so, stop it
            // If we do not stop it, this could cause issues on some platforms
            if(MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Stop();
            }
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = isRepeating;
        }

        // Pauses all audio
        public void PauseAudio()
        {
            // Pause any active songs playing
            MediaPlayer.Pause();

            // Pause any active sound effects 
            foreach (SoundEffectInstance soundEffectInstance in _activeSoundEffectInstance)
            {
                soundEffectInstance.Pause();
            }
        }

        // Resume plays of all audio
        public void ResumeAudio()
        {
            // Resume any active songs playing
            MediaPlayer.Resume();

            // Resumes any active sound effects 
            foreach (SoundEffectInstance soundEffectInstance in _activeSoundEffectInstance)
            {
                soundEffectInstance.Resume();
            }
        }

        // Mutes all audio

        public void MuteAudio()
        {
            // store the volume so they can be restored during UnmutedAudio
            _previousSongVolume = MediaPlayer.Volume;
            _previousSoundEffectVolume = SoundEffect.MasterVolume;

            // Set all volumes to 0
            MediaPlayer.Volume = 0.0f;
            SoundEffect.MasterVolume = 0.0f;

            IsMuted = true;
        }

       // Unmuted all audio to the volume level prior to muting 
       public void UnmutedAudio()
        {
            // Sets the volume to their previous level
            MediaPlayer.Volume = _previousSongVolume;
            SoundEffect.MasterVolume = _previousSoundEffectVolume;

            IsMuted = false;
        }

        // Toggles the current audio mute state
        public void ToggleMute()
        {
            if(IsMuted)
            {
                UnmutedAudio();
            }
            else
            {
                MuteAudio();
            }
        }

        // Disposes of this audio controller and cleans up resources
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes this audio controller and cleans up resources.
        /// </summary>
        /// <param name="disposing">Indicates whether managed resources should be disposed.</param>
        protected void Dispose(bool disposing)
        {
            if(IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                foreach (SoundEffectInstance soundEffectInstance in _activeSoundEffectInstance)
                {
                    soundEffectInstance.Dispose();
                }
                _activeSoundEffectInstance.Clear();
            }
            IsDisposed = true;
        }
    }
}
