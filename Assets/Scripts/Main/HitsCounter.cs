using System;
using System.Collections.Generic;
using Entities.Ball;
using Entities.Interfaces;
using Misc;
using SaveManager;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace Main {
	public class HitsCounter : IInitializable, IDisposable {
		private readonly ICollisionDetector collisionDetector;
		private readonly IUI ui;
		private readonly ISaveManager saveManager;

		private int ballHitsCount;

		[Inject]
		public HitsCounter(
			ICollisionDetector collisionDetector,
			IUI ui,
			ISaveManager saveManager
		){
			this.collisionDetector = collisionDetector;
			this.ui                = ui;
			this.saveManager       = saveManager;
		}

		public void Initialize(){
			collisionDetector.CollisionEnter += CollisionEnterHandler;

			LoadGameState();
		}

		public void Dispose(){
			collisionDetector.CollisionEnter -= CollisionEnterHandler;
		}

		private void LoadGameState(){
			ballHitsCount = saveManager.LoadInt(SavingDataKeys.BallHitsCount, 0);
			ui.MainMenu.SetBallHitsCount(ballHitsCount);
		}

		public void CollisionEnterHandler(object collision){
			++ballHitsCount;
			saveManager.SaveInt(SavingDataKeys.BallHitsCount, ballHitsCount);
			ui.MainMenu.SetBallHitsCount(ballHitsCount);
		}
	}
}