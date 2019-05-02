using Assets.Scripts.Scene.Level;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Scene
{
    public class SceneRunner : MonoBehaviour
    {
        [Inject]
        private LevelWindow m_LevelWindow;

        [Inject]
        private SceneManager m_SceneManager;

        public void Start()
        {
            m_LevelWindow.Init();
            m_SceneManager.Init();
        }
    }
}
