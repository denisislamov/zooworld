using UnityEngine;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.Core
{
    public abstract class ActorMovement<T> : MonoBehaviour, IMovable where T : Configs.ActorMovementConfig
    {
        [SerializeField] protected T Config;
        protected Rigidbody CurrentRigidbody => _rigidbody;
        private Rigidbody _rigidbody;
        
        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        public abstract void Move();
    }
}