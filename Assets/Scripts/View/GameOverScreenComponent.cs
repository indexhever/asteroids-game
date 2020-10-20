using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace AsteroidsGame.View
{
    public class GameOverScreenComponent : MonoBehaviour, GameOverScreen
    {
        private const int GAME_SCENE_INDEX = 0;
        [SerializeField]
        private CanvasGroup canvasGroup;

        private void Start()
        {
            Hide();
        }

        public void Show()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }

        public void Restart()
        {
            SceneManager.LoadSceneAsync(GAME_SCENE_INDEX);
        }

        private void Hide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }
    }
}