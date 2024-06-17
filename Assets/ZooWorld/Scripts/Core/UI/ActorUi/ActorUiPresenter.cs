using UnityEngine;

namespace ZooWorld.UI
{
    public class ActorUiPresenter : BasePresenter<ActorUiView, BaseModel>
    {
        public ActorUiPresenter(ActorUiView view) : base(view, null) { }

        private void OnActorInteraction()
        {
            _ = View.ShowText();
        }

        public override void RegisterEvents()
        {
            View.OnActorInteraction += OnActorInteraction;
        }

        public override void UnregisterEvents()
        {
            View.OnActorInteraction -= OnActorInteraction;
        }
    }
}