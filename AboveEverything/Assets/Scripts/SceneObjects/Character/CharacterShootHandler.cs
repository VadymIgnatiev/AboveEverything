using Assets.Scripts.SceneObjects.Weapon;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Character
{
    public class CharacterShootHandler
    {
        private ICharacterFacade m_CharacterFacade;
        private CharacterState m_CharacterState;

        private IWeapon m_ActiveWeapon;

        private List<IWeapon> m_Weapons { get; set; }

        public CharacterShootHandler(ICharacterFacade characterFacade, CharacterState characterState)
        {
            m_CharacterFacade = characterFacade;
            m_CharacterState = characterState;
            m_CharacterState.ChangedWeapon += ChangeWeapon;

            m_Weapons = new List<IWeapon>();
        }

        public void SetWeapons(List<IWeapon> weapons)
        {
            m_Weapons.AddRange(weapons);

            for (int i = 0; i < weapons.Count; i++)
            {
                AddWeaponToCharacter(weapons[i]);
                weapons[i].Deactivate();
            }
        }

        private void AddWeaponToCharacter(IWeapon weapon)
        {
            weapon.Transform.parent = m_CharacterFacade.WeaponSlot.transform;
            weapon.Transform.localPosition = new Vector3(0, 0, 0);
            weapon.Transform.rotation = Quaternion.identity;
        }

        public void ChangeWeapon(int index)
        {
            if (index > m_Weapons.Count - 1) return;

            if(m_ActiveWeapon != null)
                m_ActiveWeapon.Deactivate();

            m_ActiveWeapon = m_Weapons[index];
            m_ActiveWeapon.Activate();
        }

        public void Update()
        {
            if (m_CharacterState.IsFiring)
            {
                m_ActiveWeapon.Fire();
            }
        }
    }
}
