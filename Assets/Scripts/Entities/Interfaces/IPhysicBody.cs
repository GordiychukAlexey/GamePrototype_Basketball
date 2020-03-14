using UnityEngine;

namespace Entities.Interfaces {
	public interface IPhysicBody {
		Vector2 Position{ get; set; }

		float Rotation{ get; set; }
//		Vector2 Scale{ get; set; }
	}
}