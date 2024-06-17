using UnityEngine;

namespace ZooWorld.UI
{
    [CreateAssetMenu(fileName = "UiSystemSettings", menuName = "ZooWorld/UiSystemSettings", order = 1)]
    public class UiSystemSettings : ScriptableObject
    {
        public ActorUiView ActorUiViewPrefab;
        public MainUiView MainUiViewPrefab;
    }
}