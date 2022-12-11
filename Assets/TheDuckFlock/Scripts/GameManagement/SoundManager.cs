using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField] private float soundVolume = 1;
        [SerializeField] private float musicVolume = 1;

        private bool isSoundMute = false;
        private bool isMusicMute = false;


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

        private void ApplySoundMute()
        {
            soundVolume = isSoundMute ? 0 : 1;
        }

        private void ApplyMusicMute()
        {
            musicVolume = isMusicMute ? 0 : 1;
        }
    }
}
