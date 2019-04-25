using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles.Factories
{
    public abstract class BaseHorisontalObstacleFactory : BaseObstacleFactory
    {
        protected override Vector3 GetPosition(Vector3 cellPosition)
        {
            float offcet = Random.Range(-m_ObstacleSettings.SpawnCellSize / 4, m_ObstacleSettings.SpawnCellSize / 4);

            Vector3 result = new Vector3(cellPosition.x + offcet, cellPosition.y, cellPosition.z);
            return result;
        }
    }
}
