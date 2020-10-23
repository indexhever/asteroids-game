using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class BulletComponent : MonoBehaviour, IPoolable<Vector2, Vector2, IMemoryPool>, IDisposable
    {
        private const float SECONDS_BEFORE_INVOKING_AUTO_DESTRUCTION = 1.4f;
        private const string AUTO_DESTRUCTION_FUNCION = "Dispose";

        private IMemoryPool pool;
        private Vector2 initialPosition;

        [SerializeField]
        private Rigidbody2D objectRigidbody;
        [SerializeField]
        private ForceBasedMovementComponent movementComponent;

        private void Start()
        {
            initialPosition = transform.position;
        }

        public void OnSpawned(Vector2 spawnPosition, Vector2 direction, IMemoryPool pool)
        {
            this.pool = pool;
            transform.position = spawnPosition;
            transform.up = direction;
            movementComponent.OnMoveInput();
            Invoke(AUTO_DESTRUCTION_FUNCION, SECONDS_BEFORE_INVOKING_AUTO_DESTRUCTION);
            
        }

        public void Dispose()
        {
            if (!gameObject.activeInHierarchy)
                return;
            pool.Despawn(this);
        }

        public void OnDespawned()
        {
            CancelInvoke(AUTO_DESTRUCTION_FUNCION);
            transform.position = initialPosition;
        }

        public class Factory : PlaceholderFactory<Vector2, Vector2, BulletComponent>
        {
        }
    }
}