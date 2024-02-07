using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest
{
    /// <summary>
    /// GameConstants is a static class to hold much of the constants used throughout the game.
    /// In a larger project, it may be necessary to split the constants among multiple classes,
    /// but for this small project, the constants can fit within one class.
    /// </summary>
    public static class GameConstants
    {
        // Resource paths for loading.
        public static readonly string RESOURCE_PATH_FRUIT = "FruitObjects";
        public static readonly string RESOURCE_PATH_SFX = "SFX";

        // GameObject tags.
        public static readonly string TAG_ID_FRUIT = "Fruit";

        // IDs for score modifiers.
        public static readonly string SCORE_MODIFIER_ID_FRUIT = "FRUIT";

        // IDs for score data.
        public static readonly string SCORE_DATA_ID_FRUITTYPE = "FRUITTYPE";

        // IDs for individual fruits.
        public static readonly string FRUIT_ID_APPLE = "Apple";
        public static readonly string FRUIT_ID_BANANA = "Banana";
        public static readonly string FRUIT_ID_WATERMELON = "Watermelon";

        // IDs for sfx clips.
        public static readonly string SFX_CLIP_ID_APPLE = "apple_sfx";
        public static readonly string SFX_CLIP_ID_BANANA = "banana_sfx";
        public static readonly string SFX_CLIP_ID_WATERMELON = "watermelon_sfx";

        // The amount of time allotted for a game session.
        public const float GAME_TOTAL_TIME = 30f;
    }
}
