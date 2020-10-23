using UnityEngine;
using System.Collections;

namespace AsteroidsGame.View
{
    public interface LifeVisual
    {
        void UpdatWithNewRemainingLife(int remainingLife);
    }
}