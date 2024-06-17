using UnityEngine;

namespace ZooWorld.Core.Configs
{
    [CreateAssetMenu(fileName = "LinearMovementConfig", menuName = "ZooWorld/LinearMovementConfig")]
    public class LinearMovementConfig : ActorMovementConfig
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}