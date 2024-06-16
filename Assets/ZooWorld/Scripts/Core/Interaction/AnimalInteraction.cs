using System;
using UnityEngine;
using Zenject;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.Core
{
    public class AnimalInteraction : ActorInteraction
    {
        private Rigidbody _rigidbody;
        public Rigidbody Rigidbody => _rigidbody;
        
        private Collider _collider;
        public Collider Collider => _collider;
        
        private IInteractionsSystem _interactionsSystem;

        [Inject]
        public void Construct(IInteractionsSystem interactionsSystem)
        {
            _interactionsSystem = interactionsSystem;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public override void Interact(IInteractable interactable, IInteractable.InteractionType interactionType = IInteractable.InteractionType.None)
        {
            if (interactionType != IInteractable.InteractionType.Collider)
            {
                return;
            }
            
            if (interactable is not AnimalInteraction || 
                !gameObject.CompareTag(Constants.PredatorTag))
            {
                return;
            }
            
            var actorInteraction = (ActorInteraction)interactable;
            
            if (actorInteraction.gameObject.CompareTag(Constants.PreyTag))
            {
                actorInteraction.gameObject.SetActive(false);
                return;
            }
            
            if (actorInteraction.gameObject.CompareTag(Constants.PredatorTag))
            {
                if (_interactionsSystem.IsAlreadyInteracted(gameObject, actorInteraction))
                {
                    actorInteraction.gameObject.SetActive(false);
                }
            }
        }
    }
}