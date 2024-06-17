using Zenject;
using ZooWorld.Core;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.UI
{
    public class ActorUiPresenter : BasePresenter<ActorUiView, BaseModel>
    {
        [Inject] private readonly InteractionsSystem _interactionsSystem;
        private ActorInteraction _actorInteraction;

        public ActorUiPresenter(ActorUiView view, ActorInteraction actorInteraction) : base(view, null)
        {
            _actorInteraction = actorInteraction;
        }

        private void OnActorInteraction()
        {
            _ = View.ShowText();
        }

        private void OnInteract(IInteractable arg1, IInteractable.InteractionType arg2)
        {
            if (_actorInteraction != (ActorInteraction)arg1)
            {
                return;
            }
            
            if (arg1 is AnimalInteraction && arg2 == IInteractable.InteractionType.Collider)
            {
                OnActorInteraction();
            }
        }
        
        public override void RegisterEvents()
        {
            _interactionsSystem.OnInteract += OnInteract;
        }

        public override void UnregisterEvents()
        {
            _interactionsSystem.OnInteract -= OnInteract;
        }
        
        public class Factory : PlaceholderFactory<ActorUiView, ActorInteraction, ActorUiPresenter>
        {
        }
    }
}