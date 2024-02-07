using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IRTest.UI
{
    /// <summary>
    /// This UI script updates the score panel.
    /// </summary>
    public class ScoreUIController : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private void Start()
        {
            Game.Instance.ScoreManager.OnScoreUpdate += SetScoreText;

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

        private void SetScoreText()
        {
            _scoreText.text = Game.Instance.ScoreManager.TotalScore.ToString();
        }
    }
}
