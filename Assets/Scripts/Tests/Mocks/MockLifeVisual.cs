using UnityEngine;
using System.Collections;
using AsteroidsGame.View;

namespace Tests
{
    public class MockLifeVisual : LifeVisual
    {
        public int RemainingLifeShown { get; private set; }

        public void UpdatWithNewRemainingLife(int newRemainingLife)
        {
            RemainingLifeShown = newRemainingLife;
        }
    }
}