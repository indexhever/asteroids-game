using AsteroidsGame.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    // TODO: remove duplication between this spawner and asteroid one
    public class EnemySpaceShipSpawner : MonoBehaviour
    {
        private const float SECONDS_WAIT_NEXT_SPAWN = 10.0f;

        private EnemySpaceShipComponent.Factory factory;
        private CameraStatsRetriever cameraStatsRetriever;
        private int currentScreenSide;

        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private int amountToSpawn;

        [Inject]
        private void Construct(EnemySpaceShipComponent.Factory factory, /*InitialPositionSpawner initialPositionSpawner, */CameraStatsRetriever cameraStatsRetriever)
        {
            this.factory = factory;
            //this.initialPositionSpawner = initialPositionSpawner;
            this.cameraStatsRetriever = cameraStatsRetriever;
        }

        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            for(int i = 0; i < amountToSpawn; i++)
            {
                yield return new WaitForSeconds(SECONDS_WAIT_NEXT_SPAWN);

                factory.Create(prefab, CreateRandomInitialPosition(), CreateRotationBasedOnCurrentScreenSide());
            }
        }

        private Vector2 CreateRandomInitialPosition()
        {
            // take left or right
            SortScreenSideToSpawn();
            float randomX = GetXFromScreenSide();

            // take random height
            float randomY = UnityEngine.Random.Range(cameraStatsRetriever.ViewPortMinimumValue, cameraStatsRetriever.ViewPortMaximumValue);

            return cameraStatsRetriever.ConvertToWorldPosition(new Vector2(randomX, randomY));
        }

        private void SortScreenSideToSpawn()
        {
            currentScreenSide = UnityEngine.Random.Range(0, 2);
        }

        private float GetXFromScreenSide()
        {
            float rightX = cameraStatsRetriever.ViewPortMaximumValue;
            float leftX = cameraStatsRetriever.ViewPortMinimumValue;
            return currentScreenSide == 0 ? leftX : rightX;
        }

        private Vector3 CreateRotationBasedOnCurrentScreenSide()
        {
            float rotatedFacingLeft = 90;
            float rotatedFacingRight = 270;
            // if it is left side, rotate facing right, if not, rotate facing left
            float rotationZ = currentScreenSide == 0 ? rotatedFacingRight : rotatedFacingLeft;

            return new Vector3(0, 0, rotationZ);
        }
    }
}