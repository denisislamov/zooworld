using UnityEngine;

namespace ZooWorld.Core.Configs
{
    [CreateAssetMenu(fileName = "JumpingMovementConfig", menuName = "ZooWorld/JumpingMovementConfig")]
    public class JumpingMovementConfig : ActorMovementConfig
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _pauseBetweenJumps;

        public float Distance => _distance;
        public float PauseBetweenJumps => _pauseBetweenJumps;
    }
}
    