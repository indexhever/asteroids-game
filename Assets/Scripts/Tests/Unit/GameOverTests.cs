using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidsGame.Controller;
using AsteroidsGame.Controllers;
using AsteroidsGame.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameOverTests
    {
        [Test]
        public void WhenGameOverTheGameOverScreeIsShown()
        {
            GameOverScreen gameOverScreen = CreateGameOverScreen();
            GameOverController gameOverController = CreateGameOverController(gameOverScreen);

            gameOverController.Run();
            bool isGameOverScreenShown = (gameOverScreen as MockGameOverScreen).IsShown;

            Assert.IsTrue(isGameOverScreenShown);
        }

        [Test]
        public void GameIsPausedWhenGameOver()
        {
            GamePauseController gamePauseController = CreateGamePauseController();
            GameOverController gameOverController = CreateGameOverController(new MockGameOverScreen(), gamePauseController);

            gameOverController.Run();
            bool isGamePausedAfterGameOver = (gamePauseController as MockGamePauseController).IsGamePaused;

            Assert.IsTrue(isGamePausedAfterGameOver);
        }

        private GameOverController CreateGameOverController(GameOverScreen gameOverScreen)
        {
            return new DefaultGameOverController(gameOverScreen, CreateGamePauseController());
        }

        private GameOverController CreateGameOverController(GameOverScreen gameOverScreen, GamePauseController gamePauseController)
        {
            return new DefaultGameOverController(gameOverScreen, gamePauseController);
        }

        private GameOverScreen CreateGameOverScreen()
        {
            return new MockGameOverScreen();
        }

        private GamePauseController CreateGamePauseController()
        {
            return new MockGamePauseController();
        }
    }
}
