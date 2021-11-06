using System;

namespace Assets.Scripts.SceneObjects.Character
{
    public class CharacterState
    {
        public bool IsMovingLeft { get; set; }

        public bool IsMovingRight { get; set; }

        public bool IsMovingUp { get; set; }

        public bool IsMovingDown { get; set; }

        public bool IsFiring { get; set; }

        public int ActiveWeapon { get; private set; }

        public bool IsDamaging { get; set; }

        public void SetWeapon(int index)
        {
            ActiveWeapon = index;
            ChangedWeapon(ActiveWeapon);
        }

        public void SetDamage()
        {
            IsDamaging = true;
            Damage();
        }

        public event Action<int> ChangedWeapon = (x) => { };
        public event Action Damage = () => { };
    }
}
