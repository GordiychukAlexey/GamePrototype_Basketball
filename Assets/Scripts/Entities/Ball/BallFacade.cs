using System;
using Entities.Ball.Interfaces;
using UnityEngine;
using Zenject;

namespace Entities.Ball {
	public class BallFacade : MonoBehaviour, IBallFacade {
		[Inject] private IBallView view;
		[Inject] private IBallMovementController ballMovementController;

		public event Action<object> OnCollisionEnter{
			add => view.CollisionEnter += value;
			remove => view.CollisionEnter -= value;
		}

		public Vector2 Position{
			get => view.Position;
			set => view.Position = value;
		}

		public float Rotation{
			get => view.Rotation;
			set => view.Rotation = value;
		}

		public void Move(float moveInput) => ballMovementController.Move(moveInput);
	}
}