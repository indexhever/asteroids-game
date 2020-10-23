using UnityEngine;
using System.Collections;
using AsteroidsGame.Controller;

namespace Tests
{
    public class MockRotationListener : RotationListener
    {
        public bool HasRotateLeft { get; internal set; }

        public void RotateLeft()
        {
            HasRotateLeft = true;
        }
    }
}