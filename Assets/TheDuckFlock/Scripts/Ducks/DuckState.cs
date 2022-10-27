using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public enum DuckState 
    {
        /// <summary>
        /// Stands as IDLE
        /// </summary>
        Idling,

        /// <summary>
        /// Searching for the parent, rotates, go to target
        /// </summary>
        FollowingParent,

        /// <summary>
        /// Searching for a GRAIN, rotates, go to target
        /// </summary>
        LookingForFood,


        /// <summary>
        /// Picks seeds
        /// </summary>
        EatingGrain,

        /// <summary>
        /// Duck is missed
        /// </summary>
        Lost
    }
}
