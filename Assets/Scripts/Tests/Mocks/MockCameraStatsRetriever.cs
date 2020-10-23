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
        private Func<Vector2, Vector2> convertToWorldPosition;

        public MockCameraStatsRetriever(Func<CameraBorder> mockRandomBorderReturner, Func<int> mockViewPortMinValueReturner, Func<int> mockViewPortMaxValueReturner, Func<Vector2, Vector2> convertToWorldPosition)
        {
            this.mockRandomBorderReturner = mockRandomBorderReturner;
            this.mockViewPortMinValueReturner = mockViewPortMinValueReturner;
            this.mockViewPortMaxValueReturner = mockViewPortMaxValueReturner;
            this.convertToWorldPosition = convertToWorldPosition;
        }

        public MockCameraStatsRetriever(Func<CameraBorder> mockRandomBorderReturner, Func<int> mockViewPortMinValueReturner, Func<int> mockViewPortMaxValueReturner)
        {
            this.mockRandomBorderReturner = mockRandomBorderReturner;
            this.mockViewPortMinValueReturner = mockViewPortMinValueReturner;
            this.mockViewPortMaxValueReturner = mockViewPortMaxValueReturner;
            this.convertToWorldPosition = (currentPosition) => currentPosition;
        }

        public float ViewPortMinimumValue => mockViewPortMinValueReturner();

        public float ViewPortMaximumValue => mockViewPortMaxValueReturner();

        public Vector2 ConvertToWorldPosition(Vector2 initialPosition)
        {
            return convertToWorldPosition(initialPosition);
        }

        public CameraBorder GetRandomBorder()
        {
            return mockRandomBorderReturner();
        }
    }
}