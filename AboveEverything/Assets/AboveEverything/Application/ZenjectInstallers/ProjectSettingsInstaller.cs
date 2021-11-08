using Assets.Scripts.Scene.Level;
using Assets.Scripts.SceneObjects.Character;
using Assets.Scripts.SceneObjects.Monsters;
using Assets.Scripts.SceneObjects.Obstacles;
using Assets.Scripts.SceneObjects.SceneCamera;
using Assets.Scripts.SceneObjects.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    [CreateAssetMenu(fileName = "ProjectSettingsInstaller", menuName = "Create ProjectSettings")]
    public class ProjectSettingsInstaller : ScriptableObjectInstaller<ProjectSettingsInstaller>
    {
        public ObstacleSettings ObstacleSettings;
        public LevelSettings LevelSettings;
        public CharacterSettings CharacterSettings;
        public WeaponSettings WeaponSettings;
        public CameraSettings CameraSettings;
        public MonstersSettings MonstersSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(ObstacleSettings).IfNotBound();
            Container.BindInstance(LevelSettings).IfNotBound();
            Container.BindInstance(CharacterSettings).IfNotBound();
            Container.BindInstance(WeaponSettings).IfNotBound();
            Container.BindInstance(CameraSettings).IfNotBound();
            Container.BindInstance(MonstersSettings).IfNotBound();
        }
    }
}
