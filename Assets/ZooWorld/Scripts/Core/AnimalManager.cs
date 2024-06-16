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
        private AnimalManagerConfig _animalManagerConfig;
        
        [Inject]
        public void Init(ActorMovement<ActorMovementConfig>.CustomDiFactory actorMovementsFactory, 
            AnimalManagerConfig animalManagerConfig, AnimalConfigList animalConfigs)
        {
            _actorMovementsFactory = actorMovementsFactory;
            _animalManagerConfig = animalManagerConfig;
            _animalConfigs = animalConfigs;
        }
        
        public IEnumerable<ActorMovement<ActorMovementConfig>> ActorMovements => _actorMovements;

        public void Start()
        {
            var count = _animalManagerConfig.MaxAnimalCount;
            for (int i = 0; i < count; i++)
            {
                Spawn(Random.Range(0, _animalConfigs.AnimalConfigs.Count));
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
            
            var radius = _animalManagerConfig.SpawnRadius;
            var height = _animalManagerConfig.SpawnHeight;
            
            // TODO - to avoid initial collisions you can either save these positions
            // or disable collisions for 1-2 seconds after spawn
            actorMovement.gameObject.transform.position = 
                new Vector3(Random.Range(-radius, radius), height, Random.Range(-radius, radius));
            actorMovement.gameObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            
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