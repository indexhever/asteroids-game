using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidsGame.Controller;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CollisionTests
    {
        [Test]
        public void WhenTwoDisposablesCollideTheyAreDisposed()
        {
            CollisionHandler collisionHandler = CreateCollisionHandler();
            IDisposable firstDisposable = CreateDisposable();
            IDisposable secondDisposable = CreateDisposable();

            collisionHandler.HandleCollisionBetween(firstDisposable, secondDisposable);
            bool areBothDisposableDisposed = (firstDisposable as MockDisposable).IsDisposed && (secondDisposable as MockDisposable).IsDisposed;

            Assert.IsTrue(areBothDisposableDisposed);
        }

        private IDisposable CreateDisposable()
        {
            return new MockDisposable();
        }

        private CollisionHandler CreateCollisionHandler()
        {
            return new CollisionHandler();
        }
    }
}
