using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public interface IObstacle
    {
        Transform m_Transform { get; }
        void Init(ObstacleSettings obstacleSettings, Vector3 cellPosition, float spawnCellSize);
    }
}
