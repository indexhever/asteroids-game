using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;

namespace Tests
{
    public class MockWinGameController : WinGameController
    {
        public bool HasWonGame { get; private set; }

        public void Run()
        {
            HasWonGame = true;
        }
    }
}