using Zenject;
using ZooWorld.Core;
using ZooWorld.Core.Configs;
using ZooWorld.UI;

namespace ZooWorld.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject] private GameSettings _settings;
        public AnimalManager _animalManager;
        
        public override void InstallBindings()
        {
            InteractionsBinding();
            AnimalActorBinding();
            UiBinding();
        }

        private void InteractionsBinding()
        {
            Container.BindInterfacesAndSelfTo<InteractionsSystem>().AsSingle().NonLazy();
            Container.BindFactory<ActorInteraction, ActorInteraction.Factory>();
        }

        private void AnimalActorBinding()
        {
            Container.BindInterfacesAndSelfTo<AnimalManager>().FromInstance(_animalManager).AsSingle();
            Container.Bind<ActorMovement<ActorMovementConfig>.CustomDiFactory>().AsSingle();
            Container.Bind<UnityEngine.Object>()
                .FromInstance(_settings.AnimalConfigList.JumpMovementPrefab)
                .WhenInjectedInto<ActorMovement<ActorMovementConfig>.CustomDiFactory>();
            Container.Bind<UnityEngine.Object>()
                .FromInstance(_settings.AnimalConfigList.LinearMovementPrefab)
                .WhenInjectedInto<ActorMovement<ActorMovementConfig>.CustomDiFactory>();
        }

        private void UiBinding()
        {
            Container.BindInterfacesAndSelfTo<UiSystem>().AsSingle().NonLazy();
            Container.BindFactory<MainUiView, MainUiModel, MainUiPresenter, MainUiPresenter.Factory>();
        }
    }
}
