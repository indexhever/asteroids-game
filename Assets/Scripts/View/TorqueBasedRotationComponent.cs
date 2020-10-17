using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.View
{
    public class TorqueBasedRotationComponent : MonoBehaviour
    {
        private const int LEFT_TURN_MULTIPLIER = 1;
        private const int RIGHT_TURN_MULTIPLIER = -1;

        private float turn = 1;

        [SerializeField]
        private Rigidbody2D objectRigidbody;
        [SerializeField]
        public float torque;

        public void OnLeftRotate()
        {
            turn = LEFT_TURN_MULTIPLIER;
            AddRotation();
        }

        public void OnRightRotate()
        {
            turn = RIGHT_TURN_MULTIPLIER;
            AddRotation();
        }

        private void AddRotation()
        {
            objectRigidbody.AddTorque(torque * turn);
        }
    }
}