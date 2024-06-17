using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZooWorld.Core;
using ZooWorld.UI;

namespace ZooWorld.Core
{
    public class Bootstrap : MonoBehaviour
    {
        private AnimalSpawnSystem _animalSpawnSystem;
        private UiSystem _uiSystem;

        [Inject]
        public void Construct(AnimalSpawnSystem animalSpawnSystem, UiSystem uiSystem)
        {
            _animalSpawnSystem = animalSpawnSystem;
            _uiSystem = uiSystem;
        }
        
        public void Start()
        {
            _animalSpawnSystem.SpawnAll();
            _uiSystem.CreateMainUiView();
        }
    }
}
