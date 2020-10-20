using ModestTree.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.Controller
{
    public class TimeBasedGamePauseController : GamePauseController
    {
        private const int PAUSE_TIME_SCALE = 0;
        private const int RESUME_TIME_SCALE = 1;
        Action<float> setTimeScaleTo;

        public TimeBasedGamePauseController(Action<float> setTimeScaleTo)
        {
            this.setTimeScaleTo = setTimeScaleTo;
        }

        public void Pause()
        {
            setTimeScaleTo(PAUSE_TIME_SCALE);
        }

        public void Resume()
        {
            setTimeScaleTo(RESUME_TIME_SCALE);
        }
    }
}