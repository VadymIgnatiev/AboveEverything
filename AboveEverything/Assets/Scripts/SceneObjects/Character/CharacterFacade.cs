using Assets.Scripts.SceneObjects.Damage;
using Assets.Scripts.SceneObjects.Weapon;
using Assets.Scripts.SceneObjects.Weapon.WeaponFactories;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Character
{
    public class CharacterFacade : MonoBehaviour, ICharacterFacade, IDamageable
    {
        public Transform Transform => transform;

        [SerializeField]
        private GameObject m_WeaponSlot;

        public GameObject WeaponSlot => m_WeaponSlot;

        public bool IsDead { get; private set; }

        public float Helth { get; set; }

        public float Protection { get; set; }

        private CharacterState m_CharacterState;
        private CharacterInputHandler m_CharacterInputHandler;        
        private CharacterMoveHandler m_CharacterMoveHandler;
        private CharacterShootHandler m_CharacterShootHandler;
        private CharacterDamageHandler m_CharacterDamageHandler;

        [Inject]
        private CharacterSettings m_CharacterSettings;

        [Inject(Id = WeaponType.WeaponOne)]
        private WeaponFactory m_WeaponFactoryOne;

        [Inject(Id = WeaponType.WeaponTwo)]
        private WeaponFactory m_WeaponFactoryTwo;

        [Inject(Id = WeaponType.WeaponThree)]
        private WeaponFactory m_WeaponFactoryThree;

        public void Start()
        {
            m_CharacterState = new CharacterState();
            m_CharacterInputHandler = new CharacterInputHandler(m_CharacterState);
            m_CharacterMoveHandler = new CharacterMoveHandler(this, m_CharacterState, m_CharacterSettings);
            m_CharacterShootHandler = new CharacterShootHandler(this, m_CharacterState);
            m_CharacterShootHandler.SetWeapons(GetWeapons());
            m_CharacterShootHandler.ChangeWeapon(0);
            m_CharacterDamageHandler = new CharacterDamageHandler(this, m_CharacterState);
            Helth = m_CharacterSettings.Helth;
            Protection = m_CharacterSettings.Protection;
        }

        private List<IWeapon> GetWeapons()
        {            
            List<IWeapon> weapons = new List<IWeapon>();
            weapons.Add(m_WeaponFactoryOne.Create());
            weapons.Add(m_WeaponFactoryTwo.Create());
            weapons.Add(m_WeaponFactoryThree.Create());

            return weapons;
        }

        public void Update()
        {
            m_CharacterInputHandler.Update();
            m_CharacterMoveHandler.Update();
            m_CharacterShootHandler.Update();
        }

        public void TakeDamage(float damage)
        {
            m_CharacterDamageHandler.TakeDamage(damage);
        }

        public void SetDead()
        {
            IsDead = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            IDangerous dangerous = other.GetComponent<IDangerous>();

            if (dangerous == null) return;

            TakeDamage(dangerous.Damage);
        }
    }
}
