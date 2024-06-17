using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.UI
{
    public abstract class BasePresenter<T, V>  where T : BaseView where V : BaseModel
    {
        public T View { get; private set; }
        public V Model { get; private set; }

        public BasePresenter(T view, V model)
        {
            View = view;
            Model = model;
        }

        public abstract void RegisterEvents();
        public abstract void UnregisterEvents();
    }
}
