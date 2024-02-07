using System.Collections;
using System.Collections.Generic;
using IRTest.Gameplay;
using IRTest.Gameplay.Scoring;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace IRTest.Testing
{
    public class TestScoreManager
    {
        [Test]
        public void TestScoreManagerInstantiation()
        {
            ScoreManager scoreManager = new ScoreManager();

            Assert.AreEqual(scoreManager.TotalScore, 0);
        }

        [Test]
        public void TestScoreManagerAddDeleteScore()
        {
            ScoreManager scoreManager = new ScoreManager();
            scoreManager.AddScore(10, null);

            Assert.AreEqual(scoreManager.TotalScore, 10);

            scoreManager.ResetScore();

            Assert.AreEqual(scoreManager.TotalScore, 0);
        }

        [Test]
        public void TestScoreManagerSingleModifier()
        {
            ScoreManager scoreManager = new ScoreManager();
            FruitScoreModifier modifier = new FruitScoreModifier();

            scoreManager.AddScoreModifier(modifier);
            scoreManager.AddScore(10, null);

            Assert.AreEqual(scoreManager.TotalScore, 10);

            ScoreData scoreData = new ScoreData();
            scoreData.SetData(GameConstants.SCORE_DATA_ID_FRUITTYPE, (int)FruitController.FruitType.APPLE);
            scoreManager.AddScore(10, scoreData);

            Assert.AreEqual(scoreManager.TotalScore, 20);

            scoreData.SetData(GameConstants.SCORE_DATA_ID_FRUITTYPE, (int)FruitController.FruitType.BANANA);
            scoreManager.AddScore(10, scoreData);

            Assert.AreEqual(scoreManager.TotalScore, 40);

            scoreManager.RemoveScoreModifier(modifier);
            scoreManager.AddScore(10, scoreData);

            Assert.AreEqual(scoreManager.TotalScore, 50);
        }
    }
}
