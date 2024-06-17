using UnityEngine;

namespace ZooWorld.Core
{
    [CreateAssetMenu(fileName = "AnimalSpawnConfig", menuName = "ZooWorld/AnimalSpawnConfig", order = 0)]
    public class AnimalSpawnConfig : ScriptableObject
    {
        public float SpawnBoxSize;
        public float SpawnHeight;
        public float MaxAnimalCount;
        
        [Tooltip("Milliseconds")]
        public Vector2 SpawnInterval;
    }
}