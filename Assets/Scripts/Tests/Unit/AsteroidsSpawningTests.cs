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
    public class AsteroidsSpawningTests
    {
        [Test]
        public void InitialSpawnPositionIsAPlaceOnScreenBorders()
        {
            Vector2 expectedPosition = new Vector2(0, 1);
            Func<CameraBorder> mockRandomBorderReturner = () => CameraBorder.Left;
            Func<int> mockViewPortMinValueReturner = () => 0;
            Func<int> mockViewPortMaximumValueReturner = () => 1;
            CameraStatsRetriever cameraStatsRetriever = CreateCameraStatsRetriever(
                                                            mockRandomBorderReturner, 
                                                            mockViewPortMinValueReturner, 
                                                            mockViewPortMaximumValueReturner);
            Func<float, float, float> randomFunction = (minValue, maxVale) => 1.0f;
            InitialPositionSpawner initialSpawnPositioner = CreateInitialSpawnPositioner(cameraStatsRetriever, randomFunction);

            Vector2 initialPosition = initialSpawnPositioner.CreatePosition();

            Assert.AreEqual(expectedPosition, initialPosition);
        }

        [Test]
        public void WhenGettingRandomCameraBorderReturnsLeftBorder()
        {
            Func<CameraBorder> mockRandomBorderReturner = () => CameraBorder.Left;
            CameraStatsRetriever cameraStatsRetriever = CreateCameraStatsRetriever(mockRandomBorderReturner, null, null);

            CameraBorder cameraBorder = cameraStatsRetriever.GetRandomBorder();

            Assert.AreEqual(CameraBorder.Left, cameraBorder);
        }

        [Test]
        public void GetMinimumViewPortValue()
        {
            int expectedViewPortMinimumValue = 0;
            Func<int> mockViewPortMinValueReturner = () => 0;
            CameraStatsRetriever cameraStatsRetriever = CreateCameraStatsRetriever(null, mockViewPortMinValueReturner, null);

            float viewPortMinimumValue = cameraStatsRetriever.ViewPortMinimumValue;

            Assert.AreEqual(expectedViewPortMinimumValue, viewPortMinimumValue);
        }

        [Test]
        public void GetMaximumViewPortValue()
        {
            int expectedViewPortMaximumValue = 1;
            Func<int> mockViewPortMaximumValueReturner = () => 1;
            CameraStatsRetriever cameraStatsRetriever = CreateCameraStatsRetriever(null, null, mockViewPortMaximumValueReturner);

            float viewPortMaximumValue = cameraStatsRetriever.ViewPortMaximumValue;

            Assert.AreEqual(expectedViewPortMaximumValue, viewPortMaximumValue);
        }

        private InitialPositionSpawner CreateInitialSpawnPositioner(CameraStatsRetriever cameraStatsRetriever, Func<float, float, float> randomFunction)
        {
            return new InitialPositionSpawner(cameraStatsRetriever, randomFunction);
        }

        private CameraStatsRetriever CreateCameraStatsRetriever(Func<CameraBorder> mockRandomBorderReturner, Func<int> mockViewPortMinValueReturner, Func<int> mockViewPortMaxValueReturner)
        {
            return new MockCameraStatsRetriever(mockRandomBorderReturner, mockViewPortMinValueReturner, mockViewPortMaxValueReturner);
        }
    }
}
