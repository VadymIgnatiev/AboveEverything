using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    [Serializable]
    public class ObstacleSettings
    {
        public float Speed;     
        
        public GameObject HorizontalDynamicObstaclePrefab;
        public float HorizontalDynamicObstacleDamege;

        public GameObject HorizontalStaticObstaclePrefab;
        public float HorizontalStaticObstacleDamage;

        public GameObject VerticalDynamicObstaclePrefab;
        public float VerticalDynamicObstacleDamage;

        public GameObject VerticalStaticObstaclePrefab;
        public float VerticalStaticObstacleDamage;
    }
}
