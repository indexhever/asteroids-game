using AsteroidsGame.Controller;
using AsteroidsGame.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace AsteroidsGame.View
{
    public class PlayerComponent : MonoBehaviour, IDisposable
    {
        private const float SECONDS_WAIT_RETURN_ALIVE = 1.5f;
        private const int POINTS_LOSE_WHEN_DIE = 5;

        private ScoreSystem scoreSystem;
        private LifeController lifeController;
        private Vector2 initialPosition;
        private bool isDead;

        [SerializeField]
        private Rigidbody2D objectRigidbody;
        [SerializeField]
        private UnityEvent OnDie, OnReturnAlive;        

        [Inject]
        private void Construct(ScoreSystem scoreSystem, LifeController lifeController)
        {
            this.scoreSystem = scoreSystem;
            this.lifeController = lifeController;
        }

        private void Start()
        {
            initialPosition = transform.position;
        }

        public void Dispose()
        {
            if (isDead)
                return;

            isDead = true;
            DisablePhyscs();
            ResetRotation();
            ResetPosition();
            ResetSpeed();
            OnDie?.Invoke();
            scoreSystem.Remove(POINTS_LOSE_WHEN_DIE);
            lifeController.Die();
            StartCoroutine(ReturnAliveAfterSeconds());
        }

        private void ResetRotation()
        {
            transform.up = Vector3.up;
        }

        private void ResetPosition()
        {
            transform.position = initialPosition;
        }

        private void ResetSpeed()
        {
            objectRigidbody.velocity = Vector3.zero;
        }

        private IEnumerator ReturnAliveAfterSeconds()
        {
            yield return new WaitForSeconds(SECONDS_WAIT_RETURN_ALIVE);

            OnReturnAlive?.Invoke();
            EnablePhysics();
            isDead = false;
        }

        private void DisablePhyscs()
        {
            objectRigidbody.isKinematic = true;
            objectRigidbody.simulated = false;
        }

        private void EnablePhysics()
        {
            objectRigidbody.isKinematic = false;
            objectRigidbody.simulated = true;
        }
    }
}