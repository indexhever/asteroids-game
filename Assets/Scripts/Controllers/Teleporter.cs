using UnityEngine;
using System.Collections;
using System;
using AsteroidsGame.View;
using Zenject;

namespace AsteroidsGame.Controller
{
    public class Teleporter
    {
        private Vector3 currentPosition;
        private Vector2 minimumPositionInWorldSpace;
        private Vector2 maximumPositionInWorldSpace;
        private Func<Vector2> currentObjectPosition;
        private CameraStatsRetriever cameraStatsRetriever;

        public Teleporter(Func<Vector2> currentObjectPosition, CameraStatsRetriever cameraStatsRetriever)
        {
            this.currentObjectPosition = currentObjectPosition;
            this.cameraStatsRetriever = cameraStatsRetriever;
            SetupMaximumPosition();
            SetupMinimumPosition();
        }

        public Vector2 GetTeleportedPosition()
        {
            currentPosition = currentObjectPosition();

            if (IsObjectOutOfHorizontalBounds())
                currentPosition.x = -currentPosition.x;
            if (IsObjectOutOfVerticalBounds())
                currentPosition.y = -currentPosition.y;

            return currentPosition;
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

            maximumPositionInWorldSpace = cameraStatsRetriever.ConvertToWorldPosition(new Vector2(maximumViewportValue, maximumViewportValue));
        }

        private void SetupMinimumPosition()
        {
            float minimumViewportValue = cameraStatsRetriever.ViewPortMinimumValue;

            minimumPositionInWorldSpace = cameraStatsRetriever.ConvertToWorldPosition(new Vector2(minimumViewportValue, minimumViewportValue));
        }

        public class Factory : PlaceholderFactory<Func<Vector2>, Teleporter>
        {

        }
    }
}