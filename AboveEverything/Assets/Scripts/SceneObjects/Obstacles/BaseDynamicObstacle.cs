using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public abstract class BaseDynamicObstacle : MonoBehaviour, IObstacle
    {
        private ObstacleSettings m_ObstacleSettings;

        protected float m_SpawnCell;
        protected float m_Speed;
        public bool m_FromStartToEnd;
        public bool m_FromEndToStart;
        protected Vector3 m_StartPosition;
        protected Vector3 m_EndPosition;

        public Transform m_Transform { get { return transform; } }        

        public virtual void Init(ObstacleSettings obstacleSettings, Vector3 cellPosition)
        {
            m_ObstacleSettings = obstacleSettings;
            m_SpawnCell = m_ObstacleSettings.SpawnCellSize;
            m_Speed = m_ObstacleSettings.Speed;

            OffsetPosition();
            SetStartEndPosition(cellPosition);
            SetScale();

            int initDirection = Random.Range(0, 2);            

            m_FromEndToStart = initDirection == 0 ? true : false;
            m_FromStartToEnd = initDirection == 0 ? false : true;
        }

        protected abstract void SetStartEndPosition(Vector3 cellPosition);

        protected abstract void OffsetPosition();

        protected void ChangeOrientation()
        {
            m_FromEndToStart = !m_FromEndToStart;
            m_FromStartToEnd = !m_FromStartToEnd;
        }
        
        protected abstract void SetScale();

        public void Update()
        {
            if (m_FromStartToEnd)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_EndPosition, m_Speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, m_EndPosition) < 0.001)
                {
                    ChangeOrientation();
                }
            }

            if (m_FromEndToStart)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_StartPosition, m_Speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, m_StartPosition) < 0.001)
                {
                    ChangeOrientation();
                }
            }
        }
    }
}
