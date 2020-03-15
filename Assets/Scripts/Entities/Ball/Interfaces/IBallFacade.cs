using Entities.Interfaces;

namespace Entities.Ball.Interfaces {
	public interface IBallFacade : IPhysicBody, ICollisionDetector {
		void Move(float moveInput);
	}
}