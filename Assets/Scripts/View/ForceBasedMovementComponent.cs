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
        private Vector2 currentVelocity;
        private Vector2 newVelocity;

        [SerializeField]
        private Rigidbody2D objectRigidbody;
        [SerializeField]
        private float thrust; // 50 is 1 unit per second
        [SerializeField]
        private float maxSpeed;

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

        public void FixedUpdate()
        {
            LimitSpeedToMaximumAllowed();
        }

        private void LimitSpeedToMaximumAllowed()
        {
            currentVelocity = objectRigidbody.velocity;
            if (!HasAchievedMaximumSpeed())
                return;

            newVelocity = currentVelocity.normalized;
            newVelocity *= maxSpeed;
            objectRigidbody.velocity = newVelocity;
        }

        private bool HasAchievedMaximumSpeed()
        {
            return Mathf.Abs(currentVelocity.x) > maxSpeed || Mathf.Abs(currentVelocity.y) > maxSpeed;
        }
    }
}