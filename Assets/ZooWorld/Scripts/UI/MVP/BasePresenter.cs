using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.UI
{
    public abstract class BasePresenter
    {
        public BaseView View { get; private set; }
        public BaseModel Model { get; private set; }

        public BasePresenter(BaseView view, BaseModel model)
        {
            View = view;
            Model = model;
        }

        public abstract void RegisterEvents();
        public abstract void UnregisterEvents();
    }
}
