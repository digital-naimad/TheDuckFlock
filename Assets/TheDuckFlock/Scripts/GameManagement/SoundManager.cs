using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TheDuckFlock
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField] private float soundVolume = 1;
        [SerializeField] private float musicVolume = 1;

        [SerializeField] private float minimumPitch = .5f;
        [SerializeField] private float maximumPitch = 2f;

        [SerializeField] private float minimumVolume = .1f;
        [SerializeField] private float maximumVolume = 1f;

        [SerializeField] private Sound[] sounds;

        [SerializeField] private AudioMixerGroup sfxMixerChannel;
        [SerializeField] private AudioMixerGroup musicMixerChannel;
        [SerializeField] private AudioMixerGroup uiMixerChannel;

        private bool isSoundMute = false;
        private bool isMusicMute = false;

        private string volumeParameterName = "volume";


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isMute"></param>
        public void SwitchSoundMute(bool isMute)
        {
            Debug.Log( name + " | Sound mute: " + isMute );

            isSoundMute = isMute;

            ApplySoundMute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isMute"></param>
        public void SwitchMusicMute(bool isMute)
        {
            Debug.Log(name + " | Music mute: " + isMute);

            isMusicMute = isMute;

            ApplyMusicMute();
        }

        /// <summary>
        /// Plays sound given in the first parameter
        /// </summary>

        /// <param name="isRandomVolumeAndPitch">optional bool, default = false</param>
        public void PlaySound(SoundTag soundTag, bool isRandomVolumeAndPitch = false)
        {
            Sound soundToPlay = sounds[(int)soundTag];
            soundToPlay.source.Stop();
            soundToPlay.source.volume = !isRandomVolumeAndPitch ? (IsTagMuted(soundTag) ? 0 : soundToPlay.volume ) : Random.Range(minimumVolume, soundToPlay.volume);
            soundToPlay.source.pitch = !isRandomVolumeAndPitch ? soundToPlay.pitch : Random.Range(minimumPitch, maximumPitch);

            soundToPlay.source.Play();
        }

        public bool IsTagMuted(SoundTag tag)
        {
            switch(tag)
            {
                case SoundTag.MusicMenu:
                case SoundTag.MusicGameplay:
                    return isMusicMute;
                case SoundTag.RunningDuck:
                case SoundTag.Quack:
                case SoundTag.SqueakingChicks:
                case SoundTag.ButtonClick:
                default:
                    return isSoundMute;
            }
        }

        private float GetSFXVolume(Sound soundToPlay)
        {
            return isSoundMute ? 0 : soundToPlay.volume;
        }

        private float GetMusicVolume(Sound soundToPlay)
        {
            return isMusicMute ? 0 : soundToPlay.volume;
        }

        private void ApplySoundMute()
        {
            soundVolume = isSoundMute ? 0 : 1;

            sfxMixerChannel.audioMixer.SetFloat(volumeParameterName, soundVolume);
            uiMixerChannel.audioMixer.SetFloat(volumeParameterName, soundVolume);

        }

        private void ApplyMusicMute()
        {
            musicVolume = isMusicMute ? 0 : 1;

            musicMixerChannel.audioMixer.SetFloat(volumeParameterName, soundVolume);
        }
    }
}
