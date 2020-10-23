using UnityEngine;
using System.Collections;
using AsteroidsGame.View;

namespace Tests
{
    public class MockScoreVisual : ScoreVisual
    {
        public int ReceivedNewScore { get; internal set; }

        public void UpdateWithNewScore(int totalScore)
        {
            ReceivedNewScore = totalScore;
        }
    }
}