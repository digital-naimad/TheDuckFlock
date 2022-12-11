using UnityEngine;

namespace TheDuckFlock
{
    /// <summary>
    /// Custom object to store audio clips data for SoundManager
    /// </summary>
    [System.Serializable]
    public class Sound
    {
        public SoundTag tag;
        public AudioClip soundClip;

        [Range(0f, 1f)]
        public float volume = .5f;

        [Range(.1f, 3f)]
        public float pitch = 1f;

        //[HideInInspector]
        public AudioSource source;
    }
}