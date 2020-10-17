using AsteroidsGame.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteroidsGame.View
{
    public class KeyboardMovementInputDetector : MonoBehaviour
    {
        [SerializeField]
        UnityEvent OnMove;

        private void FixedUpdate()
        {
            if (HasReceivedMovementEvent())
            {
                SendMovementEvent();
            }
        }

        private bool HasReceivedMovementEvent()
        {
            return Input.GetKey(KeyCode.UpArrow);
        }

        private void SendMovementEvent()
        {
            Debug.Log("Sending movement event");
            OnMove?.Invoke();
        }
    }
}