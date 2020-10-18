using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.View
{
    public class DefaultCameraStatsRetriever : CameraStatsRetriever
    {
        private Camera gameCamera;
        public DefaultCameraStatsRetriever(Camera gameCamera)
        {
            this.gameCamera = gameCamera;
        }

        public float ViewPortMinimumValue => 0.0f;

        public float ViewPortMaximumValue => 1.0f;

        public Vector2 ConvertToWorldPosition(Vector2 initialPosition)
        {
            return gameCamera.ViewportToWorldPoint(initialPosition);
        }

        public CameraBorder GetRandomBorder()
        {
            Array values = Enum.GetValues(typeof(CameraBorder));
            int randomIndex = UnityEngine.Random.Range(0, values.Length);
            
            return (CameraBorder)values.GetValue(randomIndex);
        }
    }
}