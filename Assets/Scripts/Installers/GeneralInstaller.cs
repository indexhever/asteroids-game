using AsteroidsGame.Controller;
using AsteroidsGame.Controller;
using AsteroidsGame.View;
using System;
using UnityEngine;
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private ScoreComponent scoreComponent;

    public override void InstallBindings()
    {
        Container.Bind<CollisionHandler>()
                 .AsTransient();

        Container.Bind<InitialPositionSpawner>()
                 .AsSingle()
                 .WithArguments<Func<float, float, float>>(UnityEngine.Random.Range);

        Container.Bind<CameraStatsRetriever>()
                 .To<DefaultCameraStatsRetriever>()
                 .AsSingle();

        Container.BindFactory<Func<Vector2>, Teleporter, Teleporter.Factory>();

        Container.Bind<Camera>()
                 .FromInstance(gameCamera)
                 .AsSingle();

        Container.Bind<ScoreVisual>()
                 .FromInstance(scoreComponent)
                 .AsSingle();

        Container.Bind<ScoreSystem>()
                 .AsSingle();

        Container.Bind<EnemyDeathController>()
                 .AsSingle();
    }
}