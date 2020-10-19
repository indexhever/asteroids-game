using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidsGame.Controller;
using AsteroidsGame.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TeleportTests
    {
        [Test]
        public void WhenObjectIsAboveVerticalLimitItIsTeleportedToBottom()
        {
            float verticalLimit = 1.0f;
            Func<Vector2, Vector2> convertToWorldPosition = (objectPositionInViewPort) => objectPositionInViewPort;
            CameraStatsRetriever cameraStatsRetriever = CreateCameraStatsRetriever(convertToWorldPosition);
            Vector2 expectedTeleportedPosition = new Vector2(0, -(verticalLimit + 0.5f)); ;
            Vector2 currentObjectPosition = new Vector2(0, verticalLimit + 0.5f);
            Teleporter teleporter = CreateTeleporter(() => currentObjectPosition, cameraStatsRetriever);

            Vector2 teleportedPosition = teleporter.GetTeleportedPosition();

            Assert.AreEqual(expectedTeleportedPosition, teleportedPosition);
        }

        private CameraStatsRetriever CreateCameraStatsRetriever(Func<Vector2, Vector2> convertToWorldPosition)
        {
            Func<int> mockViewPortMinValueReturner = () => 0;
            Func<int> mockViewPortMaxValueReturner = () => 1;
            return new MockCameraStatsRetriever(null, mockViewPortMinValueReturner, mockViewPortMaxValueReturner, convertToWorldPosition);
        }

        private Teleporter CreateTeleporter(Func<Vector2> currentObjectPosition, CameraStatsRetriever cameraStatsRetriever)
        {
            return new Teleporter(currentObjectPosition, cameraStatsRetriever);
        }
    }
}