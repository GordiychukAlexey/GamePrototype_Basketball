using UnityEngine;
using Zenject;

namespace Entities.Ball {
	public class BallView {
		private readonly Rigidbody2D rigidBody2d;

		[Inject]
		public BallView(Rigidbody2D rigidBody2d){
			this.rigidBody2d = rigidBody2d;
		}

		public Vector2 Position{
			get => rigidBody2d.position;
			set => rigidBody2d.position = value;
		}

		public float Rotation{
			get => rigidBody2d.rotation;
			set => rigidBody2d.rotation = value;
		}

		public void AddForce(Vector2 force) => rigidBody2d.AddForce(force);
	}
}