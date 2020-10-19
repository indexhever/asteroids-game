using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidsGame.Controllers;
using AsteroidsGame.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreSystemTests
    {
        [Test]
        public void AddingScoreWillIncreaseTotalScore()
        {
            ScoreSystem scoreSystem = CreateScoreSystem(new MockScoreVisual());
            int pointsToAdd = 1;
            int exptedScoreAfterAdding = 1;

            scoreSystem.Add(pointsToAdd);

            Assert.AreEqual(exptedScoreAfterAdding, scoreSystem.TotalScore);
        }

        [Test]
        public void RemovingScoreWillDecreaseTotalScore()
        {
            ScoreSystem scoreSystem = CreateScoreSystem(new MockScoreVisual());
            int pointsToRemove = 1;
            int exptedScoreAfterRemoving = 0;
            scoreSystem.Add(1);

            scoreSystem.Remove(pointsToRemove);

            Assert.AreEqual(exptedScoreAfterRemoving, scoreSystem.TotalScore);
        }

        [Test]
        public void AddingScoreWillUpdateScoreVisualWithTotalScore()
        {
            ScoreVisual scoreVisual = CreateScoreVisual();
            ScoreSystem scoreSystem = CreateScoreSystem(scoreVisual);
            int pointsToAdd = 1;
            int exptedScoreAfterAdding = 1;

            scoreSystem.Add(pointsToAdd);
            int scoreVisualReceivedNewScore = (scoreVisual as MockScoreVisual).ReceivedNewScore;

            Assert.AreEqual(exptedScoreAfterAdding, scoreVisualReceivedNewScore);
        }

        [Test]
        public void RemovingScoreWillUpdateScoreVisualWithTotalScore()
        {
            ScoreVisual scoreVisual = CreateScoreVisual();
            ScoreSystem scoreSystem = CreateScoreSystem(scoreVisual);
            int pointsToRemove = 1;
            int exptedScoreAfterRemoving = 0;
            scoreSystem.Add(1);

            scoreSystem.Remove(pointsToRemove);
            int scoreVisualReceivedNewScore = (scoreVisual as MockScoreVisual).ReceivedNewScore;

            Assert.AreEqual(exptedScoreAfterRemoving, scoreVisualReceivedNewScore);
        }

        private ScoreVisual CreateScoreVisual()
        {
            return new MockScoreVisual();
        }

        private ScoreSystem CreateScoreSystem(ScoreVisual scoreVisual)
        {
            return new ScoreSystem(scoreVisual);
        }
    }
}
