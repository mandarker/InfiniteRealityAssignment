using IRTest.Gameplay;
using IRTest.Gameplay.Scoring;
using IRTest.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest
{
    /// <summary>
    /// The Game class is used to handle much of the logic of the game,
    /// including scoring, time management, and object management. It is the
    /// only singleton used in this game.
    /// </summary>
    public sealed class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }

        #region Object References
        public ObjectPoolManager ObjectPoolManager { get; private set; }
        public ScoreManager ScoreManager { get; private set; }
        public TimerManager TimerManager { get; private set; }

        [SerializeField] private SFXController _sfxController;
        public SFXController SFXController { get { return _sfxController; } }
        #endregion

        // This Action is used to invoke a number of methods that need to reset the game state before actually starting the game.
        public Action OnGameStarted;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(Instance);

                InitGame();
            }
        }

        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
            TimerManager.UpdateTimer(Time.deltaTime);
        }

        /// <summary>
        /// InitGame() takes care of the instantiation of much of the necessary objects,
        /// as well as loading some resources for the fruits that will be duplicated.
        /// </summary>
        private void InitGame()
        {
            ObjectPoolManager = new ObjectPoolManager();
            ScoreManager = new ScoreManager();
            TimerManager = new TimerManager();

            // A ScoreModifier is added to properly add the amount of points each fruit gives.
            ScoreManager.AddScoreModifier(new FruitScoreModifier());

            FruitController[] fruitControllers = Resources.LoadAll<FruitController>(GameConstants.RESOURCE_PATH_FRUIT);
            foreach (var fruitController in fruitControllers)
            {
                Game.Instance.ObjectPoolManager.AddObject(fruitController.name, fruitController.gameObject);
            }
        }

        /// <summary>
        /// StartGame() is called to either start or restart the game.
        /// </summary>
        public void StartGame()
        {
            TimerManager.StartTimer(GameConstants.GAME_TOTAL_TIME);
            ScoreManager.ResetScore();

            OnGameStarted?.Invoke();
        }
    }
}
