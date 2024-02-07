using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Gameplay.Scoring
{
    /// <summary>
    /// Manages the current score within the current session.
    /// </summary>
    public sealed class ScoreManager
    {
        public int TotalScore { get; private set; }

        /// <summary>
        /// This is invoked when the score changes. It may be separated to
        /// OnScoreIncreased and OnScoreDecreased depending on the game,
        /// but in this game's case it seems unnecessary.
        /// </summary>
        public Action OnScoreUpdate;

        /// <summary>
        /// The list of ScoreModifiers. 
        /// </summary>
        private List<IScoreModifier> _scoreModifiers;

        public ScoreManager()
        {
            TotalScore = 0;

            _scoreModifiers = new List<IScoreModifier>();
        }

        public void AddScoreModifier(IScoreModifier modifier)
        {
            _scoreModifiers.Add(modifier);
        }

        public void RemoveScoreModifier(IScoreModifier modifier)
        {
            _scoreModifiers.Remove(modifier);
        }

        public void RemoveScoreModifier(string modifierID)
        {
            _scoreModifiers.RemoveAll(modifier => modifier.GetModifierID().Equals(modifierID));
        }

        public void AddScore(int score, ScoreData scoreData)
        {
            if (scoreData != null)
            {
                // go through the modifiers here
                for (int i = 0; i < _scoreModifiers.Count; ++i)
                {
                    score = _scoreModifiers[i].ModifyScore(score, scoreData);
                }
            }

            if (score != 0)
            {
                TotalScore += score;
                OnScoreUpdate?.Invoke();
            }
        }

        public void ResetScore()
        {
            TotalScore = 0;
            OnScoreUpdate?.Invoke();
        }
    }
}
