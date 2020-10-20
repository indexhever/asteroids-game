using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;
using Zenject;

namespace AsteroidsGame.View
{
    public class AsteroidDeathComponent : EnemyDeathComponent
    {
        private ScoreSystem scoreSystem;
        private EnemyDeathController enemyDeathController;

        [Inject]
        private void Construct(ScoreSystem scoreSystem, EnemyDeathController enemyDeathController)
        {
            this.scoreSystem = scoreSystem;
            this.enemyDeathController = enemyDeathController;
        }

        public override void OnDie()
        {
            scoreSystem.Add(10);
            enemyDeathController.DecreaseAmountAliveEnemies();
        }
    }
}