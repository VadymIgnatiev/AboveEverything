using Assets.Scripts.SceneObjects.Damage;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Monsters
{
    public class MonsterFacade : MonoBehaviour, IDamageable, IPoolable<float, float, float, IMemoryPool>
    {
        public enum MonsterOrientetion
        {
            Forward,
            Left,
            Right
        }

        public Transform Transform => transform;

        [SerializeField]
        private Transform m_LeftForwardSensor;

        [SerializeField]
        private Transform m_RightForwardSensor;

        [SerializeField]
        private Transform m_LeftSensor;

        [SerializeField]
        private Transform m_RightSensor;

        private MonsterOrientetion Orientation = MonsterOrientetion.Forward;

        private IMemoryPool m_Pool;

        private float m_Damage;
        private float m_Helth;
        private float m_MovingSpeed;

        public void Init()
        {
            
        }

        public void Update()
        {
            if (Orientation == MonsterOrientetion.Forward 
                && DetectObstacle(m_LeftForwardSensor.position, m_LeftForwardSensor.up))
            {
                transform.rotation *= Quaternion.Euler(0, 0, -90);
                Orientation = MonsterOrientetion.Left;
            }

            if (Orientation == MonsterOrientetion.Forward
                && DetectObstacle(m_RightForwardSensor.position, m_RightForwardSensor.up))
            {
                transform.rotation *= Quaternion.Euler(0, 0, 90);
                Orientation = MonsterOrientetion.Right;
            }

            if (Orientation == MonsterOrientetion.Left
                && !DetectObstacle(m_LeftSensor.position, -m_LeftSensor.right))
            {
                transform.rotation *= Quaternion.Euler(0, 0, 90);
                Orientation = MonsterOrientetion.Forward;
            }

            if (Orientation == MonsterOrientetion.Right
                && !DetectObstacle(m_RightSensor.position, m_RightSensor.right))
            {
                transform.rotation *= Quaternion.Euler(0, 0, -90);
                Orientation = MonsterOrientetion.Forward;
            }

            transform.position += transform.up * Time.deltaTime * 1;
        }

        public bool DetectObstacle(Vector3 start, Vector3 direction)
        {
            RaycastHit hit;

            Debug.DrawRay(start, direction, Color.red, 1);

            if (Physics.Raycast(start, direction, out hit))
            {
                if (Vector3.Distance(start, hit.transform.position) < 1.5f)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public void TakeDamage(float damage)
        {
            m_Helth -= damage;

            if (m_Helth < 0)
            {
                m_Pool.Despawn(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            IDangerous dangerous = other.GetComponent<IDangerous>();

            if (dangerous == null) return;

            TakeDamage(dangerous.Damage);
        }

        public void OnDespawned()
        {
            m_Pool = null;
        }

        public void OnSpawned(float damage, float helth, float movingSpeed, IMemoryPool p1)
        {
            m_Pool = p1;
            m_Damage = damage;
            m_Helth = helth;
            m_MovingSpeed = movingSpeed;
        }

        public abstract class MonsterFactory : PlaceholderFactory<float, float, float, MonsterFacade> { }


        public class MonsterFactoryOne : MonsterFactory
        { 
        }

        public class MonsterFactoryTwo : MonsterFactory
        {
        }

    }
}
