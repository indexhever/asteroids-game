using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsteroidsGame.Controller;

namespace Tests
{
    public class MockMovementInputDetector : MovementInputDetector
    {
        private MovementListener movementListener;

        public MockMovementInputDetector(MovementListener movementListener)
        {
            this.movementListener = movementListener;
        }

        public void DetectMovement()
        {
            movementListener.OnMoveInput();
        }
    }
}