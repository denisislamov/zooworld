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
                Interact(interactable);
            }
        }

        public abstract void Interact(IInteractable interactable);
    }
}