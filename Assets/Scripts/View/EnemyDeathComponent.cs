using AsteroidsGame.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public abstract class EnemyDeathComponent : MonoBehaviour
    {
        private ScoreSystem scoreSystem;
        private EnemyDeathController enemyDeathController;

        [SerializeField]
        private int pointsToGiveWhenKilled;

        [Inject]
        private void Construct(ScoreSystem scoreSystem, EnemyDeathController enemyDeathController)
        {
            this.scoreSystem = scoreSystem;
            this.enemyDeathController = enemyDeathController;
        }

        public virtual void OnDie()
        {
            scoreSystem.Add(pointsToGiveWhenKilled);
            enemyDeathController.DecreaseAmountAliveEnemies();
        }
    }
}