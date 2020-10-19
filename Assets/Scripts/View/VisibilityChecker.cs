using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace AsteroidsGame.View
{
    public class VisibilityChecker : MonoBehaviour
    {
        private Camera gameCamera;
        private Plane[] planes;
        private bool isVisible;

        [SerializeField]
        private Collider2D objectCollider;
        [SerializeField]
        private UnityEvent OnEnterScreen, OnLeaveScreen;

        [Inject]
        private void Construct(Camera gameCamera)
        {
            this.gameCamera = gameCamera;
        }

        void Start()
        {
            planes = GeometryUtility.CalculateFrustumPlanes(gameCamera);
        }

        void Update()
        {
            if (HasObjectEnteredScreen())
            {
                isVisible = true;
                OnEnterScreen?.Invoke();
            }
            else if (HasObjectLeftScreen())
            {
                isVisible = false;
                OnLeaveScreen?.Invoke();
            }
        }

        private bool HasObjectEnteredScreen()
        {
            return IsObjectInsideScreenBounds() && !isVisible;
        }

        private bool HasObjectLeftScreen()
        {
            return !IsObjectInsideScreenBounds() && isVisible;
        }

        private bool IsObjectInsideScreenBounds()
        {
            return GeometryUtility.TestPlanesAABB(planes, objectCollider.bounds);
        }
    }
}