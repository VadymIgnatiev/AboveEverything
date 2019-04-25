using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Camera
{
    public class CameraFacade : MonoBehaviour
    {
        private Transform m_TargetTransform;
        
        public void SetTargetTransform(Transform targetTransform)
        {
            m_TargetTransform = targetTransform;     
        }

        public void LateUpdate()
        {
            transform.LookAt(m_TargetTransform);
        }
    }
}
