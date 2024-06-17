using UnityEngine;
using Zenject;
using ZooWorld.UI;

namespace ZooWorld.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private UiSystemSettings _uiSystemSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameSettings).AsSingle();
            Container.BindInstance(_gameSettings.AnimalConfigList).AsSingle();
            Container.BindInstance(_gameSettings.AnimalManagerConfig).AsSingle();
            Container.BindInstance(_uiSystemSettings).AsSingle();
        }
    }
}