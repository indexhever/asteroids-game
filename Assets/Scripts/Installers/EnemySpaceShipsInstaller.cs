using AsteroidsGame.View;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.Installer
{
    public class EnemySpaceShipsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemySpaceShipComponent.Factory>()
                    .AsSingle()
                    .NonLazy();
        }
    }
}