using AsteroidsGame.Controller;
using System;
using UnityEngine;
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CollisionHandler>()
                 .AsTransient();
    }
}