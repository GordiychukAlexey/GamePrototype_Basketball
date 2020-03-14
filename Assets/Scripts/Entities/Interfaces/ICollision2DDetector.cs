using System;
using UnityEngine;

namespace Entities.Interfaces {
	public interface ICollision2DDetector : ICollisionDetector {
		new event Action<Collision2D> CollisionEnter;
	}
}