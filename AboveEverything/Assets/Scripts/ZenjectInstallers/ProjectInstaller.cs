using Assets.Scripts.Scene.Level;
using Assets.Scripts.SceneObjects.Obstacles;
using Assets.Scripts.SceneObjects.Obstacles.Factories;
using Assets.Scripts.SceneObjects.SceneCamera;
using Assets.Scripts.SceneObjects.Ñharacter;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            #region Obstacles
            Container.Bind<IObstacleFactory>().WithId(FactoryType.HorizontalDynamicObstacleFactory).To<HorizontalDynamicObstacleFactory>().AsSingle();
            Container.Bind<IObstacleFactory>().WithId(FactoryType.HorizontalStaticObstacleFactory).To<HorizontalStaticObstacleFactory>().AsSingle();
            Container.Bind<IObstacleFactory>().WithId(FactoryType.VerticalDynamicObstacleFactory).To<VerticalDynamicObstacleFactory>().AsSingle();
            Container.Bind<IObstacleFactory>().WithId(FactoryType.VerticalStaticObstacleFactory).To<VerticalStaticObstacleFactory>().AsSingle();
            Container.Bind<IObstacleSpawner>().To<ObstacleSpawner>().AsSingle();
            #endregion

            #region Scene
            Container.Bind<LevelWindow>().AsSingle();
            Container.Bind<ICameraFacade>().FromComponentInHierarchy().AsSingle();
            #endregion

            #region
            Container.Bind<ICharacterFacade>().To<CharacterFacade>().AsSingle();
            #endregion
        }
    }
}
