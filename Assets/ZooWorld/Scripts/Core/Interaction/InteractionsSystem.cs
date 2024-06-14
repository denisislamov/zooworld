using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.Core
{
    public static class InteractionsSystem
    {
        private static readonly HashSet<GameObject> AlreadyMarkedForDestroy = new();
        
        public static bool IsAlreadyInteracted(GameObject srcGameObject, ActorInteraction animalInteraction)
        {
            return AlreadyMarkedForDestroy.Contains(srcGameObject) || 
                   !AlreadyMarkedForDestroy.Add(animalInteraction.gameObject);
        }
    }
}
