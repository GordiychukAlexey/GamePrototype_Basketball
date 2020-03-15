using Entities.Ball.Interfaces;
using Entities.Interfaces;
using InputManager;
using Misc.InputAdapter;
using UnityEngine;
using Zenject;

namespace Main {
	public class BallMover {
		private readonly IBallFacade ballFacade;
		private readonly IInputAdapter<Vector2, float> ballMovementInputAdapter;

		[Inject]
		public BallMover(
			IBallFacade ballFacade,
			IInputManager inputManager,
			IFactory<IPhysicBody, IInputAdapter<Vector2, float>> ballMovementInputAdapterFactory
		){
			this.ballFacade          = ballFacade;
			ballMovementInputAdapter = ballMovementInputAdapterFactory.Create(ballFacade);

			inputManager.UserInput += UserInputHandler; //todo отписка
		}

		private void UserInputHandler(Vector2 screenPos){
			float adapted = ballMovementInputAdapter.GetAdaptedInput(screenPos);
			ballFacade.Move(adapted);
		}

		public class Factory : PlaceholderFactory<IBallFacade, BallMover> { }
	}
}