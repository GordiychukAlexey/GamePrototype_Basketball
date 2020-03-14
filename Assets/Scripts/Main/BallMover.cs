using System;
using Entities.Ball;
using Entities.Interfaces;
using GameSettings;
using InputManager;
using Misc.BallMovementInputAdapter;
using UnityEngine;
using Zenject;

namespace Main {
	public class BallMover : IInitializable, IDisposable {
		private readonly IInputManager inputManager;
		private readonly BallFacade ballFacade;
		private readonly IInputAdapter<Vector2, float> ballMovementInputAdapter;

		[Inject]
		public BallMover(
			IInputManager inputManager,
			BallFacade ballFacade,
			IFactory<IPhysicBody, IInputAdapter<Vector2, float>> ballMovementInputAdapterFactory
		){
			this.inputManager        = inputManager;
			this.ballFacade          = ballFacade;
			ballMovementInputAdapter = ballMovementInputAdapterFactory.Create(ballFacade);
		}

		public void Initialize(){
			inputManager.UserInput += UserInputHandler;
		}

		public void Dispose(){
			inputManager.UserInput -= UserInputHandler;
		}

		private void UserInputHandler(Vector2 screenPos){
			float adapted = ballMovementInputAdapter.GetAdaptedInput(screenPos);
			ballFacade.Move(adapted);
		}
	}
}