using UnityEngine;

namespace ZooWorld.Core
{
    public class LinearMovement : ActorMovement<Configs.LinearMovementConfig>
    {
        private float _speed = 1.0f;
        
        [SerializeField] private bool _shouldRotate;
        [SerializeField] private float _rotationSpeed = 5.0f;
        
        private readonly float _timeToChangeDirection = 4.0f;
        private float _elapsedTimeToChangeDirection;

        protected override void Awake()
        {
            base.Awake();
            _speed = Config.Speed;
        }
        
        public override void Move()
        {
            CurrentRigidbody.velocity = transform.forward * _speed;
            
            _elapsedTimeToChangeDirection += Time.fixedDeltaTime;
            if (_shouldRotate && _elapsedTimeToChangeDirection > _timeToChangeDirection)
            {
                Debug.Log("Change direction");
                bool leftOrRight = Random.value > 0.5f;
                Vector3 rotationDirection = leftOrRight ? -transform.up : transform.up;
                
                CurrentRigidbody.AddRelativeTorque(rotationDirection * _rotationSpeed, ForceMode.Impulse);
                _elapsedTimeToChangeDirection = 0.0f;
            }
        }
    }
}
