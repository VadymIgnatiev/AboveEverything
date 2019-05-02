using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.SceneCamera
{
    public class CameraFacade : MonoBehaviour, ICameraFacade
    {
        public Camera m_Camera;
        private Transform m_TargetTransform;        
        private float m_YPreviousPosition;

        public float FieldOfView => m_Camera.fieldOfView;

        public float Aspect => m_Camera.aspect;

        public Transform Transform => transform;

        public event Action ChangedHeight = () => { };

        [Inject]
        private CameraSettings m_CameraSettings;

        public void Start()
        {
            m_YPreviousPosition = m_Camera.transform.position.y;
        }

        public void SetTargetTransform(Transform targetTransform)
        {
            m_TargetTransform = targetTransform;     
        }

        public void LateUpdate()
        {
            if (m_TargetTransform.position.y > m_CameraSettings.MinCameraHeight)
            {
                float x = m_Camera.transform.position.x;
                float y = m_TargetTransform.position.y;
                float z = m_Camera.transform.position.z;
                m_Camera.transform.position = new Vector3(x, y, z);
            }

            if (Math.Abs(m_Camera.transform.position.y - m_YPreviousPosition) > 0.001)
            {
                ChangedHeight();
            }
            m_YPreviousPosition = m_Camera.transform.position.y;
        }
    }
}
