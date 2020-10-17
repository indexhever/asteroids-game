using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteroidsGame.View
{
    public class KeyboardRotationInputDetector : MonoBehaviour
    {
        [SerializeField]
        UnityEvent OnLeft, OnRight;

        private void FixedUpdate()
        {
            if (HasReceivedLeftRotationEvent())
            {
                SendLeftRotationEvent();
            } 
            else if (HasReceivedRightRotationEvent())
            {
                SendRightRotationEvent();
            }
        }

        private bool HasReceivedLeftRotationEvent()
        {
            return Input.GetKey(KeyCode.LeftArrow);
        }

        private bool HasReceivedRightRotationEvent()
        {
            return Input.GetKey(KeyCode.RightArrow);
        }

        private void SendLeftRotationEvent()
        {
            OnLeft?.Invoke();
        }

        private void SendRightRotationEvent()
        {
            OnRight?.Invoke();
        }
    }
}