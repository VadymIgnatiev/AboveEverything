namespace Assets.Scripts.SceneObjects.Character
{
    public class CharacterDamageHandler
    {
        private CharacterFacade m_CharacterFacade;
        private CharacterState m_CharacterState;

        public CharacterDamageHandler(CharacterFacade characterFacade, CharacterState characterState)
        {
            m_CharacterFacade = characterFacade;
            m_CharacterState = characterState;
        }

        public void TakeDamage(float damage)
        {
            if (m_CharacterFacade.Protection > 0)
            {
                m_CharacterFacade.Protection -= damage;
            }
            else
            {
                m_CharacterFacade.Helth -= damage;

                if (m_CharacterFacade.Helth < 0)
                    m_CharacterFacade.SetDead();
            }

            if (!m_CharacterFacade.IsDead)
                m_CharacterState.SetDamage();
        }
    }
}
