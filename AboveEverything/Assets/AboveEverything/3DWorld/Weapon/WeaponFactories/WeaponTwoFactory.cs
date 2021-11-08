using UnityEngine;
using Zenject;
using static Assets.Scripts.SceneObjects.Weapon.Bullets.Bullet;

namespace Assets.Scripts.SceneObjects.Weapon.WeaponFactories
{
    public class WeaponTwoFactory : BaseWeaponFactory
    {
        [Inject]
        protected BulletFactoryTwo m_BulletFactory;

        public override IWeapon Create()
        {
            GameObject gameObject = GameObject.Instantiate(m_Settings.Weapon2.Prefab);
            Weapon weapon = gameObject.GetComponent<Weapon>();
            weapon.Init(m_Settings.Weapon3, m_BulletFactory);
            return weapon;
        }
    }
}
