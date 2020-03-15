using Entities.Interfaces;
using UnityEngine;

namespace Entities.Ball.Interfaces {
	public interface IBallView : IPhysicBody, ICollision2DDetector {
		void AddForce(Vector2 force);
	}
}