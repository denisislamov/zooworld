using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZooWorld.Core.Configs;
using ZooWorld.UI;

namespace ZooWorld.Core
{
    public class AnimalSpawnSystem
    {
        private readonly List<ActorMovement<ActorMovementConfig>> _actorMovements = new();
        private AnimalConfigList _animalConfigs;

        private ActorMovement<ActorMovementConfig>.CustomDiFactory _actorMovementsFactory;
        private AnimalManagerConfig _animalManagerConfig;
        
        private ActorInteraction.Factory _actorInteractionFactory;
        private UiSystem _uiSystem;
        
        [Inject]
        public void Construct(ActorMovement<ActorMovementConfig>.CustomDiFactory actorMovementsFactory, 
            AnimalManagerConfig animalManagerConfig, AnimalConfigList animalConfigs, 
            ActorInteraction.Factory actorInteractionFactory, UiSystem uiSystem)
        {
            _actorMovementsFactory = actorMovementsFactory;
            _animalManagerConfig = animalManagerConfig;
            _animalConfigs = animalConfigs;
            _actorInteractionFactory = actorInteractionFactory;
            _uiSystem = uiSystem;
        }

        public void SpawnAll()
        {
            var count = _animalManagerConfig.MaxAnimalCount;
            for (int i = 0; i < count; i++)
            {
                Spawn(Random.Range(0, _animalConfigs.AnimalConfigs.Count));
            }
        }

        private void Spawn(int index)
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
            
            var boxSize = _animalManagerConfig.SpawnBoxSize;
            var height = _animalManagerConfig.SpawnHeight;
            
            // TODO - to avoid initial collisions you can either save these positions
            // or disable collisions for 1-2 seconds after spawn
            actorMovement.gameObject.transform.position = 
                new Vector3(Random.Range(-boxSize, boxSize), height, Random.Range(-boxSize, boxSize));
            actorMovement.gameObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            
            actorMovement.gameObject.tag = animalConfig.Type switch
            {
                AnimalConfig.AnimalType.Pray => Constants.PreyTag,
                AnimalConfig.AnimalType.Predator => Constants.PredatorTag,
                _ => actorMovement.gameObject.tag
            };
            
            var actorInteraction = _actorInteractionFactory.Create<AnimalInteraction>(actorMovement.gameObject);

            if (animalConfig.Type == AnimalConfig.AnimalType.Predator)
            {
                _uiSystem.CreateActorUIView(actorMovement.gameObject, actorInteraction);
            }

            _actorMovements.Add(actorMovement);
        }
    }
}
