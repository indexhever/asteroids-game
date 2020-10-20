using UnityEngine;
using System.Collections;
using System;
using AsteroidsGame.View;

namespace AsteroidsGame.Controller
{
    public class LifeController
    {
        private LifeVisual lifeVisual;
        private GameOverController gameOverController;

        public LifeController(int initialLife, LifeVisual lifeVisual, GameOverController gameOverController)
        {
            RemainingLife = initialLife;
            this.lifeVisual = lifeVisual;
            this.gameOverController = gameOverController;
        }

        public int RemainingLife { get; private set; }

        public void Die()
        {
            --RemainingLife;
            lifeVisual.UpdatWithNewRemainingLife(RemainingLife);
            if (RemainingLife == 0)
                gameOverController.Run();
        }
    }
}