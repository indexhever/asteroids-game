using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AsteroidsGame.Controller;
using Zenject;

namespace AsteroidsGame.View
{
    public class LifeVisualComponent : MonoBehaviour, LifeVisual
    {
        [SerializeField]
        private Text lifeTextComponent;

        [Inject]
        public void Construct(LifeController lifeController)
        {
            UpdatWithNewRemainingLife(lifeController.RemainingLife);
        }

        public void UpdatWithNewRemainingLife(int remainingLife)
        {
            lifeTextComponent.text = remainingLife.ToString();
        }
    }
}