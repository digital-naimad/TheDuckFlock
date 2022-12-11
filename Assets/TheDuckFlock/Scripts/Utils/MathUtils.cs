
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public static class MathUtils
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

        private static System.Random rng = new System.Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
