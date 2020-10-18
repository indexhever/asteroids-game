using UnityEngine;
using System.Collections;
using AsteroidsGame.View;
using System;

namespace AsteroidsGame.Controller
{
    public class InitialPositionSpawner
    {
        private CameraStatsRetriever cameraStatsRetriever;
        private Func<float, float, float> randomFunction;

        public InitialPositionSpawner(CameraStatsRetriever cameraStatsRetriever, Func<float, float, float> randomFunction)
        {
            this.cameraStatsRetriever = cameraStatsRetriever;
            this.randomFunction = randomFunction;
        }

        public Vector2 CreatePosition()
        {
            CameraBorder cameraBorder = cameraStatsRetriever.GetRandomBorder();
            Vector2 initialPosition = Vector2.zero;

            switch (cameraBorder)
            {
                case CameraBorder.Left:
                    initialPosition = new Vector2(0, GetRandomViewPortValue());
                    break;
                
                case CameraBorder.Right:
                    initialPosition = new Vector2(1, GetRandomViewPortValue());
                    break;
                
                case CameraBorder.Top:
                    initialPosition = new Vector2(GetRandomViewPortValue(), 1);
                    break;
                
                case CameraBorder.Bottom:
                    initialPosition = new Vector2(GetRandomViewPortValue(), 0);
                    break;
            }

            return cameraStatsRetriever.ConvertToWorldPosition(initialPosition);
        }

        private float GetRandomViewPortValue()
        {
            return randomFunction(cameraStatsRetriever.ViewPortMinimumValue, cameraStatsRetriever.ViewPortMaximumValue);
        }
    }
}