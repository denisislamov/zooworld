using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Core.Configs;

namespace ZooWorld.Core
{
    // TODO - to animal manager
    public class AnimalManager
    {
        private readonly List<ActorMovement<ActorMovementConfig>> _actorMovements = new();
        private readonly AnimalConfigList _animalConfigs;

        private readonly ActorMovement<ActorMovementConfig>.CustomDiFactory _actorMovementsFactory;
        
        public AnimalManager(ActorMovement<ActorMovementConfig>.CustomDiFactory actorMovementsFactory, AnimalConfigList animalConfigs)
        {
            _actorMovementsFactory = actorMovementsFactory;
            _animalConfigs = animalConfigs;
        }
        
        public IEnumerable<ActorMovement<ActorMovementConfig>> ActorMovements => _actorMovements;

        public void Spawn(int index)
        {
            AnimalConfig animalConfig = _animalConfigs.AnimalConfigs[index];
            ActorMovementConfig actorMovementConfig =  animalConfig.ActorMovementConfig;

            ActorMovement<ActorMovementConfig> actorMovement = null;
            switch (actorMovementConfig)
            {
                case JumpingMovementConfig:
                    actorMovement = _actorMovementsFactory.Create<JumpMovement>();
                    break;
                case LinearMovementConfig:
                    actorMovement = _actorMovementsFactory.Create<LinearMovement>();
                    break;
            }
            
            if (actorMovement == null)
            {
                Debug.LogError("Actor movement is null");
                return;
            }
            
            actorMovement.SetConfig(animalConfig.ActorMovementConfig);
            _actorMovements.Add(actorMovement);
        }
    }
}