using System;
using System.Collections.Generic;

namespace GameStory
{
    [Serializable]
    public class GameCharacter
    {
        public string characterName;
        public Location characterLocation;
        public Sex characterSex;
        public PersonalObject characterPersonalObject;

        public readonly Dictionary<ConversationLineType, List<ConversationLine>> conversationLines =
            new Dictionary<ConversationLineType, List<ConversationLine>>();

        public GameCharacter(string characterName, Location characterLocation, Sex characterSex,
            PersonalObject characterPersonalObject)
        {
            foreach (var conversationLineType in (ConversationLineType[]) Enum.GetValues(typeof(ConversationLineType)))
            {
                conversationLines.Add(conversationLineType, new List<ConversationLine>());
            }

            this.characterName = characterName;
            this.characterLocation = characterLocation;
            this.characterSex = characterSex;
            this.characterPersonalObject = characterPersonalObject;
        }

        public override string ToString()
        {
            return
                $"Name: {characterName}, Location: {characterLocation.locationName}, Sex: {characterSex.ToString()}, Personal Object: {characterPersonalObject.personalObjectName}";
        }
    }
}