using AsteroidsGame.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class EnemySpaceShipSpawner : MonoBehaviour
    {
        private EnemySpaceShipComponent.Factory factory;
        private EnemyDeathController enemyDeathController;

        [SerializeField]
        private GameObject prefab;

        [Inject]
        private void Construct(EnemySpaceShipComponent.Factory factory, /*InitialPositionSpawner initialPositionSpawner, */EnemyDeathController enemyDeathController)
        {
            this.factory = factory;
            //this.initialPositionSpawner = initialPositionSpawner;
            this.enemyDeathController = enemyDeathController;
        }

        private void Start()
        {
            factory.Create(prefab, transform.position, Vector2.up);
        }
    }
}