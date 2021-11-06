using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Character
{
    public class CharacterInputHandler
    {
        readonly CharacterState m_CharacterState;

        public CharacterInputHandler(CharacterState state)
        {
            m_CharacterState = state;
        }

        public void Update()
        {
            ProcessMoving();
            ProcessWeapon();
        }

        private void ResetState()
        {
            m_CharacterState.IsMovingLeft = false;
            m_CharacterState.IsMovingRight = false;
            m_CharacterState.IsMovingUp = false;
            m_CharacterState.IsMovingDown = false;
        }

        private void ProcessRestPress()
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
            {
                ResetState();
                m_CharacterState.IsMovingLeft = true;
                return;
            }

            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
            {
                ResetState();
                m_CharacterState.IsMovingRight = true;
                return;
            }

            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
            {
                ResetState();
                m_CharacterState.IsMovingUp = true;
                return;
            }

            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
            {
                ResetState();
                m_CharacterState.IsMovingDown = true;
                return;
            }
        }

        private void ProcessMoving()
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
            {
                ResetState();
                m_CharacterState.IsMovingLeft = true;
                return;
            }

            if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)))
            {
                m_CharacterState.IsMovingLeft = false;
                ProcessRestPress();
                return;
            }

            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
            {
                ResetState();
                m_CharacterState.IsMovingRight = true;
                return;
            }

            if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)))
            {
                m_CharacterState.IsMovingRight = false;
                ProcessRestPress();
                return;
            }

            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
            {
                ResetState();
                m_CharacterState.IsMovingUp = true;
                return;
            }

            if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)))
            {
                m_CharacterState.IsMovingUp = false;
                ProcessRestPress();
                return;
            }

            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
            {
                ResetState();
                m_CharacterState.IsMovingDown = true;
                return;
            }

            if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)))
            {
                m_CharacterState.IsMovingDown = false;
                ProcessRestPress();
                return;
            }
        }

        private void ProcessWeapon()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                m_CharacterState.SetWeapon(0);
            }

            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                m_CharacterState.SetWeapon(1);
            }

            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                m_CharacterState.SetWeapon(2);
            }

            m_CharacterState.IsFiring = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        }
    }
}
