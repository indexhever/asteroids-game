using UnityEngine;
using System.Collections;
using AsteroidsGame.Animation;

namespace AsteroidsGame.Animations
{
    public class PlayerReborn : AnimationController
    {
        private readonly int REBORN_TRIGGER_HASH = Animator.StringToHash("Reborn");

        public override void Play()
        {
            animator.SetTrigger(REBORN_TRIGGER_HASH);
        }
    }
}