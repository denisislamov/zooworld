
namespace ZooWorld.Core.Interfaces
{
   public interface IInteractable
   {
      enum InteractionType
      {
         None,
         Collider,
         Trigger
      }
      void Interact(IInteractable interactable, InteractionType interactionType = InteractionType.None);
   }
}
