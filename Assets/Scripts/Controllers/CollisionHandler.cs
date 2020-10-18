using UnityEngine;
using System.Collections;
using System;

namespace AsteroidsGame.Controller
{
    public class CollisionHandler
    {
        public void HandleCollisionBetween(IDisposable firstDisposable, IDisposable secondDisposable)
        {
            firstDisposable.Dispose();
            secondDisposable.Dispose();
        }
    }
}