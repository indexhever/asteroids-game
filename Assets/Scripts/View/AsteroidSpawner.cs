using AsteroidsGame.Controller;
using AsteroidsGame.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class AsteroidSpawner : MonoBehaviour
    {
        private const int  INITIAL_ASTEROID_AMOUNT = 5;
        private const int MAX_ROTATION_DEGREE = 360;
        private const int MIN_ROTATION_DEGREE = 0;

        private AsteroidComponent.Factory asteroidFactory;
        private InitialPositionSpawner initialPositionSpawner;
        private EnemyDeathController enemyDeathController;

        [SerializeField]
        private GameObject asteroidPrefab;

        [Inject]
        private void Construct(AsteroidComponent.Factory asteroidFactory, InitialPositionSpawner initialPositionSpawner, EnemyDeathController enemyDeathController)
        {
            this.asteroidFactory = asteroidFactory;
            this.initialPositionSpawner = initialPositionSpawner;
            this.enemyDeathController = enemyDeathController;
        }

        private void Start()
        {
            for (int i = 0; i < INITIAL_ASTEROID_AMOUNT; i++)
            {
                AsteroidComponent asteroidComponent = asteroidFactory.Create(asteroidPrefab, CreateInitialPosition(), CreateInitialRotation());

                EnemySpawnDefinition enemySpawnDefinition = asteroidComponent.GetComponent<EnemySpawnDefinition>();
                enemyDeathController.IncreaseAmountAliveEnemies(enemySpawnDefinition.AmountWillBeSpawn);
            }
        }

        public void Spawn(GameObject gameObject, Vector3 position, int amountOfAsteroidsToSpawnWhenDie)
        {
            StartCoroutine(SpawnCoroutine(gameObject, position, amountOfAsteroidsToSpawnWhenDie));
        }

        private IEnumerator SpawnCoroutine(GameObject gameObject, Vector3 initialPosition, int amountToSpawn)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                asteroidFactory.Create(gameObject, initialPosition, CreateInitialRotation());

                yield return null;
            }
        }

        private Vector2 CreateInitialPosition()
        {
            return initialPositionSpawner.CreatePosition();
        }

        private Vector3 CreateInitialRotation()
        {
            return new Vector3(0, 0, Random.Range(MIN_ROTATION_DEGREE, MAX_ROTATION_DEGREE));
        }
    }
}