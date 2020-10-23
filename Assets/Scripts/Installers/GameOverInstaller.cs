using AsteroidsGame.Controller;
using AsteroidsGame.Controller;
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
    [SerializeField]
    private WinGameScreenComponent winGameScreenComponent;

    public override void InstallBindings()
    {
        Container.Bind<LifeController>()
                 .AsSingle()
                 .WithArguments<int>(initialLifeAmount);

        Container.Bind<LifeVisual>()
                 .FromInstance(lifeVisualComponent)
                 .AsSingle();
        
        // Game Over
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

        // Win Game
        Container.Bind<WinGameController>()
                 .To<DefaultWinGameController>()
                 .AsSingle();

        Container.Bind<WinGameScreen>()
                 .FromInstance(winGameScreenComponent)
                 .AsSingle();
    }
}