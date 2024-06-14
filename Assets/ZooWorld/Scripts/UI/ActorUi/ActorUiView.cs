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
        [SerializeField] protected ActorInteraction ActorInteraction;
        [SerializeField] protected TMP_Text Text;
        
        public event Action OnActorInteraction = () => { };
        
        private void Awake()
        {
            Text.gameObject.SetActive(false);
            ActorInteraction.OnInteract += OnInteract;
        }

        private void OnInteract(IInteractable arg1, IInteractable.InteractionType arg2)
        {
            if (arg1 is AnimalInteraction && arg2 == IInteractable.InteractionType.Collider)
            {
                _ = ShowText();
            }
            
            OnActorInteraction();
        }
        
        public async UniTask ShowText()
        {
            Text.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(2.0f), ignoreTimeScale: false);
            Text.gameObject.SetActive(false);
        }
    }
}
