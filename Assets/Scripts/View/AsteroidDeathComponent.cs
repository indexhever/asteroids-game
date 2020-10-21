using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;
using Zenject;
using System;

namespace AsteroidsGame.View
{
    public class AsteroidDeathComponent : EnemyDeathComponent, EnemySpawnDefinition
    {
        [SerializeField]
        private AsteroidComponent asteroidToSpawnWhenDie;
        [SerializeField]
        private int amountOfAsteroidsToSpawnWhenDie;

        // current asteroid + amount it will spawn when die
        public int AmountWillBeSpawn => 1 + amountOfAsteroidsToSpawnWhenDie; 

        public override void OnDie()
        {
            base.OnDie();

            SpawnDebris();
        }

        // TODO: spawn more asteroids when this one is dead
        private void SpawnDebris()
        {
            
        }
    }
}