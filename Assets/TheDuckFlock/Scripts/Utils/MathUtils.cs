using UnityEngine;

namespace TheDuckFlock
{
    public class MathUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static float GetAngleBetween2PointsInDegrees(float x1, float y1, float x2, float y2)
        {
            float angleInRadians = Mathf.Atan2(y2 - y1, x2 - x1);
            return angleInRadians * Mathf.Rad2Deg;
        }
    }
}
