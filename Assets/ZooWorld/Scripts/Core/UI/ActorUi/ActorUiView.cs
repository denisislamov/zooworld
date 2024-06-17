using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using ZooWorld.Core;
using ZooWorld.Core.Interfaces;

namespace ZooWorld.UI
{
    public class ActorUiView : BaseView
    {
        private ActorInteraction _actorInteraction;
        private TMP_Text _text;
        
        public void Init(ActorInteraction actorInteraction, TMP_Text text)
        {
            _actorInteraction = actorInteraction;
            _text = text;
            
            _text.gameObject.SetActive(false);
            _actorInteraction.OnInteract += OnInteract;
        }
        
        public event Action OnActorInteraction = () => { };
        
        private void OnInteract(IInteractable arg1, IInteractable.InteractionType arg2)
        {
            if (arg1 is AnimalInteraction && arg2 == IInteractable.InteractionType.Collider)
            {
                OnActorInteraction();
            }
        }
        
        public async UniTask ShowText()
        {
            _text.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(2.0f), ignoreTimeScale: false);
            _text.gameObject.SetActive(false);
        }
    }
}
