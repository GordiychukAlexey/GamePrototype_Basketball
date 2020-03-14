using System;
using Entities.Ball.Interfaces;
using Entities.Interfaces;
using UnityEngine;
using Zenject;

namespace Entities.Ball {
	public class BallFacade : MonoBehaviour, IPhysicBody, ICollision2DDetector {
		public event Action<Collision2D> CollisionEnter;

		event Action<object> ICollisionDetector.CollisionEnter{
			add => CollisionEnter += value;
			remove => CollisionEnter -= value;
		}

		private BallView view;
		private IBallMovementController ballMovementController;

		[Inject]
		public void Construct(
			BallView view,
			IBallMovementController ballMovementController){
			this.view                   = view;
			this.ballMovementController = ballMovementController;
		}

		public Vector2 Position{
			get => view.Position;
			set => view.Position = value;
		}

		public float Rotation{
			get => view.Rotation;
			set => view.Rotation = value;
		}

		private void OnCollisionEnter2D(Collision2D other){
			CollisionEnter?.Invoke(other);
		}

		public void Move(float moveInput) => ballMovementController.Move(moveInput);
	}
}