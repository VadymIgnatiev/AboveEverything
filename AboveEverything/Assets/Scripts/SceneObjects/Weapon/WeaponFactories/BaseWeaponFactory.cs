using Zenject;
using static Assets.Scripts.SceneObjects.Weapon.Bullets.Bullet;

namespace Assets.Scripts.SceneObjects.Weapon.WeaponFactories
{
    public abstract class BaseWeaponFactory : IWeaponFactory
    {
        [Inject]
        protected WeaponSettings m_Settings;        

        public abstract IWeapon Create();
    }
}
