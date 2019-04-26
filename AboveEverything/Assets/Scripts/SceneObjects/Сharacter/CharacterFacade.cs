using UnityEngine;

namespace Assets.Scripts.SceneObjects.Сharacter
{
    public class CharacterFacade : MonoBehaviour, ICharacterFacade
    {
        public Transform Transform => transform;
    }
}
