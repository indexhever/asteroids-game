using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsGame.Animation
{
    public abstract class AnimationController : MonoBehaviour
    {
        [SerializeField]
        protected Animator animator;

        public abstract void Play();
    }
}