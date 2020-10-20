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

        [Inject]
        private void Construct(AsteroidComponent.Factory asteroidFactory, InitialPositionSpawner initialPositionSpawner, EnemyDeathController enemyDeathController)
        {
            this.asteroidFactory = asteroidFactory;
            this.initialPositionSpawner = initialPositionSpawner;
            this.enemyDeathController = enemyDeathController;
        }

        private void Start()
        {
            enemyDeathController.IncreaseAmountAliveEnemies(INITIAL_ASTEROID_AMOUNT);

            for (int i = 0; i < INITIAL_ASTEROID_AMOUNT; i++)
            {
                asteroidFactory.Create(CreateInitialPosition(), CreateInitialRotation());
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