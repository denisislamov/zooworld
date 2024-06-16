using System;
using ZooWorld.Core.Configs;

namespace ZooWorld.Core
{
    [Serializable]
    public class AnimalConfig
    {
        public string Name;
        public enum AnimalType
        {
            Pray,
            Predator
        }
        
        public AnimalType Type;
        public ActorMovementConfig ActorMovementConfig;
    }
}
