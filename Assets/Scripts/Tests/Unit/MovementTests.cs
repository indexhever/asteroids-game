using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AsteroidsGame.Controller;

namespace Tests
{
    public class MovementTests
    {
        [Test]
        public void WhenMovementIsDetectedTheListenerReceiveMovementAction()
        {
            MovementListener movementListener = CreateMovementListener();
            MovementInputDetector movementInpuDetector = CreateMovementInputDetector(movementListener);

            movementInpuDetector.DetectMovement();
            bool hasListenerMoved = (movementListener as MockMovementListener).HasMoved;

            Assert.IsTrue(hasListenerMoved);
        }

        private MovementListener CreateMovementListener()
        {
            return new MockMovementListener();
        }

        private MovementInputDetector CreateMovementInputDetector(MovementListener movementListener)
        {
            return new MockMovementInputDetector(movementListener);
        }
    }
}
