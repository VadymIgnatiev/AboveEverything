using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles.Factories
{
    public abstract class BaseVerticalObstacleFactory : BaseObstacleFactory
    {
        protected override Vector3 GetPosition(Vector3 cellPosition)
        {
            float offcet = Random.Range(-m_ObstacleSettings.SpawnCellSize / 4, m_ObstacleSettings.SpawnCellSize / 4);

            Vector3 result = new Vector3(cellPosition.x, cellPosition.y + offcet, cellPosition.z);
            return result;
        }
    }
}
