using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.Controller
{
    public interface MovementListener
    {
        void OnMoveInput();
    }
}