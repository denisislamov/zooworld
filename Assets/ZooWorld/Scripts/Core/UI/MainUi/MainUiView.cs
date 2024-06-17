using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ZooWorld.Core;

namespace ZooWorld.UI
{
    public class MainUiView : BaseView
    {
        [SerializeField] private TMP_Text _text;
        
        public void UpdateText(int preys, int predators)
        {
            _text.text = $"Preys: {preys}\nPredators: {predators}";
        }
    }
}