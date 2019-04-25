using UnityEngine;

namespace Assets.Scripts.SceneObjects.Obstacles
{
    public class VerticalDynamicObstacle : BaseDynamicObstacle
    {
        protected override void SetStartEndPosition(Vector3 cellPosition)
        {
            m_StartPosition = new Vector3(cellPosition.x, cellPosition.y + m_SpawnCell / 4, cellPosition.z);
            m_EndPosition = new Vector3(cellPosition.x, cellPosition.y - m_SpawnCell / 4, cellPosition.z);
        }

        protected override void SetScale()
        {
            transform.localScale = new Vector3(1, m_SpawnCell / 2, 1);
        }

        protected override void OffsetPosition()
        {
            float offcet = Random.Range(-m_SpawnCell / 4, m_SpawnCell / 4);

            transform.position = new Vector3(transform.position.x, transform.position.y + offcet, transform.position.z);
        }
    }
}
