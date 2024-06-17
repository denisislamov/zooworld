using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.Core
{
    public class InteractionsSystem : IInteractionsSystem
    {
        public event System.Action<GameObject> OnDisableGo = _ => { };
        
        private readonly HashSet<GameObject> AlreadyMarkedForDestroy = new();

        public void InvokeOnDisableGo(GameObject value)
        {
            OnDisableGo(value);
        }

        public bool IsAlreadyInteracted(GameObject srcGameObject, ActorInteraction animalInteraction)
        {
            return AlreadyMarkedForDestroy.Contains(srcGameObject) || 
                   !AlreadyMarkedForDestroy.Add(animalInteraction.gameObject);
        }
    }

    public interface IInteractionsSystem
    {
        public event System.Action<GameObject> OnDisableGo;
        public void InvokeOnDisableGo(GameObject value);
        
        public bool IsAlreadyInteracted(GameObject srcGameObject, ActorInteraction animalInteraction);
    }
}
