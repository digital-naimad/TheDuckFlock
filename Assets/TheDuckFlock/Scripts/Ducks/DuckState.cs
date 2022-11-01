using System.Collections;

namespace TheDuckFlock
{
    public enum DuckState 
    {
        /// <summary>
        /// Fresh duck
        /// </summary>
        Newborn,

        /// <summary>
        /// Stands as IDLE
        /// </summary>
        Idle,

        /// <summary>
        /// Searching for the parent, rotates, go to target
        /// </summary>
        GoToParent,

        /// <summary>
        /// Warning: Not only a duck mother can be a parent for duckie
        /// </summary>
        FollowParent,

        /// <summary>
        /// Searching for a GRAIN, rotates, go to target
        /// </summary>
        LookForFood,


        /// <summary>
        /// Picks seeds
        /// </summary>
        EatGrain,

        /// <summary>
        /// Duck is missed
        /// </summary>
        Lost
    }
}
