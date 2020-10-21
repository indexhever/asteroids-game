using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.Util
{
    // one parameter
    public class RuntimeGameObjectFactory<TParam1, TValue>
    where TValue : Component, IPoolable<TParam1, IMemoryPool>, IDisposable
    {
        private DiContainer container;
        private readonly Dictionary<GameObject, RuntimeGameObjectPool<TParam1, TValue>> pools = new Dictionary<GameObject, RuntimeGameObjectPool<TParam1, TValue>>();

        [Inject]
        public void Construct(DiContainer container)
        {
            this.container = container;
        }

        public TValue Create(GameObject prefab, TParam1 param1)
        {
            //MemoryPool<TValue> objectPool;
            RuntimeGameObjectPool<TParam1, TValue> objectPool;

            if (!pools.TryGetValue(prefab, out objectPool))
            {
                objectPool = CreatePool(prefab);
                pools.Add(prefab, objectPool);
            }

            TValue objectComponent = objectPool.Spawn(param1);
            //objectComponent.OnSpawned(param1, objectPool);

            return objectComponent;
        }

        private RuntimeGameObjectPool<TParam1, TValue> CreatePool(GameObject prefab)
        {
            return container.Instantiate<RuntimeGameObjectPool<TParam1, TValue>>(
                new object[] {
                    new ComponentFromPrefabFactory<TValue>(prefab, container)
                });
        }

        private class RuntimeGameObjectPool<TParam1, TValue> : MonoMemoryPool<TParam1, TValue>
            where TValue : Component, IPoolable<TParam1, IMemoryPool>, IDisposable
        {
            protected override void Reinitialize(TParam1 p1, TValue item)
            {
                base.Reinitialize(p1, item);
                item.OnSpawned(p1, this);
            }

            protected override void OnDespawned(TValue item)
            {
                base.OnDespawned(item);
                item.OnDespawned();
            }
        }
    }

    // two parameters
    public class RuntimeGameObjectFactory<TParam1, TParam2, TValue>
    where TValue : Component, IPoolable<TParam1, TParam2, IMemoryPool>, IDisposable
    {
        private DiContainer container;
        private readonly Dictionary<GameObject, RuntimeGameObjectPool<TParam1, TParam2, TValue>> pools = new Dictionary<GameObject, RuntimeGameObjectPool<TParam1, TParam2, TValue>>();

        [Inject]
        public void Construct(DiContainer container)
        {
            this.container = container;
        }

        public TValue Create(GameObject prefab, TParam1 param1, TParam2 param2)
        {
            //MemoryPool<TValue> objectPool;
            RuntimeGameObjectPool<TParam1, TParam2, TValue> objectPool;

            if (!pools.TryGetValue(prefab, out objectPool))
            {
                objectPool = CreatePool(prefab);
                pools.Add(prefab, objectPool);
            }

            TValue objectComponent = objectPool.Spawn(param1, param2);
            //objectComponent.OnSpawned(param1, objectPool);

            return objectComponent;
        }

        private RuntimeGameObjectPool<TParam1, TParam2, TValue> CreatePool(GameObject prefab)
        {
            return container.Instantiate<RuntimeGameObjectPool<TParam1, TParam2, TValue>>(
                new object[] {
                    new ComponentFromPrefabFactory<TValue>(prefab, container)
                });
        }

        private class RuntimeGameObjectPool<TParam1, TParam2, TValue> : MonoMemoryPool<TParam1, TParam2, TValue>
            where TValue : Component, IPoolable<TParam1, TParam2, IMemoryPool>, IDisposable
        {
            protected override void Reinitialize(TParam1 p1, TParam2 p2, TValue item)
            {
                base.Reinitialize(p1, p2, item);
                item.OnSpawned(p1, p2, this);
            }

            protected override void OnDespawned(TValue item)
            {
                base.OnDespawned(item);
                item.OnDespawned();
            }
        }
    }
}