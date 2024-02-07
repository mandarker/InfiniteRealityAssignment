using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace IRTest.Gameplay.Scoring
{
    /// <summary>
    /// This ScoreModifier takes into account which fruit is being scored
    /// and provides the proper score output.
    /// </summary>
    public sealed class FruitScoreModifier : IScoreModifier
    {
        public string GetModifierID()
        {
            return GameConstants.SCORE_MODIFIER_ID_FRUIT;
        }

        public int ModifyScore(int score, ScoreData scoreData)
        {
            if (scoreData.GetData(GameConstants.SCORE_DATA_ID_FRUITTYPE, out int fruitType))
            {
                switch (fruitType)
                {
                    case (int)FruitController.FruitType.APPLE:
                    default:
                        // don't apply a multiplier
                        break;
                    case (int)FruitController.FruitType.BANANA:
                        score = score * 2;
                        break;
                    case (int)FruitController.FruitType.WATERMELON:
                        score = score * 4;
                        break;
                }
            }

            return score;
        }
    }
}
