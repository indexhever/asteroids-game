using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class FirerComponent : MonoBehaviour
    {
        [SerializeField]
        private BulletComponent.Factory bulletFactory;

        [Inject]
        private void Construct(BulletComponent.Factory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        public void OnFiring()
        {
            bulletFactory.Create(transform.position, transform.up.normalized);
        }
    }
}