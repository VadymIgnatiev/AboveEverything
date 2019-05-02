using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Weapon.Bullets
{
    public class Bullet : MonoBehaviour, IPoolable<float, float, IMemoryPool>
    {
        private float m_StartTime;
        private float m_Speed;
        private float m_LifeTime;

        private IMemoryPool m_Pool;

        public Vector3 MoveDirection
        {
            get { return transform.right; }
        }

        public void OnTriggerEnter(Collider other)
        {
            /*
            var enemyView = other.GetComponent<EnemyView>();

            if (enemyView != null && _type == BulletTypes.FromPlayer)
            {
                enemyView.Facade.Die();
                _pool.Despawn(this);
            }
            else
            {
                var player = other.GetComponent<PlayerFacade>();

                if (player != null && _type == BulletTypes.FromEnemy)
                {
                    player.TakeDamage(MoveDirection);
                    _pool.Despawn(this);
                }
            }*/
        }

        public void Update()
        {
            transform.position += transform.up * m_Speed * Time.deltaTime;

            if (Time.realtimeSinceStartup - m_StartTime > m_LifeTime)
            {
                m_Pool.Despawn(this);
            }
        }

        public void OnSpawned(float speed, float lifeTime, IMemoryPool pool)
        {
            m_Pool = pool;            
            m_Speed = speed;
            m_LifeTime = lifeTime;            

            m_StartTime = Time.realtimeSinceStartup;
        }

        public void OnDespawned()
        {
            m_Pool = null;
        }

        public abstract class BaseBulletFactory : PlaceholderFactory<float, float, Bullet> { }


        public class BulletFactoryOne : BaseBulletFactory
        {
        }

        public class BulletFactoryTwo : BaseBulletFactory
        {
        }

        public class BulletFactoryThree : BaseBulletFactory
        {
        }        
    }
}
