using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;
using Zenject;
using System;

namespace AsteroidsGame.View
{
    public class AsteroidDeathComponent : EnemyDeathComponent, EnemySpawnDefinition
    {
        private AsteroidSpawner asteroidSpawner;

        [SerializeField]
        private AsteroidComponent asteroidToSpawnWhenDie;
        [SerializeField]
        private int amountOfAsteroidsToSpawnWhenDie;

        // current asteroid + amount it will spawn when die
        public int AmountWillBeSpawn => 1 + amountOfAsteroidsToSpawnWhenDie; 

        [Inject]
        private void Construct(AsteroidSpawner asteroidFactory)
        {
            this.asteroidSpawner = asteroidFactory;
        }

        public override void OnDie()
        {
            base.OnDie();

            SpawnDebris();
        }

        private void SpawnDebris()
        {
            asteroidSpawner.Spawn(asteroidToSpawnWhenDie.gameObject, transform.position, amountOfAsteroidsToSpawnWhenDie);
        }
    }
}