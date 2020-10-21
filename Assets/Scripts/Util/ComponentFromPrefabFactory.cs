using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.Util
{
    public class ComponentFromPrefabFactory<T> : IFactory<T>
        where T : Component
    {
        readonly DiContainer _container;
        readonly GameObject _prefab;

        public ComponentFromPrefabFactory(
            GameObject prefab,
            DiContainer container)
        {
            _container = container;
            _prefab = prefab;
        }

        public T Create()
        {
            return _container.InstantiatePrefabForComponent<T>(_prefab);
        }
    }
}