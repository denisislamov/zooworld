using UnityEngine;

namespace ZooWorld.Core
{
    public class JumpMovement : ActorMovement<Configs.JumpingMovementConfig>
    {
        private float _distance = 2.0f;
        private float _pauseBetweenJumps = 2.0f;
        
        [SerializeField] private bool _shouldRotate;
        [SerializeField] private float _rotationSpeed = 5.0f;
        
        private const float ChanceToRotate = 0.05f;
        private float _elapsedTimeToJump;
        private bool _alreadyRotate;
        
        protected override void Awake()
        {
            base.Awake();
            _distance = Config.Distance;
            _pauseBetweenJumps = Config.PauseBetweenJumps;
            _elapsedTimeToJump = _pauseBetweenJumps;
        }
        
        public override void Move()
        {
            _elapsedTimeToJump += Time.fixedDeltaTime;
            if (_elapsedTimeToJump > _pauseBetweenJumps)
            {
                JumpToTarget(transform.position + transform.forward * _distance);
                _elapsedTimeToJump = 0.0f;
                _alreadyRotate = false;
                
                return;
            }
            
            if (!_alreadyRotate && _shouldRotate)
            {
                if (!(Random.Range(0.0f, 1.0f) < ChanceToRotate))
                {
                    return;
                }

                if (!isGrounded())
                {
                    return;
                }
                
                bool leftOrRight = Random.value > 0.5f;
                Vector3 rotationDirection = leftOrRight ? -transform.up : transform.up;
                CurrentRigidbody.AddRelativeTorque(rotationDirection * _rotationSpeed , ForceMode.Impulse);
                _alreadyRotate = true;
            }
        }

        private const float InitialAngle = 45.0f;
        
        private void JumpToTarget(Vector3 target)
        {
            float gravity = Physics.gravity.magnitude;
            float angle = InitialAngle * Mathf.Deg2Rad;
 
            Vector3 planarTarget = new Vector3(target.x, 0, target.z);
            Vector3 planarPosition = new Vector3(transform.position.x, 0, transform.position.z);
 
            float distance = Vector3.Distance(planarTarget, planarPosition);
            float yOffset = transform.position.y - target.y;
            float initialVelocity = 1 / Mathf.Cos(angle) * Mathf.Sqrt(0.5f * gravity * Mathf.Pow(distance, 2) /
                                                                      (distance * Mathf.Tan(angle) + yOffset));
            Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));
            float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPosition);
            Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
            
            CurrentRigidbody.AddForce(finalVelocity * CurrentRigidbody.mass, ForceMode.Impulse);
        }
        
        private bool isGrounded() => Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }
}