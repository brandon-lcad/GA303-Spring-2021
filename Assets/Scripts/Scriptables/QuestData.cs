using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "new Quest", menuName = "Game Systems/Quests")]
    public class QuestData : GameContent
    {
        public enum RewardType
        {
            Currency,
            Reputation,
            Reagent
        }

        public int questObjective; 
        public int invQuantity;

        public bool questTimed;
        public int questTimer;
        public bool questActive;
        public bool questComplete;

        public int rewardAmount;
        public Sprite rewardImage;
        public RewardType rewardType;
    }
}



