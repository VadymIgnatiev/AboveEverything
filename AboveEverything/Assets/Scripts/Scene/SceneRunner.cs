using Assets.Scripts.Scene.Level;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Scene
{
    public class SceneRunner : MonoBehaviour
    {
        [Inject]
        private LevelWindow LevelWindow;

        public void Start()
        {
            LevelWindow.Init();
        }
    }
}
