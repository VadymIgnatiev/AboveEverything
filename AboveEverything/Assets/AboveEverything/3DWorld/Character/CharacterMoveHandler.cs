using UnityEngine;

namespace Assets.Scripts.SceneObjects.Character
{
    public class CharacterMoveHandler
    {
        private ICharacterFacade m_CharacterFacade { get; set; }
        
        private CharacterState m_CharacterState { get; set; }

        private readonly float _movingSpeed;
        private readonly float _damageSpeed;
        private readonly float _damageSlowing;
        private readonly float _damageTime;
        private float _restDamageTime;


        public CharacterMoveHandler(
            CharacterFacade characterFacade, 
            CharacterState characterInputState,
            CharacterSettings characterSettings)
        {
            m_CharacterFacade = characterFacade;
            m_CharacterState = characterInputState;
            characterInputState.Damage += SetDamagingMoving;
            _movingSpeed = characterSettings.MovingSpeed;
            _damageSpeed = characterSettings.DamageSpeed;
            _damageSlowing = characterSettings.DamageSlowing;
            _damageTime = characterSettings.DamageTime;

        }

        private void MoveCharacter()
        {
            m_CharacterFacade.Transform.position += m_CharacterFacade.Transform.up * _movingSpeed * Time.deltaTime;
        }

        public void SetDamagingMoving()
        {
            _restDamageTime = _damageTime;
        }

        public void Update()
        {
            if (m_CharacterFacade.IsDead) return;

            if (m_CharacterState.IsDamaging)
            {
                m_CharacterFacade.Transform.position -= m_CharacterFacade.Transform.up * _damageSpeed * Time.deltaTime
                    + m_CharacterFacade.Transform.up * _damageSlowing * Time.deltaTime * Time.deltaTime / 2;

                if (_restDamageTime < 0)
                {
                    m_CharacterState.IsDamaging = false;
                }
                else
                {
                    _restDamageTime -= Time.deltaTime;
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
