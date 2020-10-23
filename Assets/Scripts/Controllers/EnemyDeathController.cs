using UnityEngine;
using System.Collections;
using System;

namespace AsteroidsGame.Controller
{
    public class EnemyDeathController
    {
        private int aliveEnemiesAmount;
        private WinGameController winGameController;

        public EnemyDeathController(WinGameController winGameController)
        {
            this.winGameController = winGameController;
        }

        public void IncreaseAmountAliveEnemies(int amountToIncrease = 1)
        {
            aliveEnemiesAmount += amountToIncrease;
        }

        public void DecreaseAmountAliveEnemies(int amountToDecrease = 1)
        {
            aliveEnemiesAmount -= amountToDecrease;

            CheckIfWinGame();
        }

        private void CheckIfWinGame()
        {
            if (aliveEnemiesAmount > 0)
                return;

            winGameController.Run();
        }
    }
}