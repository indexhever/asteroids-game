using UnityEngine;
using System.Collections;

namespace AsteroidsGame.View
{
    public interface ScoreVisual
    {
        void UpdateWithNewScore(int newScore);
    }
}