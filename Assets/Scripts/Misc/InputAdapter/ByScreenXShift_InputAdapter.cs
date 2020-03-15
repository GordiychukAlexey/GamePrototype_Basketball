using Entities.Interfaces;
using UnityEngine;
using Zenject;

namespace Misc.InputAdapter {
	/// <summary>
	/// Преобразует экранную позицию курсора в смещение позиции курсора от позиции IPhysicBody в проекции на экранную ось X, нормализованное по ширине экрана.
	/// </summary>
	public class ByScreenXShift_InputAdapter : IInputAdapter<Vector2, float> {
		private readonly IPhysicBody physicBody;
		private readonly Camera camera;

		[Inject]
		public ByScreenXShift_InputAdapter(
			[Inject(Id = "Main")] Camera camera,
			IPhysicBody physicBody
		){
			this.camera     = camera;
			this.physicBody = physicBody;
		}

		public float GetAdaptedInput(Vector2 userInput){
			Vector2 ballInScreenPos  = camera.WorldToScreenPoint(physicBody.Position);
			float   deltaX           = userInput.x - ballInScreenPos.x;
			float   normalizedDeltaX = deltaX / Screen.width;
			return normalizedDeltaX;
		}

		public class Factory : PlaceholderFactory<IPhysicBody, ByScreenXShift_InputAdapter> { }
	}
}