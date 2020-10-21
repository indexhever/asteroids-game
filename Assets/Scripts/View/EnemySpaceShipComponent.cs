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
        private IMemoryPool pool;
        private bool isAlive;

        [SerializeField]
        private ForceBasedMovementComponent forceBasedMovementComponent;
        [SerializeField]
        private UnityEvent OnDie;

        public void OnSpawned(Vector2 initialPosition, Vector3 initialRotation, IMemoryPool pool)
        {
            this.pool = pool;
            transform.position = initialPosition;
            transform.Rotate(initialRotation);
            forceBasedMovementComponent.OnMoveInput();
            isAlive = true;

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

            OnDie?.Invoke();
        }

        public void ReturnToPoolAlive()
        {
            pool.Despawn(this);
        }

        public class Factory : RuntimeGameObjectFactory<Vector2, Vector3, EnemySpaceShipComponent>
        {

        }
    }
}