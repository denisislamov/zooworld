using System;
using UnityEngine;
using ZooWorld.Core;
using ZooWorld.Core.Configs;

namespace ZooWorld.Installers
{
    [Serializable]
    public class GameSettings
    {
        [SerializeField] private AnimalConfigList _animalConfigList;
        public AnimalConfigList AnimalConfigList => _animalConfigList;
        
        [SerializeField] private AnimalManagerConfig _animalManagerConfig;
        public AnimalManagerConfig AnimalManagerConfig => _animalManagerConfig;
    }
}