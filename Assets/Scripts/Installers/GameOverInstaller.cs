using AsteroidsGame.Controller;
using AsteroidsGame.Controllers;
using AsteroidsGame.View;
using System;
using UnityEngine;
using Zenject;

public class GameOverInstaller : MonoInstaller
{
    [SerializeField]
    private int initialLifeAmount;
    [SerializeField]
    private LifeVisualComponent lifeVisualComponent;
    [SerializeField]
    private GameOverScreenComponent gameOverScreenComponent;

    public override void InstallBindings()
    {
        Container.Bind<LifeController>()
                 .AsSingle()
                 .WithArguments<int>(initialLifeAmount);

        Container.Bind<LifeVisual>()
                 .FromInstance(lifeVisualComponent)
                 .AsSingle();

        Container.Bind<GameOverController>()
                 .To<DefaultGameOverController>()
                 .AsSingle();

        Container.Bind<GameOverScreen>()
                 .FromInstance(gameOverScreenComponent)
                 .AsSingle();

        Container.Bind<GamePauseController>()
                 .To<TimeBasedGamePauseController>()
                 .AsSingle()
                 .WithArguments<Action<float>>((newTimeScale) => Time.timeScale = newTimeScale);
    }
}