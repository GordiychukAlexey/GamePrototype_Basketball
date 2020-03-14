using System;
using UnityEngine;

namespace InputManager {
	public interface IInputManager {
		event Action<Vector2> UserInput;
	}
}