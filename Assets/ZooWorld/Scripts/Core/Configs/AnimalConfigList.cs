using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.Core.Configs
{
    [CreateAssetMenu(fileName = "AnimalConfigList", menuName = "Configs/AnimalConfigList", order = 1)]
    public class AnimalConfigList : ScriptableObject
    {
        public List<AnimalConfig> AnimalConfigs;
        
        public JumpMovement JumpMovementPrefab;
        public LinearMovement LinearMovementPrefab;
    }
}
