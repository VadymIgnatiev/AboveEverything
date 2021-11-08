using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public interface IObstacleSpawner
    {
        void Init();
        void SpawnObstacleInCell(Vector3 cellPosition);
    }
}
