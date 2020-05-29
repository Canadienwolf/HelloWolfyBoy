using System;
using UnityEngine;

namespace _Scripts.StoryValuesScripts
{
    [Serializable]
    public class PhysicalClue
    {
        public string clueName;
        public GameObject cluePrefab;
        public DialogueLine[] lines;
    }
}