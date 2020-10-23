using UnityEngine;
using System.Collections;

namespace AsteroidsGame.View
{
    public enum CameraBorder
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public interface CameraStatsRetriever
    {
        float ViewPortMinimumValue { get; }
        float ViewPortMaximumValue { get; }

        CameraBorder GetRandomBorder();
        Vector2 ConvertToWorldPosition(Vector2 initialPosition);
    }
}