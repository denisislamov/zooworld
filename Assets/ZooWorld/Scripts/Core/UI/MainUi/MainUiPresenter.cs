using UnityEngine;
using Zenject;
using ZooWorld.Core;

namespace ZooWorld.UI
{
    public class MainUiPresenter : BasePresenter<MainUiView, MainUiModel>
    {
        [Inject] private readonly InteractionsSystem _interactionsSystem;

        public MainUiPresenter(MainUiView view, MainUiModel model) : base(view, model) { }

        public override void RegisterEvents()
        {
            _interactionsSystem.OnDisableGo += OnDisableGo;
        }

        private void OnDisableGo(GameObject obj)
        {
            if (obj.CompareTag(Constants.PreyTag))
            {
                Model.AddPrey(1);
            }
            else if (obj.CompareTag(Constants.PredatorTag))
            {
                Model.AddPredator(1);
            }
            View.UpdateText(Model.PreyKillCount, Model.PredatorKillCount);
        }

        public override void UnregisterEvents()
        {
            _interactionsSystem.OnDisableGo -= OnDisableGo;
        }
        
        public class Factory : PlaceholderFactory<MainUiView, MainUiModel, MainUiPresenter>
        {
        }
    }
}
