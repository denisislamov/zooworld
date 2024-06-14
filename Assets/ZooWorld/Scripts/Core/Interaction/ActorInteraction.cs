using ZooWorld.Core.Interfaces;
using UnityEngine;

namespace ZooWorld.Core
{
    public abstract class ActorInteraction : MonoBehaviour, IInteractable
    {
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

        public abstract void Interact(IInteractable interactable, 
            IInteractable.InteractionType interactionType = IInteractable.InteractionType.None);
    }
}