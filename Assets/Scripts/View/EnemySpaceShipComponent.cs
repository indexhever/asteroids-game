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
        }

        public void Dispose()
        {
            if (!gameObject.activeInHierarchy)
                return;

            pool.Despawn(this);
        }

        public void OnDespawned()
        {
            OnDie?.Invoke();
        }

        public class Factory : RuntimeGameObjectFactory<Vector2, Vector3, EnemySpaceShipComponent>
        {

        }
    }
}