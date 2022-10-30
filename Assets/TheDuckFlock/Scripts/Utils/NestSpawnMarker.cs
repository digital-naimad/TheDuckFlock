using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class NestSpawnMarker : SpawnMarker
    {
        [SerializeField] private DucksMotherSpawnMarker _ducksMotherSpawnMarker;
        [SerializeField] private EggSpawnMarker _eggSpawnMarker;

        public DucksMotherSpawnMarker DucksMotherSpawnMarker { get { return _ducksMotherSpawnMarker; } }
        public EggSpawnMarker EggSpawnMarker { get { return _eggSpawnMarker; } }
    }
}