using UnityEngine;
using System.Collections;

namespace AsteroidsGame.View
{
    public interface EnemySpawnDefinition
    {
        int AmountWillBeSpawn { get; }
    }
}