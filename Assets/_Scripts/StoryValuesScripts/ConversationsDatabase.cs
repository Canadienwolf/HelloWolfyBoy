using System.Collections;
using System.Collections.Generic;
using _Scripts.StoryValuesScripts;
using UnityEngine;

namespace GameStory
{
    public class ConversationsDatabase : ScriptableObject
    {
        public List<Location> locations;
        public List<GameCharacter> gameCharacters;
        public List<ConversationLine> conversationLines;
    }
}