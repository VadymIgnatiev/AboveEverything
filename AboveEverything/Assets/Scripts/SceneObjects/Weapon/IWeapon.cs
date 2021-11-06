using UnityEngine;

namespace Assets.Scripts.SceneObjects.Weapon
{
    public interface IWeapon
    {    
        Transform Transform { get; }
        void Activate();
        void Deactivate();
        void Fire();
    }
}
