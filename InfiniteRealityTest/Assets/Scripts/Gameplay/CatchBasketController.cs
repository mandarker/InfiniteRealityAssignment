using IRTest.Gameplay.Scoring;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace IRTest.Gameplay
{
    public sealed class CatchBasketController : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _bounds;

        private float _horizontal;

        private bool _inputEnabled;

        /// <summary>
        /// This hashset may seem a little strange, but it is necessary when dealing with
        /// colliders with multiple points potentially in contact (like circular or
        /// capsule colliders). It prevents redundant OnTriggerEnter() calls.
        /// </summary>
        private HashSet<int> _collisionHashset;

        private void Start()
        {
            Game.Instance.TimerManager.OnTimerEnded += DisableInput;
            Game.Instance.OnGameStarted += EnableInput;

            _inputEnabled = true;

            _collisionHashset = new HashSet<int>();
        }

        private void EnableInput()
        {
            _inputEnabled = true;
        }

        private void DisableInput()
        {
            _inputEnabled = false;
        }

        // The input is calculated here, but is actually used during the Update() function.
        private void FixedUpdate()
        {
            _horizontal = 0;

            if (!_inputEnabled)
                return;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _horizontal -= 1;
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _horizontal += 1;
            }
        }

        private void Update()
        {
            float offset = _horizontal * _speed * Time.deltaTime;

            if (Mathf.Abs(transform.position.x + offset) < _bounds)
            {
                transform.position += new Vector3(offset, 0, 0);
            }

            _collisionHashset.Clear();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            int instanceID = collision.attachedRigidbody.gameObject.GetInstanceID();

            if (_collisionHashset.Contains(instanceID))
            {
                return;
            }
            else
            {
                _collisionHashset.Add(instanceID);
            }

            // if the object we're colliding with is a fruit
            if (collision.attachedRigidbody.tag.Equals(GameConstants.TAG_ID_FRUIT))
            {
                FruitController fruitController = collision.attachedRigidbody.GetComponent<FruitController>();

                ScoreData scoreData = new ScoreData();
                scoreData.SetData(GameConstants.SCORE_DATA_ID_FRUITTYPE, (int)fruitController.GetFruitType());

                // add the score
                Game.Instance.ScoreManager.AddScore(1, scoreData);

                // remove the object appropriately and play the sfx
                switch (fruitController.GetFruitType())
                {
                    case FruitController.FruitType.APPLE:
                        Game.Instance.ObjectPoolManager.ReturnObject(GameConstants.FRUIT_ID_APPLE, fruitController.gameObject);
                        Game.Instance.SFXController.PlayAudioClip(GameConstants.SFX_CLIP_ID_APPLE);
                        break;
                    case FruitController.FruitType.BANANA:
                        Game.Instance.ObjectPoolManager.ReturnObject(GameConstants.FRUIT_ID_BANANA, fruitController.gameObject);
                        Game.Instance.SFXController.PlayAudioClip(GameConstants.SFX_CLIP_ID_BANANA);
                        break;
                    case FruitController.FruitType.WATERMELON:
                        Game.Instance.ObjectPoolManager.ReturnObject(GameConstants.FRUIT_ID_WATERMELON, fruitController.gameObject);
                        Game.Instance.SFXController.PlayAudioClip(GameConstants.SFX_CLIP_ID_WATERMELON);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
