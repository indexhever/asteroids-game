using AsteroidsGame.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class ForceBasedMovementComponent : MonoBehaviour
    {
        private MovementListener movementListener;

        [SerializeField]
        private Rigidbody2D objectRigidbody;
        [SerializeField]
        private float thrust; // 50 is 1 unit per second

        [Inject]
        private void Construct(ForceBasedMovementController.Factory movementFactory)
        {
            this.movementListener = movementFactory.Create(AddForce);
        }

        public void OnMoveInput()
        {
            movementListener.OnMoveInput();
        }

        private void AddForce()
        {
            objectRigidbody.AddForce(transform.up * thrust);
        }
    }
}