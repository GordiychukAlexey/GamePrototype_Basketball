using System;
using Entities.Ball.Interfaces;
using Entities.Interfaces;
using UnityEngine;
using Zenject;

namespace Entities.Ball {
	public class BallView : MonoBehaviour, IBallView {
		public event Action<Collision2D> CollisionEnter;

		event Action<object> ICollisionDetector.OnCollisionEnter{
			add => CollisionEnter += value;
			remove => CollisionEnter -= value;
		}

		private Rigidbody2D rigidBody2d;

		[Inject]
		public void Construct(Rigidbody2D rigidBody2d){
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

		private void OnCollisionEnter2D(Collision2D other){
			CollisionEnter?.Invoke(other);
		}
	}
}