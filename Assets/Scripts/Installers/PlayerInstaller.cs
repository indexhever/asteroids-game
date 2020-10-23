using AsteroidsGame.View;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.Installer
{
    public class PlayerInstaller : MonoInstaller
    {
        private const int BULLETS_INITIAL_AMOUNT = 15;
        [SerializeField]
        private GameObject bulletPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<Vector2, Vector2, BulletComponent, BulletComponent.Factory>().FromMonoPoolableMemoryPool<Vector2, Vector2, BulletComponent>(
                x => x.WithInitialSize(BULLETS_INITIAL_AMOUNT).FromComponentInNewPrefab(bulletPrefab).UnderTransformGroup("BulletPool"));
        }
    }
}