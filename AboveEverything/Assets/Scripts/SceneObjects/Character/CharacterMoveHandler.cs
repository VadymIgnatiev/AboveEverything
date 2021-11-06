using UnityEngine;

namespace Assets.Scripts.SceneObjects.Character
{
    public class CharacterMoveHandler
    {
        private ICharacterFacade m_CharacterFacade { get; set; }
        
        private CharacterState m_CharacterState { get; set; }

        readonly float m_MovingSpeed;
        readonly float m_DamageSpeed;
        readonly float m_DamageSlowing;
        readonly float m_DamageTime;
        private float m_RestDamageTime;


        public CharacterMoveHandler(
            CharacterFacade characterFacade, 
            CharacterState characterInputState,
            CharacterSettings characterSettings)
        {
            m_CharacterFacade = characterFacade;
            m_CharacterState = characterInputState;
            characterInputState.Damage += SetDamagingMoving;
            m_MovingSpeed = characterSettings.MovingSpeed;
            m_DamageSpeed = characterSettings.DamageSpeed;
            m_DamageSlowing = characterSettings.DamageSlowing;
            m_DamageTime = characterSettings.DamageTime;

        }

        private void MoveCharacter()
        {
            m_CharacterFacade.Transform.position += m_CharacterFacade.Transform.up * m_MovingSpeed * Time.deltaTime;
        }

        public void SetDamagingMoving()
        {
            m_RestDamageTime = m_DamageTime;
        }

        public void Update()
        {
            if (m_CharacterFacade.IsDead) return;

            if (m_CharacterState.IsDamaging)
            {
                m_CharacterFacade.Transform.position -= m_CharacterFacade.Transform.up * m_DamageSpeed * Time.deltaTime
                    + m_CharacterFacade.Transform.up * m_DamageSlowing * Time.deltaTime * Time.deltaTime / 2;

                if (m_RestDamageTime < 0)
                {
                    m_CharacterState.IsDamaging = false;
                }
                else
                {
                    m_RestDamageTime -= Time.deltaTime;
                }

                return;
            }

            if (m_CharacterState.IsMovingUp)
            {
                m_CharacterFacade.Transform.rotation = Quaternion.Euler(0, 0, 0);
                MoveCharacter();
            }

            if (m_CharacterState.IsMovingRight)
            {
                m_CharacterFacade.Transform.rotation = Quaternion.Euler(0, 0, -90);
                MoveCharacter();
            }

            if (m_CharacterState.IsMovingDown)
            {
                m_CharacterFacade.Transform.rotation = Quaternion.Euler(0, 0, 180);
                MoveCharacter();
            }

            if (m_CharacterState.IsMovingLeft)
            {
                m_CharacterFacade.Transform.rotation = Quaternion.Euler(0, 0, 90);
                MoveCharacter();
            }            
        }
    }
}
