using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;
using AsteroidsGame.View;

namespace AsteroidsGame.Controllers
{
    public class DefaultGameOverController : GameOverController
    {
        private GameOverScreen gameOverScreen;
        private GamePauseController gamePauseController;

        public DefaultGameOverController(GameOverScreen gameOverScreen, GamePauseController gamePauseController)
        {
            this.gameOverScreen = gameOverScreen;
            this.gamePauseController = gamePauseController;
            gamePauseController.Resume();
        }

        public void Run()
        {
            gamePauseController.Pause();
            gameOverScreen.Show();
        }
    }
}