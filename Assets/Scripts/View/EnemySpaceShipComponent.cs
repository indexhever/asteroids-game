using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteroidsGame.View
{
    public class EnemySpaceShipComponent : MonoBehaviour, IDisposable
    {
        [SerializeField]
        private UnityEvent OnDie;

        public void Dispose()
        {
            gameObject.SetActive(false);
        }
    }
}