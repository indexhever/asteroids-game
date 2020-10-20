using AsteroidsGame.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.Controller
{
    public class DefaultWinGameController : WinGameController
    {
        private WinGameScreen winGameScreen;

        public DefaultWinGameController(WinGameScreen winGameScreen)
        {
            this.winGameScreen = winGameScreen;
        }

        public void Run()
        {
            winGameScreen.Show();
        }
    }
}