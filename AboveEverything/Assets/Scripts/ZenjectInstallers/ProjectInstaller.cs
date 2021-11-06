using Assets.Scripts.Scene;
using Assets.Scripts.Scene.Level;
using Assets.Scripts.SceneObjects.Character;
using Assets.Scripts.SceneObjects.Monsters;
using Assets.Scripts.SceneObjects.Obstacles;
using Assets.Scripts.SceneObjects.Obstacles.Factories;
using Assets.Scripts.SceneObjects.SceneCamera;
using Assets.Scripts.SceneObjects.Weapon;
using Assets.Scripts.SceneObjects.Weapon.Bullets;
using Assets.Scripts.SceneObjects.Weapon.WeaponFactories;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    public class ProjectInstaller : MonoInstaller
    {
        [Inject]
        private WeaponSettings m_WeaponSettings;

        [Inject]
        private MonstersSettings m_MonstersSettings;

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
            Container.Bind<SceneManager>().AsSingle();
            #endregion

            #region character
            Container.Bind<ICharacterFacade>().FromComponentInHierarchy().AsSingle();
            #endregion

            #region weapon
            Container.BindFactory<float, float, float, Bullet, Bullet.BulletFactoryOne>()               
               .FromPoolableMemoryPool<float, float, float, Bullet, BulletPool>(poolBinder => poolBinder                   
                   .WithInitialSize(20)                   
                   .FromComponentInNewPrefab(m_WeaponSettings.Weapon1.BulletPrefab)
                   .UnderTransformGroup("Bullets"));

            Container.BindFactory<float, float, float, Bullet, Bullet.BulletFactoryTwo>()
               .FromPoolableMemoryPool<float, float, float, Bullet, BulletPool>(poolBinder => poolBinder
                   .WithInitialSize(20)
                   .FromComponentInNewPrefab(m_WeaponSettings.Weapon2.BulletPrefab)
                   .UnderTransformGroup("Bullets"));

            Container.BindFactory<float, float, float, Bullet, Bullet.BulletFactoryThree>()
               .FromPoolableMemoryPool<float, float, float, Bullet, BulletPool>(poolBinder => poolBinder
                   .WithInitialSize(20)
                   .FromComponentInNewPrefab(m_WeaponSettings.Weapon3.BulletPrefab)
                   .UnderTransformGroup("Bullets"));

            Container.BindFactory<IWeapon, WeaponFactory>()
                .WithId(WeaponType.WeaponOne)
                .FromFactory<WeaponOneFactory>();

            Container.BindFactory<IWeapon, WeaponFactory>()
                .WithId(WeaponType.WeaponTwo)
                .FromFactory<WeaponTwoFactory>();

            Container.BindFactory<IWeapon, WeaponFactory>()
                .WithId(WeaponType.WeaponThree)
                .FromFactory<WeaponThreeFactory>();
            #endregion

            #region Monsters

            Container.Bind<MonsterSpawner>().AsSingle();

            Container.BindFactory<float, float, float, MonsterFacade, MonsterFacade.MonsterFactoryOne>()
               .FromPoolableMemoryPool<float, float, float, MonsterFacade, MonsterPool>(poolBinder => poolBinder
                   .WithInitialSize(20)
                   .FromComponentInNewPrefab(m_MonstersSettings.Monster0.MonsterPrefab)
                   .UnderTransformGroup("Monsters"));

            Container.BindFactory<float, float, float, MonsterFacade, MonsterFacade.MonsterFactoryTwo>()
               .FromPoolableMemoryPool<float, float, float, MonsterFacade, MonsterPool>(poolBinder => poolBinder
                   .WithInitialSize(20)
                   .FromComponentInNewPrefab(m_MonstersSettings.Monster1.MonsterPrefab)
                   .UnderTransformGroup("Monsters"));
            #endregion
        }
    }

    class BulletPool : MonoPoolableMemoryPool<float, float, float, IMemoryPool, Bullet>
    {
    }

    class MonsterPool : MonoPoolableMemoryPool<float, float, float, IMemoryPool, MonsterFacade>
    {
    }
}
