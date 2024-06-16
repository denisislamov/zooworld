using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.Core
{
    public abstract class ActorMovement<T> : MonoBehaviour, IMovable where T : Configs.ActorMovementConfig
    {
        [SerializeField] protected T Config;
        protected Rigidbody CurrentRigidbody { get; private set; }

        protected virtual void Awake()
        {
            CurrentRigidbody = GetComponent<Rigidbody>();
        }

        public void SetConfig(T config)
        {
            Config = config;
        }
        protected virtual void FixedUpdate()
        {
            Move();
        }
        
        public abstract void Move();
        
        
        public class CustomDiFactory 
        {
            private readonly DiContainer _container;
            private readonly List<Object> _prefabs;

            public CustomDiFactory(List<Object> prefabs, DiContainer container)
            {
                _container = container;
                _prefabs = prefabs;
            }

            public ActorMovement<T> Create<V>() where V : ActorMovement<T>
            {
                var prefab = _prefabs.OfType<V>().Single();
                return _container.InstantiatePrefabForComponent<V>(prefab);
            }
        }
    }
}