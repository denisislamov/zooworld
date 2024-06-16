using UnityEngine;
using Zenject;

namespace ZooWorld.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings _gameSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameSettings).AsSingle();
            Container.BindInstance(_gameSettings.AnimalConfigList).AsSingle();
            Container.BindInstance(_gameSettings.AnimalManagerConfig).AsSingle();
        }
    }
}