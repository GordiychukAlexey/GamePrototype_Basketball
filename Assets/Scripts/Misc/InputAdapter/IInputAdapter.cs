using UnityEngine;

namespace Misc.BallMovementInputAdapter {
	public interface IInputAdapter<in Source, out Target> {
		Target GetAdaptedInput(Source userInput);
	}
}