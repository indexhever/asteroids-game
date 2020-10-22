using AsteroidsGame.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.Controller
{
    public class DeathWithoutDecreasingEnemyAmount : EnemyDeathComponent
    {
        public override void OnDie()
        {
            GivePoints();
        }
    }
}