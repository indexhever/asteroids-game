using AsteroidsGame.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
    public class MockMovementListener : MovementListener
    {
        public bool HasMoved { get; internal set; }

        public void OnMoveInput()
        {
            HasMoved = true;
        }
    }
}