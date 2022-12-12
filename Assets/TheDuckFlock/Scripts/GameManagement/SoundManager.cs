using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

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

        private float fadeStep = .1f;
        private float fadeDuration = 3f;
        private Ease fadeEase = Ease.InOutCubic;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isMute"></param>
        public void SwitchSoundMute(bool isMute)
        {
            // Debug.Log( name + " | Sound mute: " + isMute );

            isSoundMute = isMute;

            ApplySoundMute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isMute"></param>
        public void SwitchMusicMute(bool isMute)
        {
           // Debug.Log(name + " | Music mute: " + isMute);

            isMusicMute = isMute;

            ApplyMusicMute();
        }

        public void PlayMusic(SoundTag soundTag)
        {
            sounds[(int)soundTag].source.Play();
            sounds[(int)soundTag].source.DOFade(sounds[(int)soundTag].volume, fadeDuration).From(0, true).SetEase(fadeEase);

        }

        public void TurnOffVolume(SoundTag soundTag)
        {
            sounds[(int)soundTag].source.volume = 0;
        }

        public void TurnUpVolume(SoundTag soundTag)
        {
            float currentVolume = sounds[(int)soundTag].source.volume;
            sounds[(int)soundTag].source.DOFade(Mathf.Clamp01(currentVolume + fadeStep) * sounds[(int)soundTag].volume , fadeDuration).SetEase(fadeEase);
        }

        public void TurnDownVolume(SoundTag soundTag)
        {
            float currentVolume = sounds[(int)soundTag].source.volume;
           
            sounds[(int)soundTag].source.DOFade(Mathf.Clamp01(currentVolume - fadeStep) * sounds[(int)soundTag].volume, fadeDuration).SetEase(fadeEase);
            
        }

        public void TurnOffWithFade(SoundTag soundTag)
        {
            
            sounds[(int)soundTag].source.DOFade(0, fadeDuration).SetEase(fadeEase)
                .OnComplete(() =>
                {
                    sounds[(int)soundTag].source.Stop();
                });
        }

        /// <summary>
        /// Plays sound given in the first parameter
        /// </summary>
        /// <param name="isRandomVolumeAndPitch">optional bool, default = false</param>
        public void PlaySound(SoundTag soundTag, bool isRandomVolumeAndPitch = false, bool isFadeIn = false)
        {
            Sound soundToPlay = sounds[(int)soundTag];

            soundToPlay.source.clip = soundToPlay.soundClip;

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

            //sfxMixerChannel.audioMixer.SetFloat(volumeParameterName, soundVolume);
            //uiMixerChannel.audioMixer.SetFloat(volumeParameterName, soundVolume);

           

            sounds[(int)SoundTag.ButtonClick].source.mute = isSoundMute;
            sounds[(int)SoundTag.RunningDuck].source.mute = isSoundMute;
            sounds[(int)SoundTag.SqueakingChicks].source.mute = isSoundMute;
            sounds[(int)SoundTag.Quack].source.mute = isSoundMute;



        }

        private void ApplyMusicMute()
        {
            musicVolume = isMusicMute ? 0 : 1;

            //musicMixerChannel.audioMixer.SetFloat(volumeParameterName, soundVolume);

            sounds[(int)SoundTag.MusicMenu].source.mute = isMusicMute;
            sounds[(int)SoundTag.MusicGameplay].source.mute = isMusicMute;
        }
    }
}
