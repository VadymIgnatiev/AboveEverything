using UnityEngine;

namespace Assets.Scripts.SceneObjects.Character
{
    public interface ICharacterFacade
    {
        Transform Transform { get; }

        GameObject WeaponSlot { get; }

        bool IsDead { get; }

        float Helth { get; }

        float Protection { get; set; }        

    }
}
