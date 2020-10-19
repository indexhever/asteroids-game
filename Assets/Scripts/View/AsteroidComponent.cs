using AsteroidsGame.Controller;
using AsteroidsGame.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class AsteroidComponent : MonoBehaviour, IPoolable<Vector2, Vector3, ScoreSystem, IMemoryPool>, IDisposable
    {
        private IMemoryPool pool;
        private ScoreSystem scoreSystem;

        [SerializeField]
        private ForceBasedMovementComponent forceBasedMovementComponent;

        public void OnSpawned(Vector2 initialPosition, Vector3 initialRotation, ScoreSystem scoreSystem, IMemoryPool pool)
        {
            this.pool = pool;
            this.scoreSystem = scoreSystem;
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
            // Spawn new smal asteroids
            scoreSystem.Add(10);
        }

        public class Factory : PlaceholderFactory<Vector2, Vector3, ScoreSystem, AsteroidComponent>
        {
        }
    }
}