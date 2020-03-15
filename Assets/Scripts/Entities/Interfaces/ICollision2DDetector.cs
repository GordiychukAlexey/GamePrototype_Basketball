using System;
using UnityEngine;

namespace Entities.Interfaces {
	public interface ICollision2DDetector : ICollisionDetector {
		event Action<Collision2D> CollisionEnter;
	}
}