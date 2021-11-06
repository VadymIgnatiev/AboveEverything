using Assets.Scripts.Scene.Level;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Obstacles.Factories
{
    public abstract class BaseObstacleFactory : IObstacleFactory
    {
        [Inject]
        protected ObstacleSettings m_ObstacleSettings;

        [Inject]
        protected LevelSettings m_LevelSettings;

        public abstract IObstacle Create(Vector3 cellPosition);

        protected abstract Vector3 GetPosition(Vector3 cellPosition);        
    }
}
