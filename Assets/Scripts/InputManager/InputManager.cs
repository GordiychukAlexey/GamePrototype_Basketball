using System;
using Lean.Touch;
using UnityEngine;
using Zenject;

namespace InputManager {
	public class InputManager : IInputManager, IInitializable, IDisposable {
		public event Action<Vector2> UserInput;

		public void Initialize(){
			LeanTouch.OnFingerSet += OnFingerSetHandler;
		}

		public void Dispose(){
			LeanTouch.OnFingerSet -= OnFingerSetHandler;
		}

		private void OnFingerSetHandler(LeanFinger finger){
			if (!finger.IsOverGui){
				UserInput?.Invoke(finger.ScreenPosition);
			}
		}
	}
}