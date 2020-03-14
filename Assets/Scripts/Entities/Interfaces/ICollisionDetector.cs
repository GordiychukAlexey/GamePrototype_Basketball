using System;

namespace Entities.Interfaces {
	public interface ICollisionDetector {
		event Action<object> CollisionEnter;
	}
}