using ZooWorld.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace ZooWorld.Core
{
    public class ActorInteraction : MonoBehaviour, IInteractable
    {
        [Inject] protected InteractionsSystem InteractionsSystem;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out IInteractable interactable))
            {
                return;
            }
            
            InteractWith(interactable, IInteractable.InteractionType.Collider);
            InteractionsSystem.InvokeOnInteract(this, IInteractable.InteractionType.Collider);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
            {
                return;
            }
            
            InteractWith(interactable,  IInteractable.InteractionType.Trigger);
            InteractionsSystem.InvokeOnInteract(this, IInteractable.InteractionType.Trigger);
        }

        public virtual void InteractWith(IInteractable interactable,
            IInteractable.InteractionType interactionType = IInteractable.InteractionType.None)
        {
        }

        public class Factory : PlaceholderFactory<ActorInteraction>
        {
            readonly DiContainer _container;

            public Factory(DiContainer container)
            {
                _container = container;
            }
            
            public ActorInteraction Create<T>(GameObject prefab) where T : ActorInteraction
            {
                return _container.InstantiateComponent<T>(prefab);
            }
        }
    }
}