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
        private TMP_Text _text;
        
        public void Init(TMP_Text text)
        {
            _text = text;
            _text.gameObject.SetActive(false);
        }
        
        public async UniTask ShowText()
        {
            _text.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(2.0f), ignoreTimeScale: false);
            _text.gameObject.SetActive(false);
        }
    }
}
