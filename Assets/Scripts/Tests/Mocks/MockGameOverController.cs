using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;

namespace Tests
{
    public class MockGameOverController : GameOverController
    {
        public bool IsTriggered { get; private set; }

        public void Run()
        {
            IsTriggered = true;
        }
    }
}