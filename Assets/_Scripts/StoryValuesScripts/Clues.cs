using UnityEngine;

namespace _Scripts.StoryValuesScripts
{
    [CreateAssetMenu(fileName = "Clues", menuName = "Story/Clues")]
    public class Clues : ScriptableObject
    {
        public LocationClue[] victimLocationClues;
        
        public LocationClue[] murderLocationClues;
        
        [Header("Murder Clues")]
        public PersonalItem[] personalItemClues;
        public PhysicalClue[] objectFoundOnLocationClues;
        public PhysicalClue[] observationClues;
    }
}