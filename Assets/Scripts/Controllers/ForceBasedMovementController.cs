using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.Controller
{
    public class ForceBasedMovementController : MovementListener
    {
        private Action applyForce;
        public ForceBasedMovementController(Action applyForce)
        {
            this.applyForce = applyForce;
        }

        public void OnMoveInput()
        {
            applyForce();
        }

        public class Factory : PlaceholderFactory<Action, ForceBasedMovementController>
        {

        }
    }
}