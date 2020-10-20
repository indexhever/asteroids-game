using UnityEngine;
using System.Collections;

namespace AsteroidsGame.Controller
{
    public interface GamePauseController
    {
        void Pause();
        void Resume();
    }
}