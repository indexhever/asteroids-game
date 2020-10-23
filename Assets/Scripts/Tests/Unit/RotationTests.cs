using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidsGame.Controller;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RotationTests
    {
        [Test]
        public void RotatingLeft()
        {
            RotationListener rotationListener = CreateRotationListener();

            rotationListener.RotateLeft();
            bool hasHotatedLeft = (rotationListener as MockRotationListener).HasRotateLeft;

            Assert.IsTrue(hasHotatedLeft);
        }

        private RotationListener CreateRotationListener()
        {
            return new MockRotationListener();
        }
    }
}
