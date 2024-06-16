using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZooWorld.Core;
using ZooWorld.Core.Configs;

namespace ZooWorld.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject]
        GameSettings _settings = null;
        
        public JumpMovement JumpMovementPrefab;
        public LinearMovement LinearMovementPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<ActorMovement<ActorMovementConfig>.CustomDiFactory>().AsSingle();
            Container.Bind<UnityEngine.Object>()
                .FromInstance(JumpMovementPrefab)
                .WhenInjectedInto<ActorMovement<ActorMovementConfig>.CustomDiFactory>();
            Container.Bind<UnityEngine.Object>()
                .FromInstance(LinearMovementPrefab)
                .WhenInjectedInto<ActorMovement<ActorMovementConfig>.CustomDiFactory>();
        }
    }
    
    
    [Serializable]
    public class GameSettings
    {
        [SerializeField] private AnimalConfigList _animalConfigList;
        public AnimalConfigList AnimalConfigList => _animalConfigList;
    }
}
