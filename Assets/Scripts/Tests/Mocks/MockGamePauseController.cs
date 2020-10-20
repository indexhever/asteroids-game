using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;

namespace Tests
{
    public class MockGamePauseController : GamePauseController
    {
        public bool IsGamePaused { get; private set; }

        public void Pause()
        {
            IsGamePaused = true;
        }

        public void Resume()
        {
            IsGamePaused = false;
        }
    }
}