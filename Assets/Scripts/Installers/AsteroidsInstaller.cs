using AsteroidsGame.Controller;
using AsteroidsGame.View;
using UnityEngine;
using Zenject;

public class AsteroidsInstaller : MonoInstaller
{
    private const int ASTEROIDS_INITIAL_AMOUNT = 10;

    [SerializeField]
    private GameObject asteroidPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<Vector2, Vector3, AsteroidComponent, AsteroidComponent.Factory>().FromMonoPoolableMemoryPool<Vector2, Vector3, AsteroidComponent>(
                x => x.WithInitialSize(ASTEROIDS_INITIAL_AMOUNT).FromComponentInNewPrefab(asteroidPrefab).UnderTransformGroup("AsteroidsPool"));
    }
}