using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    [Serializable]
    public class ObstacleSettings
    {
        public float SpawnCellSize;        
        public float Speed;
        public int CellsQuantityInRow;
        public int InitCellsQuantityInHeight;
        public Vector3 InitSpawnerPosition;
        public GameObject HorizontalDynamicObstaclePrefab;
        public GameObject HorizontalStaticObstaclePrefab;
        public GameObject VerticalDynamicObstaclePrefab;
        public GameObject VerticalStaticObstaclePrefab;
    }
}
