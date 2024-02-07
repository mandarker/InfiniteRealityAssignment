using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Gameplay.Scoring
{
    /// <summary>
    /// ScoreModifiers are any class that modifies the score a fruit may give.
    /// This can be expanded to custom multipliers, combos, etc... The idea is
    /// to string them together to calculate the end score.
    /// </summary>
    public interface IScoreModifier
    {
        public string GetModifierID();
        public int ModifyScore(int score, ScoreData scoreData);
    }
}
