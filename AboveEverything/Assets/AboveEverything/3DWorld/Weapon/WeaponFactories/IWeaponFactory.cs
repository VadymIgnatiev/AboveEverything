using Zenject;
using static Assets.Scripts.SceneObjects.Weapon.Bullets.Bullet;

namespace Assets.Scripts.SceneObjects.Weapon.WeaponFactories
{
    public interface IWeaponFactory : IFactory<IWeapon>
    {
    }
}
