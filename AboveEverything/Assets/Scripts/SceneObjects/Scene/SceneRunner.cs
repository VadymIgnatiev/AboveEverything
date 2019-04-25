using Assets.Scripts.SceneObjects.Obstacles;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Scene
{
    public class SceneRunner : MonoBehaviour
    {
        [Inject]
        public ObstacleSpawner m_ObstacleSpawner;

        public void Start()
        {
            m_ObstacleSpawner.Init();
            m_ObstacleSpawner.InitScene();
        }
    }
}
