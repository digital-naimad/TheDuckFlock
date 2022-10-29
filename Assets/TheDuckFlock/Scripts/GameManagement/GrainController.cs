using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class GrainController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

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
        public void RestartParticles()
        {
            _particleSystem.Stop();
            _particleSystem.Play();
        }

        
    }
}
