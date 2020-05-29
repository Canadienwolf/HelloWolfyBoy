using System;
using UnityEngine;

namespace GameStory
{
    [Serializable]
    public class PersonalObject
    {
        public string personalObjectName;
        public GameCharacter personalObjectOwner;
        public GameObject personalObjectPrefab;

        public PersonalObject(string personalObjectName, GameCharacter personalObjectOwner = null,
            GameObject personalObjectPrefab = null)
        {
            this.personalObjectName = personalObjectName;
            this.personalObjectOwner = personalObjectOwner;
            this.personalObjectPrefab = personalObjectPrefab;
        }
    }
}