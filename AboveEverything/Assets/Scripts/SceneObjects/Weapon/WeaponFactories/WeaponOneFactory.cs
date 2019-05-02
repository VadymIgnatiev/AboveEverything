using UnityEngine;
using Zenject;
using static Assets.Scripts.SceneObjects.Weapon.Bullets.Bullet;

namespace Assets.Scripts.SceneObjects.Weapon.WeaponFactories
{
    public class WeaponOneFactory : BaseWeaponFactory
    {
        [Inject]
        protected BulletFactoryOne m_BulletFactory;

        public override IWeapon Create()
        {
            GameObject gameObject = GameObject.Instantiate(m_Settings.Weapon1.Prefab);
            Weapon weapon = gameObject.GetComponent<Weapon>();
            weapon.Init(m_Settings.Weapon1, m_BulletFactory);
            return weapon;
        }
    }
}
