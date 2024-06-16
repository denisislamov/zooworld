using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ZooWorld.Core;

namespace ZooWorld.UI
{
    
    public class UiSystem
    {
        private HashSet<ActorUiPresenter> actorUiPresenters = new();
        public ActorUiView CreateActorUIView(GameObject target, ActorInteraction actorInteraction, TMP_Text text)
        {
            var actorUiView = target.AddComponent<ActorUiView>();
            
            if (actorUiView == null)
            {
                return null;
            }
            
            actorUiView.Init(actorInteraction, text);

            var actorUiPresenter = new ActorUiPresenter(actorUiView);
            actorUiPresenter.RegisterEvents();

            actorUiPresenters.Add(actorUiPresenter);
            
            return actorUiView;
        }
    }
}
