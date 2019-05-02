using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Assets.Scripts.SceneObjects.Monsters.MonsterFacade;

namespace Assets.Scripts.SceneObjects.Monsters
{
    public class MonsterSpawner
    {
        [Inject]
        private MonsterFactoryOne m_MonsterFactoryOne;

        [Inject]
        private MonsterFactoryTwo m_MonsterFactoryTwo;

        [Inject]
        private MonstersSettings m_MonstersSettings;

        public void Spawn(Vector3 cell)
        {
            int index = Random.Range(0, 2);

            MonsterFacade monster;

            if (index == 0)
            {
                monster = m_MonsterFactoryOne
                    .Create(m_MonstersSettings.Monster0.Damage,
                    m_MonstersSettings.Monster0.Helth,
                    m_MonstersSettings.Monster0.MovingSpead);
            }
            else
            {
                monster = m_MonsterFactoryOne
                    .Create(m_MonstersSettings.Monster1.Damage,
                    m_MonstersSettings.Monster1.Helth,
                    m_MonstersSettings.Monster1.MovingSpead);
            }

            monster.transform.position = cell;
            monster.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
