using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.Core
{
    public class InteractionsSystem
    {
        public event System.Action<GameObject> OnDisableGo = _ => { };
        private readonly HashSet<GameObject> _alreadyMarkedForDestroy = new();

        public void InvokeOnDisableGo(GameObject value)
        {
            OnDisableGo(value);
        }

        public bool IsAlreadyInteracted(GameObject srcGameObject, ActorInteraction animalInteraction)
        {
            return _alreadyMarkedForDestroy.Contains(srcGameObject) || 
                   !_alreadyMarkedForDestroy.Add(animalInteraction.gameObject);
        }
    }
}
