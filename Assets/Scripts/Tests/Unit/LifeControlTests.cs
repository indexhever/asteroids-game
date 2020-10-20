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
    public class LifeControlTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void RemainingLifeDecreasesWhenDie()
        {
            int expectedRemainingLife = 1;
            int initialLife = 2;
            LifeController lifeController = CreateLifeController(initialLife, new MockLifeVisual(), new MockGameOverController());

            lifeController.Die();
            int remainingLife = lifeController.RemainingLife;

            Assert.AreEqual(expectedRemainingLife, remainingLife);
        }

        [Test]
        public void LifeVisualIsUpdatedAfterDeath()
        {
            int initialLife = 2;
            int expectedRemainingLifeShownInVisual = 1;
            LifeVisual lifeVisual = CreateLifeVisual();
            LifeController lifeController = CreateLifeController(initialLife, lifeVisual, new MockGameOverController());

            lifeController.Die();
            int remainingLifeShownInVisual = (lifeVisual as MockLifeVisual).RemainingLifeShown;

            Assert.AreEqual(expectedRemainingLifeShownInVisual, remainingLifeShownInVisual);
        }

        [Test]
        public void GameOverIsTriggeredWhenRemainingLifeIsZero()
        {
            int initialLife = 1;
            LifeVisual lifeVisual = CreateLifeVisual();
            GameOverController gameOverController = CreateGameOverController();
            LifeController lifeController = CreateLifeController(initialLife, lifeVisual, gameOverController);

            lifeController.Die();
            bool isGameOverTriggered = (gameOverController as MockGameOverController).IsTriggered;

            Assert.IsTrue(isGameOverTriggered);
        }

        private GameOverController CreateGameOverController()
        {
            return new MockGameOverController();
        }

        private LifeVisual CreateLifeVisual()
        {
            return new MockLifeVisual();
        }

        private LifeController CreateLifeController(int initialLife, LifeVisual lifeVisual, GameOverController gameOverController)
        {
            return new LifeController(initialLife, lifeVisual, gameOverController);
        }
    }
}