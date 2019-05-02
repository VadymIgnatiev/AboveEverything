using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Monsters
{
    [Serializable]
    public class MonstersSettings
    {
        [Serializable]
        public class MonsterSettings
        {
            public float Helth;
            public float MovingSpead;
            public float Damage;
            public GameObject MonsterPrefab;
        }

        public MonsterSettings Monster0;
        public MonsterSettings Monster1;
    }
}
