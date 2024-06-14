using UnityEngine;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.Core
{
    public class BorderInteraction : ActorInteraction
    {
        enum BorderType
        {
            X,
            Z
        }
        
        [SerializeField] private BorderType _borderType;
        
        public override void Interact(IInteractable interactable, IInteractable.InteractionType interactionType = IInteractable.InteractionType.None)
        {
            if (interactionType != IInteractable.InteractionType.Trigger)
            {
                return;
            }
            
            var actorInteraction = (AnimalInteraction)interactable;
            if (!actorInteraction.gameObject.CompareTag(Constants.PreyTag) &&
                !actorInteraction.gameObject.CompareTag(Constants.PredatorTag))
            { 
                return;
            }
            
            var actorRigidbody = actorInteraction.Rigidbody;
            var position = actorRigidbody.position;
            
            // TODO: probably need to calculate biggest bounds size, not important for symmetric collider
            var boundsSize = actorInteraction.Collider.bounds.size;
            var maxSize = Mathf.Max(Mathf.Max(boundsSize.x, boundsSize.y), boundsSize.z);
            
            Debug.Log($"Position: {position}, Bounds size: {boundsSize}");
            
            actorRigidbody.position = _borderType switch
            {
                BorderType.X => new Vector3(-(position.x - Mathf.Sign(position.x) * maxSize), position.y, position.z),
                BorderType.Z => new Vector3(position.x, position.y,-(position.z - Mathf.Sign(position.z) * maxSize)),
                _ => actorInteraction.Rigidbody.position
            };
        }
    }
}
