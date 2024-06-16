using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ZooWorld.Core.Configs;

namespace ZooWorld.Core
{
    [Serializable]
    public class AnimalConfig
    {
        public string Name;
        public enum AnimalType
        {
            None,
            Pray,
            Predator
        }
        
        public AnimalType Type;
        public GameObject MovementPrefab;
        public ActorMovementConfig ActorMovementConfig;
        public Color Color;
    }
}
