using AsteroidsGame.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace AsteroidsGame.View
{
    public class EnemySpaceShipComponent : MonoBehaviour, IPoolable<Vector2, Vector3, IMemoryPool>, IDisposable
    {
        private const float SECONDS_WAIT_FIRING_AGAIN = 2.0f;

        private IMemoryPool pool;
        private bool isAlive;

        [SerializeField]
        private ForceBasedMovementComponent forceBasedMovementComponent;
        [SerializeField]
        private FirerComponent firer; 
        [SerializeField]
        private UnityEvent OnDie;

        public void OnSpawned(Vector2 initialPosition, Vector3 initialRotation, IMemoryPool pool)
        {
            this.pool = pool;
            transform.position = initialPosition;
            transform.Rotate(initialRotation);
            forceBasedMovementComponent.OnMoveInput();
            isAlive = true;
            StartCoroutine(FireToNewDirection());
        }

        private IEnumerator FireToNewDirection()
        {
            while (isAlive)
            {
                yield return new WaitForSeconds(SECONDS_WAIT_FIRING_AGAIN);
                firer.transform.RotateAround(transform.position, Vector3.forward, CreateRandomAngle());
                firer.OnFiring();                
            }
        }

        private int CreateRandomAngle()
        {
            return UnityEngine.Random.Range(0, 360);
        }

        public void Dispose()
        {
            if (!gameObject.activeInHierarchy)
                return;

            isAlive = false;
            pool.Despawn(this);
        }

        public void OnDespawned()
        {
            if (isAlive)
                return;

            StopFiring();
            ResetRotation();
            OnDie?.Invoke();
        }

        public void ReturnToPoolAlive()
        {
            StopFiring();
            ResetRotation();            
            pool.Despawn(this);
        }

        private void StopFiring()
        {
            StopCoroutine(FireToNewDirection());
        }

        private void ResetRotation()
        {
            transform.up = Vector3.up;
        }

        public class Factory : RuntimeGameObjectFactory<Vector2, Vector3, EnemySpaceShipComponent>
        {

        }
    }
}