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
        
        private InteractionsSystem _interactionsSystem;

        [Inject]
        public void Construct(InteractionsSystem interactionsSystem)
        {
            _interactionsSystem = interactionsSystem;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public override void InteractWith(IInteractable interactable, 
            IInteractable.InteractionType interactionType = IInteractable.InteractionType.None)
        {
            if (interactionType != IInteractable.InteractionType.Collider ||
                interactable is not AnimalInteraction || 
                !gameObject.CompareTag(Constants.PredatorTag))
            {
                return;
            }
            
            var actorInteraction = (ActorInteraction)interactable;
            if (actorInteraction.gameObject.CompareTag(Constants.PreyTag))
            {
                actorInteraction.gameObject.SetActive(false);
                InteractionsSystem.InvokeOnDisableGo(actorInteraction.gameObject);
                return;
            }

            if (!actorInteraction.gameObject.CompareTag(Constants.PredatorTag) ||
                _interactionsSystem.IsAlreadyInteracted(gameObject, actorInteraction))
            {
                return;
            }
            
            actorInteraction.gameObject.SetActive(false);
            InteractionsSystem.InvokeOnDisableGo(actorInteraction.gameObject);
        }
    }
}