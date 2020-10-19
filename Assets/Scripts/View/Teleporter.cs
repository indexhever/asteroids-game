using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class Teleporter : MonoBehaviour
    {
        private Vector3 currentPosition;
        private Vector2 minimumPositionInWorldSpace;
        private Vector2 maximumPositionInWorldSpace;
        private CameraStatsRetriever cameraStatsRetriever;

        [Inject]
        private void Construct(CameraStatsRetriever cameraStatsRetriever)
        {
            this.cameraStatsRetriever = cameraStatsRetriever;
        }

        private void Start()
        {
            SetupMaximumPosition();
            SetupMinimumPosition();
        }

        public void OnLeaveScreen()
        {
            TeleportToOpositeSide();
        }

        private void TeleportToOpositeSide()
        {
            currentPosition = transform.position;

            if (IsObjectOutOfHorizontalBounds())
                currentPosition.x = -currentPosition.x;
            if (IsObjectOutOfVerticalBounds())
                currentPosition.y = -currentPosition.y;

            transform.position = currentPosition;
        }

        private bool IsObjectOutOfHorizontalBounds()
        {
            return currentPosition.x > maximumPositionInWorldSpace.x || currentPosition.x < minimumPositionInWorldSpace.x;
        }

        private bool IsObjectOutOfVerticalBounds()
        {
            return currentPosition.y > maximumPositionInWorldSpace.y || currentPosition.y < minimumPositionInWorldSpace.y;
        }

        private void SetupMaximumPosition()
        {
            float maximumViewportValue = cameraStatsRetriever.ViewPortMaximumValue;

            maximumPositionInWorldSpace =  cameraStatsRetriever.ConvertToWorldPosition(new Vector2(maximumViewportValue, maximumViewportValue));
        }

        private void SetupMinimumPosition()
        {
            float minimumViewportValue = cameraStatsRetriever.ViewPortMinimumValue;

            minimumPositionInWorldSpace =  cameraStatsRetriever.ConvertToWorldPosition(new Vector2(minimumViewportValue, minimumViewportValue));
        }
    }
}