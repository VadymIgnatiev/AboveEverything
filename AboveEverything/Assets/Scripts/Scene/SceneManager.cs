using Assets.Scripts.Scene.Level;
using Assets.Scripts.SceneObjects.SceneCamera;
using Assets.Scripts.SceneObjects.Character;
using Zenject;

namespace Assets.Scripts.Scene
{
    public class SceneManager
    {
        [Inject]
        private LevelWindow m_LevelWindow { get; set; }

        [Inject]
        private ICameraFacade m_CameraFacade { get; set; }

        [Inject]
        private ICharacterFacade m_CharacterFacade { get; set; }

        public void Init()
        {           
            m_CameraFacade.SetTargetTransform(m_CharacterFacade.Transform);
        }
    }
}
