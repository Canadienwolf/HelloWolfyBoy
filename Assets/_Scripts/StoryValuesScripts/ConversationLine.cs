using System;

namespace GameStory
{
    [Serializable]
    public class ConversationLine
    {
        public string conversationLine;
        public GameCharacter character;
        public ReputationMarker reputationMarker;
        public DayPhase dayPhase;
        public ConversationLineType conversationLineType;

        public ConversationLine(string conversationLine, GameCharacter character = null,
            ReputationMarker reputationMarker = ReputationMarker.Any, DayPhase dayPhase = DayPhase.Generic,
            ConversationLineType conversationLineType = ConversationLineType.Generic)
        {
            this.conversationLine = conversationLine;
            this.character = character;
            this.reputationMarker = reputationMarker;
            this.dayPhase = dayPhase;
            this.conversationLineType = conversationLineType;
        }
    }
}