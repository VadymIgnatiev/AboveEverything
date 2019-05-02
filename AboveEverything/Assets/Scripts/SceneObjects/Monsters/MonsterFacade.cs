using UnityEngine;

namespace Assets.Scripts.SceneObjects.Monsters
{
    public class MonsterFacade : MonoBehaviour
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
    }
}
