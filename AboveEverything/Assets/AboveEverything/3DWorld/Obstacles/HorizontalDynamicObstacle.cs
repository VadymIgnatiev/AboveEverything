using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public class HorizontalDynamicObstacle : BaseDynamicObstacle
    {
        protected override void SetStartEndPosition(Vector3 cellPosition)
        {
            m_StartPosition = new Vector3(cellPosition.x - m_SpawnCell / 4, cellPosition.y, cellPosition.z);
            m_EndPosition = new Vector3(cellPosition.x + m_SpawnCell / 4, cellPosition.y, cellPosition.z);
        }

        protected override void SetScale()
        {
            transform.localScale = new Vector3(m_SpawnCell / 2, 1, 1);
        }

        protected override void OffsetPosition()
        {
            float offcet = Random.Range(-m_SpawnCell / 4, m_SpawnCell / 4);

            transform.position = new Vector3(transform.position.x + offcet, transform.position.y, transform.position.z);
        }
    }
}
