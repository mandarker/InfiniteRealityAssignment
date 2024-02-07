using IRTest.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Gameplay
{
    /// <summary>
    /// The FruitFactoryManager takes care of spawning all of the fruit from the top.
    /// </summary>
    public class FruitFactoryManager : MonoBehaviour
    {
        [SerializeField] private Transform _spawnBaseTransform;
        [SerializeField, Range(0, 10)] private float _spawnRange;
        [SerializeField, Range(0, 2)] private float _spawnFrequency;

        private bool _spawning;
        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            _spawning = true;
        }

        public void Start()
        {
            if (_spawnCoroutine == null)
            {
                _spawnCoroutine = StartCoroutine(SpawnFruitCoroutine());
            }

            Game.Instance.TimerManager.OnTimerEnded += OnTimerEnded;
            Game.Instance.OnGameStarted += OnGameStarted;
        }

        private void OnGameStarted()
        {
            _spawning = true;

            _spawnCoroutine = StartCoroutine(SpawnFruitCoroutine());
        }

        private void OnTimerEnded()
        {
            // removes all of the current objects on screen
            Game.Instance.ObjectPoolManager.ReturnAll(GameConstants.FRUIT_ID_APPLE);
            Game.Instance.ObjectPoolManager.ReturnAll(GameConstants.FRUIT_ID_BANANA);
            Game.Instance.ObjectPoolManager.ReturnAll(GameConstants.FRUIT_ID_WATERMELON);

            // prevents any more objects from spawning
            StopAllCoroutines();

            _spawning = false;
        }

        IEnumerator SpawnFruitCoroutine()
        {
            while (_spawning)
            {
                yield return new WaitForSeconds(_spawnFrequency);

                // random function here for now, but can be improved drastically
                int random = Random.Range(0, 3);

                if (random == 0)
                {
                    SpawnFruit(GameConstants.FRUIT_ID_APPLE);
                }
                else if (random == 1)
                {
                    SpawnFruit(GameConstants.FRUIT_ID_BANANA);
                }
                else
                {
                    SpawnFruit(GameConstants.FRUIT_ID_WATERMELON);
                }

            }
        }

        private void SpawnFruit(string fruitID)
        {
            GameObject fruitObject = Game.Instance.ObjectPoolManager.GetObject(fruitID);

            if (fruitObject != null)
            {
                FruitController controller = fruitObject.GetComponent<FruitController>();

                // the object is spawned with a random horizontal offset
                controller.transform.position = _spawnBaseTransform.position + new Vector3(Random.Range(-_spawnRange, _spawnRange), 0, 0);
                controller.gameObject.SetActive(true);

                // as well as a random spin
                controller.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2, 2));
            }
        }
    }
}
