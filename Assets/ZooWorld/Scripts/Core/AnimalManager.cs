using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZooWorld.Core.Configs;

namespace ZooWorld.Core
{
    // TODO - to animal manager
    public class AnimalManager : MonoBehaviour
    {
        private readonly List<ActorMovement<ActorMovementConfig>> _actorMovements = new();
        private AnimalConfigList _animalConfigs;

        private ActorMovement<ActorMovementConfig>.CustomDiFactory _actorMovementsFactory;
        
        [Inject]
        public void Init(ActorMovement<ActorMovementConfig>.CustomDiFactory actorMovementsFactory, AnimalConfigList animalConfigs)
        {
            _actorMovementsFactory = actorMovementsFactory;
            _animalConfigs = animalConfigs;
        }
        
        public IEnumerable<ActorMovement<ActorMovementConfig>> ActorMovements => _actorMovements;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Spawn(0);
            }
        }
        
        public void Spawn(int index)
        {
            AnimalConfig animalConfig = _animalConfigs.AnimalConfigs[index];
            ActorMovementConfig actorMovementConfig =  animalConfig.ActorMovementConfig;

            ActorMovement<ActorMovementConfig> actorMovement = actorMovementConfig switch
            {
                JumpingMovementConfig => _actorMovementsFactory.Create<JumpMovement>(),
                LinearMovementConfig => _actorMovementsFactory.Create<LinearMovement>(),
                _ => null
            };

            if (actorMovement == null)
            {
                Debug.LogError("Actor movement is null");
                return;
            }
            
            actorMovement.SetConfig(animalConfig.ActorMovementConfig);
            
            actorMovement.gameObject.tag = animalConfig.Type switch
            {
                AnimalConfig.AnimalType.Pray => Constants.PreyTag,
                AnimalConfig.AnimalType.Predator => Constants.PredatorTag,
                _ => actorMovement.gameObject.tag
            };
            
            actorMovement.gameObject.AddComponent<AnimalInteraction>();
            _actorMovements.Add(actorMovement);
        }
    }
}