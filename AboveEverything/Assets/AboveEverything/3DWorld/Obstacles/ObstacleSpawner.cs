using Assets.Scripts.SceneObjects.Obstacles.Factories;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public class ObstacleSpawner : IObstacleSpawner
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
        

        public void Init()
        {
            m_ObstacleFactories = new List<IObstacleFactory>();
            m_ObstacleFactories.Add(HorizontalDynamicObstacleFactory);
            m_ObstacleFactories.Add(HorizontalStaticObstacleFactory);
            m_ObstacleFactories.Add(VerticalDynamicObstacleFactory);
            m_ObstacleFactories.Add(VerticalStaticObstacleFactory);
        }

        public void SpawnObstacleInCell(Vector3 cellPosition)
        {
            int index = Random.Range(0, m_ObstacleFactories.Count);
            IObstacleFactory obstacleFactory = m_ObstacleFactories[index];
            obstacleFactory.Create(cellPosition);
        }
    }
}
