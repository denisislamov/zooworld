using UnityEngine;

namespace ZooWorld.Core
{
    [CreateAssetMenu(fileName = "AnimalManagerConfig", menuName = "ZooWorld/AnimalManagerConfig", order = 0)]
    public class AnimalManagerConfig : ScriptableObject
    {
        public float SpawnBoxSize;
        public float SpawnHeight;
        public float MaxAnimalCount;
    }
}