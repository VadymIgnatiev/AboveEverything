using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public class StaticObstacle : MonoBehaviour, IObstacle
    {
        public Transform m_Transform { get { return transform; } }

        public float Damage { get; set; }

        public void Init(ObstacleSettings obstacleSettings, Vector3 cellPosition, float spawnCellSize, float damage)
        {
            Damage = damage;
        }
    }
}
