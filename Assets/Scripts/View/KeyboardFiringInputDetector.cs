using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteroidsGame.View
{
    public class KeyboardFiringInputDetector : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnFiring;

        private void Update()
        {
            if (HasReceivedFireEvent())
            {
                SendFireEvent();
            }
        }

        private bool HasReceivedFireEvent()
        {
            return Input.GetKeyDown(KeyCode.LeftControl);
        }

        private void SendFireEvent()
        {
            OnFiring?.Invoke();
        }
    }
}