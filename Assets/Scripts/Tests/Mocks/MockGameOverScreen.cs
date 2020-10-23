using UnityEngine;
using System.Collections;
using AsteroidsGame.View;

namespace Tests
{
    public class MockGameOverScreen : GameOverScreen
    {
        public bool IsShown { get; private set; }

        public void Show()
        {
            IsShown = true;
        }
    }
}