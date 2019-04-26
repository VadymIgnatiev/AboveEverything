using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    [Serializable]
    public class ObstacleSettings
    {
        public float Speed;                
        public GameObject HorizontalDynamicObstaclePrefab;
        public GameObject HorizontalStaticObstaclePrefab;
        public GameObject VerticalDynamicObstaclePrefab;
        public GameObject VerticalStaticObstaclePrefab;
    }
}
