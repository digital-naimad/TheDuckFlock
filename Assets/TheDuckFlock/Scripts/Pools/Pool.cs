using System;
using UnityEngine;

namespace TheDuckFlock
{
    [Serializable]
    public struct Pool
    {
        public PoolTag tag;
        public GameObject prefab;
        public short poolSize;
    }
}