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
        
        public void Init()
        {
            var go = GameObject.Instantiate(MovementPrefab.gameObject);
            var actorMovement = go.GetComponent<ActorMovement<ActorMovementConfig>>();
            actorMovement.SetConfig(ActorMovementConfig);

            actorMovement.gameObject.tag = Type switch
            {
                AnimalType.Pray => Constants.PreyTag,
                AnimalType.Predator => Constants.PredatorTag,
                _ => actorMovement.gameObject.tag
            };
            
            go.AddComponent<AnimalInteraction>();
            
        }
    }
}
