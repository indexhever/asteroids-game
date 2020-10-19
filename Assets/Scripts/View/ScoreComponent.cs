using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsGame.View
{
    public class ScoreComponent : MonoBehaviour, ScoreVisual
    {
        [SerializeField]
        private Text textComponent;

        //TODO: control concurrent update?
        public void UpdateWithNewScore(int newScore)
        {
            textComponent.text = newScore.ToString();
        }
    }
}