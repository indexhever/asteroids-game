using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.View
{
    public abstract class EnemyDeathComponent : MonoBehaviour
    {
        public abstract void OnDie();
    }
}