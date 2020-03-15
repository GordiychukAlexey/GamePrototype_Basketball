using Entities.Ball.Interfaces;
using UnityEngine;

namespace Entities.Ball {
	public class BallMovementController : IBallMovementController {
		private readonly IBallView ballView;
		private readonly BallSettings ballSettings;

		public BallMovementController(IBallView ballView, BallSettings ballSettings){
			this.ballView     = ballView;
			this.ballSettings = ballSettings;
		}

		public void Move(float moveInput){
			ballView.AddForce(new Vector2(moveInput * ballSettings.BallMovingForceMultiplier, 0.0f));
		}
	}
}