using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AsteroidsGame.View
{
    public class TeleporterComponent : MonoBehaviour
    {
        private AsteroidsGame.Controller.Teleporter teleporter;

        [Inject]
        private void Construct(AsteroidsGame.Controller.Teleporter.Factory teleporterFactory)
        {
            if (teleporter == null)
                this.teleporter = teleporterFactory.Create(() => transform.position);
        }

        public void OnLeaveScreen()
        {
            TeleportToOpositeSide();
        }

        private void TeleportToOpositeSide()
        {
            transform.position = teleporter.GetTeleportedPosition();
        }
    }
}