using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.View
{
    public class SpeedLimiterComponent : MonoBehaviour
    {
        private Vector2 currentVelocity;
        private Vector2 newVelocity;

        [SerializeField]
        private float maxSpeed;

        [SerializeField]
        private Rigidbody2D objectRigidbody;

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