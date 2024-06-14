using ZooWorld.Core.Interfaces;
using UnityEngine;

namespace ZooWorld.Core
{
    public abstract class ActorInteraction : MonoBehaviour, IInteractable
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IInteractable interactable))
            {
                Interact(interactable, IInteractable.InteractionType.Collider);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                Interact(interactable,  IInteractable.InteractionType.Trigger);
            }
        }

        public abstract void Interact(IInteractable interactable, 
            IInteractable.InteractionType interactionType = IInteractable.InteractionType.None);
    }
}