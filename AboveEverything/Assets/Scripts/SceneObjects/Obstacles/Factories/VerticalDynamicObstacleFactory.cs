using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles.Factories
{
    public class VerticalDynamicObstacleFactory : BaseVerticalObstacleFactory
    {
        public override IObstacle Create(Vector3 cellPosition)
        {
            GameObject obstacleObject = GameObject.Instantiate(m_ObstacleSettings.VerticalDynamicObstaclePrefab);
            obstacleObject.transform.position = GetPosition(cellPosition);
            obstacleObject.transform.localScale = new Vector3(1, m_ObstacleSettings.SpawnCellSize / 2, 1);
            IObstacle obstacle = obstacleObject.GetComponent<IObstacle>();
            obstacle.Init(m_ObstacleSettings, cellPosition);
            return obstacle;
        }
    }
}
