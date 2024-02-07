using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Gameplay
{
    /// <summary>
    /// This class is noticably empty, but that's because of the simplicity of the game.
    /// </summary>
    public class FruitController : MonoBehaviour
    {
        public enum FruitType { 
            APPLE,
            BANANA,
            WATERMELON
        }

        [SerializeField] private FruitType _fruitType;

        public FruitType GetFruitType() { return _fruitType; }
    }
}
