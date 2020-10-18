using UnityEngine;
using System.Collections;
using AsteroidsGame.View;
using System;

namespace Tests
{
    public class MockCameraStatsRetriever : CameraStatsRetriever
    {
        private Func<CameraBorder> mockRandomBorderReturner;
        private Func<int> mockViewPortMinValueReturner;
        private Func<int> mockViewPortMaxValueReturner;

        public MockCameraStatsRetriever(Func<CameraBorder> mockRandomBorderReturner, Func<int> mockViewPortMinValueReturner, Func<int> mockViewPortMaxValueReturner)
        {
            this.mockRandomBorderReturner = mockRandomBorderReturner;
            this.mockViewPortMinValueReturner = mockViewPortMinValueReturner;
            this.mockViewPortMaxValueReturner = mockViewPortMaxValueReturner;
        }

        public float ViewPortMinimumValue => mockViewPortMinValueReturner();

        public float ViewPortMaximumValue => mockViewPortMaxValueReturner();

        public Vector2 ConvertToWorldPosition(Vector2 initialPosition)
        {
            return initialPosition;
        }

        public CameraBorder GetRandomBorder()
        {
            return mockRandomBorderReturner();
        }
    }
}