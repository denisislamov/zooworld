using System.Collections.Generic;
using Codice.CM.Common.Serialization;
using TMPro;
using UnityEngine;
using ZooWorld.Core;

namespace ZooWorld.UI
{
    public class UiSystem
    {
        private HashSet<ActorUiPresenter> _actorUiPresenters = new();
        private MainUiPresenter _mainUiPresenter;
        private MainUiPresenter.Factory _mainUiPresenterFactory;
        
        private UiSystemSettings _uiSystemSettings;
        
        public UiSystem(UiSystemSettings uiSystemSettings, MainUiPresenter.Factory mainUiPresenterFactory)
        {
            _uiSystemSettings = uiSystemSettings;
            _mainUiPresenterFactory = mainUiPresenterFactory;
        }
        
        public ActorUiView CreateActorUIView(GameObject target, ActorInteraction actorInteraction)
        {
            var actorUiView = GameObject.Instantiate(_uiSystemSettings.ActorUiViewPrefab, target.transform);
            var text = actorUiView.GetComponent<TMP_Text>();
            
            actorUiView.Init(actorInteraction, text);

            var actorUiPresenter = new ActorUiPresenter(actorUiView);
            actorUiPresenter.RegisterEvents();

            _actorUiPresenters.Add(actorUiPresenter);
            
            return actorUiView;
        }
        
        public void CreateMainUiView()
        {
            var mainUiView = GameObject.Instantiate(_uiSystemSettings.MainUiViewPrefab);
            
            var mainUiModel = new MainUiModel();
            _mainUiPresenter = _mainUiPresenterFactory.Create(mainUiView, mainUiModel);
            _mainUiPresenter.RegisterEvents();
        }
    }
}
