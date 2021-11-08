using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Obstacles.Factories
{
    public interface IObstacleFactory : IFactory<Vector3, IObstacle> { }
}
