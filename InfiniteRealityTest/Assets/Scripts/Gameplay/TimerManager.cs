using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Gameplay
{
    /// <summary>
    /// The TimerManager takes care of the current in-game time that is counting down.
    /// </summary>
    public sealed class TimerManager
    {
        public float TimeRemaining { get; private set; }
        private bool _isTimerPaused;

        /// <summary>
        /// This is invoked when the current game session ends and time has run out.
        /// </summary>
        public Action OnTimerEnded;

        public TimerManager()
        {
            TimeRemaining = 0;
            _isTimerPaused = true;
        }

        public void StartTimer(float totalTime)
        {
            TimeRemaining = totalTime;
            _isTimerPaused = false;
        }

        public void UpdateTimer(float deltaTime)
        {
            if (!_isTimerPaused)
            {
                TimeRemaining -= deltaTime;

                // if the time has run out
                if (TimeRemaining <= 0)
                {
                    // set this to true to prevent multiple invocation
                    _isTimerPaused = true;
                    TimeRemaining = 0;

                    OnTimerEnded?.Invoke();
                }
            }
        }

        public void SetTimerPaused(bool paused)
        {
            _isTimerPaused = paused;
        }
    }
}
