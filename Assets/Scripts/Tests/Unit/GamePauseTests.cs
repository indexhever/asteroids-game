using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidsGame.Controller;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GamePauseTests
    {
        [Test]
        public void TimeScaleIsSetToZeroOnPause()
        {
            float expectedTimeScaleAfterPause = 0;
            float currentTimeScale = 1;
            Action<float> setTimeScale = (newTimeScale) => currentTimeScale = newTimeScale;
            TimeBasedGamePauseController timeBasedGamePauseController = CreateGamePauseController(setTimeScale);

            timeBasedGamePauseController.Pause();

            Assert.AreEqual(expectedTimeScaleAfterPause, currentTimeScale);
        }

        [Test]
        public void TimeScaleIsSetToOneOnResume()
        {
            float expectedTimeScaleAfterPause = 1;
            float currentTimeScale = 0;
            Action<float> setTimeScale = (newTimeScale) => currentTimeScale = newTimeScale;
            TimeBasedGamePauseController timeBasedGamePauseController = CreateGamePauseController(setTimeScale);

            timeBasedGamePauseController.Resume();

            Assert.AreEqual(expectedTimeScaleAfterPause, currentTimeScale);
        }

        private TimeBasedGamePauseController CreateGamePauseController(Action<float> setTimeScale)
        {
            return new TimeBasedGamePauseController(setTimeScale);
        }
    }
}
