using ZooWorld.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace ZooWorld.Core
{
    public class ActorInteraction : MonoBehaviour, IInteractable
    {
        [Inject] protected InteractionsSystem InteractionsSystem;
        public event System.Action<IInteractable, IInteractable.InteractionType> OnInteract = (_, _) => { };
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out IInteractable interactable))
            {
                return;
            }
            
            Interact(interactable, IInteractable.InteractionType.Collider);
            OnInteract(interactable, IInteractable.InteractionType.Collider);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
            {
                return;
            }
            
            Interact(interactable,  IInteractable.InteractionType.Trigger);
            OnInteract(interactable, IInteractable.InteractionType.Collider);
        }

        public virtual void Interact(IInteractable interactable,
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