using System;
using UnityEngine;
using Zenject;
using ZooWorld.Core;
using ZooWorld.Core.Configs;

namespace ZooWorld.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject] private GameSettings _settings;
        public AnimalManager _animalManager;
        
        public override void InstallBindings()
        {
            Container.Bind<IInteractionsSystem>().To<InteractionsSystem>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<AnimalManager>().FromInstance(_animalManager).AsSingle();
            
            Container.Bind<ActorMovement<ActorMovementConfig>.CustomDiFactory>().AsSingle();
            Container.Bind<UnityEngine.Object>()
                .FromInstance(_settings.AnimalConfigList.JumpMovementPrefab)
                .WhenInjectedInto<ActorMovement<ActorMovementConfig>.CustomDiFactory>();
            Container.Bind<UnityEngine.Object>()
                .FromInstance(_settings.AnimalConfigList.LinearMovementPrefab)
                .WhenInjectedInto<ActorMovement<ActorMovementConfig>.CustomDiFactory>();

            Container.BindFactory<ActorInteraction, ActorInteraction.Factory>();
        }
    }
    
    
    [Serializable]
    public class GameSettings
    {
        [SerializeField] private AnimalConfigList _animalConfigList;
        public AnimalConfigList AnimalConfigList => _animalConfigList;
        
        [SerializeField] private AnimalManagerConfig _animalManagerConfig;
        public AnimalManagerConfig AnimalManagerConfig => _animalManagerConfig;
    }
}
