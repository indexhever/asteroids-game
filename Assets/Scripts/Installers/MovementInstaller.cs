using AsteroidsGame.Controller;
using System;
using UnityEngine;
using Zenject;

public class MovementInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindFactory<Action, ForceBasedMovementController, ForceBasedMovementController.Factory>();
    }
}