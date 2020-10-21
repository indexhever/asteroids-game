using AsteroidsGame.Controller;
using AsteroidsGame.View;
using UnityEngine;
using Zenject;

public class AsteroidsInstaller : MonoInstaller
{
    [SerializeField]
    private AsteroidSpawner asteroidSpawner;

    public override void InstallBindings()
    {
        Container.Bind<AsteroidComponent.Factory>()
                .AsSingle()
                .NonLazy();

        Container.Bind<AsteroidSpawner>()
                 .FromInstance(asteroidSpawner)
                 .AsSingle();
    }
}