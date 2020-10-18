using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class BulletComponent : MonoBehaviour, IPoolable<Vector2, Vector2, IMemoryPool>, IDisposable
    {
        private IMemoryPool pool;

        [SerializeField]
        private Rigidbody2D objectRigidbody;
        [SerializeField]
        private ForceBasedMovementComponent movementComponent;

        public void OnSpawned(Vector2 initialPosition, Vector2 direction, IMemoryPool pool)
        {
            this.pool = pool;
            transform.position = initialPosition;
            transform.up = direction;
            movementComponent.OnMoveInput();
        }

        public void Dispose()
        {
            
        }

        public void OnDespawned()
        {
            
        }

        public class Factory : PlaceholderFactory<Vector2, Vector2, BulletComponent>
        {
        }
    }
}