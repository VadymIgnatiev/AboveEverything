using Assets.Scripts.SceneObjects.Obstacles.Factories;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public class ObstacleSpawner
    {
        [Inject]
        private ObstacleSettings m_ObstacleSettings;

        private List<IObstacleFactory> m_ObstacleFactories;

        [Inject(Id = FactoryType.HorizontalDynamicObstacleFactory)]
        private IObstacleFactory HorizontalDynamicObstacleFactory;

        [Inject(Id = FactoryType.HorizontalStaticObstacleFactory)]
        private IObstacleFactory HorizontalStaticObstacleFactory;

        [Inject(Id = FactoryType.VerticalDynamicObstacleFactory)]
        private IObstacleFactory VerticalDynamicObstacleFactory;

        [Inject(Id = FactoryType.VerticalStaticObstacleFactory)]
        private IObstacleFactory VerticalStaticObstacleFactory;

        private int m_CellQuantityInRow;
        private float m_SpawnCellSize;
        private Vector3 m_CurrentRowPosition;
        private int InitCellsQuantityInHeight;

        public void Init()
        {
            m_ObstacleFactories = new List<IObstacleFactory>();
            m_ObstacleFactories.Add(HorizontalDynamicObstacleFactory);
            m_ObstacleFactories.Add(HorizontalStaticObstacleFactory);
            m_ObstacleFactories.Add(VerticalDynamicObstacleFactory);
            m_ObstacleFactories.Add(VerticalStaticObstacleFactory);

            m_CellQuantityInRow = m_ObstacleSettings.CellsQuantityInRow;
            m_SpawnCellSize = m_ObstacleSettings.SpawnCellSize;
            m_CurrentRowPosition = m_ObstacleSettings.InitSpawnerPosition;
            InitCellsQuantityInHeight = m_ObstacleSettings.InitCellsQuantityInHeight;
        }

        public void InitScene()
        {
            for (int i = 0; i < InitCellsQuantityInHeight; i++)
            {
                MoveToNextRow();
                SpawnObstacles();                
            }
        }

        private void SpawnRowIfNeed(Vector3 target)
        {
            if (m_CurrentRowPosition.y - target.y < m_SpawnCellSize)
            {
                MoveToNextRow();
                SpawnObstacles();                
            }
        }

        private void MoveToNextRow()
        {
            m_CurrentRowPosition.y += m_SpawnCellSize;
        }

        private void SpawnObstacles()
        {
            for (int i = 0; i < m_CellQuantityInRow; i++)
            {
                int index = Random.Range(0, m_ObstacleFactories.Count);
                IObstacleFactory obstacleFactory = m_ObstacleFactories[index];

                Vector3 cellPosition = m_CurrentRowPosition;
                cellPosition.x += m_SpawnCellSize * i;
                obstacleFactory.Create(cellPosition);
            }
        }
    }
}
