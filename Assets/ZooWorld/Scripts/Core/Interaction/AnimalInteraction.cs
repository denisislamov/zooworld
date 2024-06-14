using ZooWorld.Core.Interfaces;

namespace ZooWorld.Core
{
    public class AnimalInteraction : ActorInteraction
    {
        public override void Interact(IInteractable interactable)
        {
            if (interactable is not AnimalInteraction || !gameObject.CompareTag(Constants.PredatorTag))
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
                if (InteractionsSystem.IsAlreadyInteracted(gameObject, actorInteraction))
                {
                    actorInteraction.gameObject.SetActive(false);
                }
            }
        }
    }
}