using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Weapon
{
    [Serializable]
    public class WeaponSettings
    {
        [Serializable]
        public class Weapon
        {
            public GameObject Prefab;
            public GameObject BulletPrefab;
            public float BulletSpeed;
            public float BulletLifeTime;
        }

        public Weapon Weapon1;
        public Weapon Weapon2;
        public Weapon Weapon3;
    }


}
