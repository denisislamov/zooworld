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
        private ActorUiPresenter.Factory _actorUiPresenterFactory;
        
        private UiSystemSettings _uiSystemSettings;
        
        public UiSystem(UiSystemSettings uiSystemSettings, MainUiPresenter.Factory mainUiPresenterFactory,
            ActorUiPresenter.Factory actorUiPresenterFactory)
        {
            _uiSystemSettings = uiSystemSettings;
            _mainUiPresenterFactory = mainUiPresenterFactory;
            _actorUiPresenterFactory = actorUiPresenterFactory;
        }
        
        public void CreateActorUIView(GameObject target, ActorInteraction actorInteraction)
        {
            var actorUiView = GameObject.Instantiate(_uiSystemSettings.ActorUiViewPrefab, target.transform);
            var text = actorUiView.GetComponent<TMP_Text>();
            
            actorUiView.Init(text);

            var actorUiPresenter = _actorUiPresenterFactory.Create(actorUiView, actorInteraction);
            actorUiPresenter.RegisterEvents();

            _actorUiPresenters.Add(actorUiPresenter);
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
