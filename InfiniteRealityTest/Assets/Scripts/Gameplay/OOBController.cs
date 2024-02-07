using IRTest.Gameplay.Scoring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Gameplay
{
    /// <summary>
    /// This class just takes care of objects that have fallen off the screen
    /// by checking to see if they have collided with a large collider below.
    /// </summary>
    public class OOBController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.attachedRigidbody.tag.Equals(GameConstants.TAG_ID_FRUIT))
            {
                FruitController fruitController = collision.attachedRigidbody.GetComponent<FruitController>();

                // this can be done better, but alas, time constraints
                switch(fruitController.GetFruitType())
                {
                    case FruitController.FruitType.APPLE:
                        Game.Instance.ObjectPoolManager.ReturnObject(GameConstants.FRUIT_ID_APPLE, fruitController.gameObject);
                        break;
                    case FruitController.FruitType.BANANA:
                        Game.Instance.ObjectPoolManager.ReturnObject(GameConstants.FRUIT_ID_BANANA, fruitController.gameObject);
                        break;
                    case FruitController.FruitType.WATERMELON:
                        Game.Instance.ObjectPoolManager.ReturnObject(GameConstants.FRUIT_ID_WATERMELON, fruitController.gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
