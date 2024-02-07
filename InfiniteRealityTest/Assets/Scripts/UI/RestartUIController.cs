using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IRTest.UI
{
    /// <summary>
    /// This UI script updates the restart panel.
    /// </summary>
    public class RestartUIController : MonoBehaviour
    {
        [SerializeField] private Button _yesButton;
        [SerializeField] private Text _finalScoreText;

        private void Start()
        {
            Game.Instance.TimerManager.OnTimerEnded += OnTimerEnded;

            _yesButton.onClick.AddListener(OnYesClicked);
            
            // turn off the panel until the game is over
            gameObject.SetActive(false);
        }

        private void OnTimerEnded()
        {
            // we can turn on the panel now
            gameObject.SetActive(true);

            _finalScoreText.text = Game.Instance.ScoreManager.TotalScore.ToString();
        }

        private void OnYesClicked()
        {
            Game.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}
