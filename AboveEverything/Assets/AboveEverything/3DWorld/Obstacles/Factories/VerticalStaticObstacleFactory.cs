using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles.Factories
{
    public class VerticalStaticObstacleFactory : BaseVerticalObstacleFactory
    {
        public override IObstacle Create(Vector3 cellPosition)
        {
            GameObject obstacleObject = GameObject.Instantiate(m_ObstacleSettings.VerticalStaticObstaclePrefab);
            obstacleObject.transform.position = GetPosition(cellPosition);
            obstacleObject.transform.localScale = new Vector3(1, m_LevelSettings.SpawnCellSize / 2, 1);
            var obstacle = obstacleObject.GetComponent<IObstacle>();
            obstacle.Init(m_ObstacleSettings, cellPosition, m_LevelSettings.SpawnCellSize, m_ObstacleSettings.VerticalStaticObstacleDamage);
            return obstacle;
        }        
    }
}
