using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IRTest.UI
{
    /// <summary>
    /// This UI script updates the time remaining panel.
    /// </summary>
    public class TimeRemainingUIController : MonoBehaviour
    {
        [SerializeField] private Text _timeRemainingText;

        private void Start()
        {
            Game.Instance.OnGameStarted += OnGameStarted;
            Game.Instance.TimerManager.OnTimerEnded += OnTimerEnded;
        }

        private void OnGameStarted()
        {
            gameObject.SetActive(true);
        }

        private void OnTimerEnded()
        {
            gameObject.SetActive(false);
        }

        public void Update()
        {
            _timeRemainingText.text = ((int)Game.Instance.TimerManager.TimeRemaining + 1).ToString();
        }
    }
}
