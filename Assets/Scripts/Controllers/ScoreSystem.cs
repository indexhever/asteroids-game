
using UnityEngine;
using System.Collections;
using System;
using AsteroidsGame.View;

namespace AsteroidsGame.Controller
{
    public class ScoreSystem
    {
        private ScoreVisual scoreVisual;

        public ScoreSystem(ScoreVisual scoreVisual)
        {
            this.scoreVisual = scoreVisual;
        }

        public int TotalScore { get; private set; }

        public void Add(int pointsToAdd)
        {
            TotalScore += pointsToAdd;
            UpdateVisual();
        }

        public void Remove(int pointsToRemove)
        {
            TotalScore -= pointsToRemove;
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            scoreVisual.UpdateWithNewScore(TotalScore);
        }
    }
}