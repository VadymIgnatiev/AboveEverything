using Assets.Scripts.Scene.Level;
using Assets.Scripts.SceneObjects.Obstacles;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    [CreateAssetMenu(fileName = "ProjectSettingsInstaller", menuName = "Create ProjectSettings")]
    public class ProjectSettingsInstaller : ScriptableObjectInstaller<ProjectSettingsInstaller>
    {
        public ObstacleSettings ObstacleSettings;
        public LevelSettings LevelSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(ObstacleSettings).IfNotBound();
            Container.BindInstance(LevelSettings).IfNotBound();
        }
    }
}
