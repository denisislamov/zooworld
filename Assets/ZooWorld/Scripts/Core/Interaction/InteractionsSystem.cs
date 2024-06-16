using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.Core
{
    public class InteractionsSystem : IInteractionsSystem
    {
        private readonly HashSet<GameObject> AlreadyMarkedForDestroy = new();

        public bool IsAlreadyInteracted(GameObject srcGameObject, ActorInteraction animalInteraction)
        {
            return AlreadyMarkedForDestroy.Contains(srcGameObject) || 
                   !AlreadyMarkedForDestroy.Add(animalInteraction.gameObject);
        }
    }

    public interface IInteractionsSystem
    {
        public bool IsAlreadyInteracted(GameObject srcGameObject, ActorInteraction animalInteraction);
    }
}
