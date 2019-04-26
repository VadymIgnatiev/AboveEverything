using Assets.Scripts.SceneObjects.Сharacter;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.SceneCamera
{
    public class CameraFacade : MonoBehaviour, ICameraFacade
    {
        private Transform m_TargetTransform;
        private Camera m_Camera;
        private float m_YPreviousPosition;

        public float FieldOfView => m_Camera.fieldOfView;

        public float Aspect => m_Camera.aspect;

        public Transform Transform => transform;

        public event Action ChangedHeight = () => { };

        public void Start()
        {
            m_Camera = GetComponent<Camera>();
        }

        public void Update()
        {
            if (Math.Abs(m_Camera.transform.position.y - m_YPreviousPosition) < 0.001)
            {
                ChangedHeight();
            }
            m_YPreviousPosition = m_Camera.transform.position.y;
        }

        public void SetTargetTransform(Transform targetTransform)
        {
            m_TargetTransform = targetTransform;     
        }

        public void LateUpdate()
        {
            //m_Camera.transform.LookAt(m_TargetTransform);
        }
    }
}
