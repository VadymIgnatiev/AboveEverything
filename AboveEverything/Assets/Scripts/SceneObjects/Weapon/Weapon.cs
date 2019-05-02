using UnityEngine;
using static Assets.Scripts.SceneObjects.Weapon.Bullets.Bullet;

namespace Assets.Scripts.SceneObjects.Weapon
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        private WeaponSettings.Weapon m_Settings;
        private BaseBulletFactory m_BulletFactory;

        public Transform Transform => transform;

        public void Init(WeaponSettings.Weapon weaponSettings, BaseBulletFactory bulletFactory)
        {
            m_Settings = weaponSettings;
            m_BulletFactory = bulletFactory;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Fire()
        {
            var bullet = m_BulletFactory.Create(m_Settings.BulletSpeed, m_Settings.BulletLifeTime, m_Settings.Damage);

            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }        
    }
}
