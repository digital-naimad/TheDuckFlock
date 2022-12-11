using UnityEngine;

namespace TheDuckFlock
{
    public class DebugUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionToMark"></param>
        public static void DrawDebugMarker(Vector3 positionToMark)
        {
            Debug.DrawRay( positionToMark, Vector3.up, Color.green);
            Debug.DrawRay( positionToMark, Vector3.down, Color.green);
            Debug.DrawRay( positionToMark, Vector3.left, Color.red);
            Debug.DrawRay( positionToMark, Vector3.right, Color.red);
            Debug.DrawRay( positionToMark, Vector3.forward, Color.blue);
            Debug.DrawRay( positionToMark, Vector3.back, Color.blue);
        }
    }
}
