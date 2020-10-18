using AsteroidsGame.View;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.Installer
{
    public class PlayerInstaller : MonoInstaller
    {

        [SerializeField]
        private GameObject bulletPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<Vector2, Vector2, BulletComponent, BulletComponent.Factory>().FromMonoPoolableMemoryPool<Vector2, Vector2, BulletComponent>(
                x => x.WithInitialSize(2).FromComponentInNewPrefab(bulletPrefab).UnderTransformGroup("BulletPool"));
        }
    }
}