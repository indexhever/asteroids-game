using AsteroidsGame.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class CollisionDetectorComponent : MonoBehaviour
    {
        private IDisposable currentDisposable;
        private IDisposable collidedDisposable;
        private CollisionHandler collisionHandler;


        [Inject]
        private void Construct(CollisionHandler collisionHandler)
        {
            this.collisionHandler = collisionHandler;
        }

        private void Start()
        {
            currentDisposable = GetComponent<IDisposable>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collidedDisposable = collision.GetComponent<IDisposable>();
            collisionHandler.HandleCollisionBetween(currentDisposable, collidedDisposable);
        }
    }
}