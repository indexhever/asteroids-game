using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidsGame.Controller;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WinGameTests
    {
        [Test]
        public void WinGameWhenThereIsNoEnemyAlive()
        {
            WinGameController winGameController = CreateWinGameController();
            EnemyDeathController enemyDeathController = CreateEnemyDeathController(winGameController);
            enemyDeathController.IncreaseAmountAliveEnemies(1);

            enemyDeathController.DecreaseAmountAliveEnemies();
            bool hasWonGame = (winGameController as MockWinGameController).HasWonGame;

            Assert.IsTrue(hasWonGame);
        }

        private WinGameController CreateWinGameController()
        {
            return new MockWinGameController();
        }

        private EnemyDeathController CreateEnemyDeathController(WinGameController winGameController)
        {
            return new EnemyDeathController(winGameController);
        }
    }
}
