using AsteroidsGame.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class AsteroidComponent : MonoBehaviour, IPoolable<Vector2, Vector3, IMemoryPool>, IDisposable
    {
        private IMemoryPool pool;

        [SerializeField]
        private ForceBasedMovementComponent forceBasedMovementComponent;
        //private InitialPositionSpawner initialPositionSpawner;

        //[Inject]
        //private void Construct(InitialPositionSpawner initialPositionSpawner)
        //{
        //    this.initialPositionSpawner = initialPositionSpawner;
        //}

        public void OnSpawned(Vector2 initialPosition, Vector3 initialRotation, IMemoryPool pool)
        {
            //transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            //transform.position = initialPositionSpawner.CreatePosition();
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
            // Spawn new smal asteroids
        }

        public class Factory : PlaceholderFactory<Vector2, Vector3, AsteroidComponent>
        {
        }
    }
}