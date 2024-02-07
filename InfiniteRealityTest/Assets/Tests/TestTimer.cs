using System.Collections;
using System.Collections.Generic;
using IRTest.Gameplay;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace IRTest.Testing
{
    public class TestTimer
    {
        [Test]
        public void TestTimerInstantiation()
        {
            TimerManager timerManager = new TimerManager();

            Assert.AreEqual(timerManager.TimeRemaining, 0);
        }

        [Test]
        public void TestTimerClock()
        {
            TimerManager timerManager = new TimerManager();

            timerManager.StartTimer(60);

            Assert.AreEqual(timerManager.TimeRemaining, 60);

            timerManager.UpdateTimer(10);

            Assert.AreEqual(timerManager.TimeRemaining, 50);

            timerManager.SetTimerPaused(true);
            timerManager.UpdateTimer(10);

            Assert.AreEqual(timerManager.TimeRemaining, 50);

            timerManager.SetTimerPaused(false);
            timerManager.UpdateTimer(60);

            Assert.AreEqual(timerManager.TimeRemaining, 0);
        }
    }
}
