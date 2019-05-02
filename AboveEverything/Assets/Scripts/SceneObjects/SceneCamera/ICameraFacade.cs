using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.SceneCamera
{
    public interface ICameraFacade
    {
        float FieldOfView { get; }
        float Aspect { get; }
        Transform Transform { get; }
        event Action ChangedHeight;
        void SetTargetTransform(Transform targetTransform);
    }
}
