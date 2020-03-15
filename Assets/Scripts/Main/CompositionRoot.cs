using Entities.Ball.Interfaces;
using GameSettings;
using Main.Interfaces;
using Misc;
using SaveManager;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace Main {
	public class CompositionRoot : MonoBehaviour {
		[Inject] private MainSettings mainSettings;
		[Inject] private IUI ui;
		[Inject] private ISaveManager saveManager;
		[Inject] private IBallFacade ballFacade;
		[Inject] private BallMover.Factory ballMoverFactory;
		[Inject] private IPlanetController planetController;
		[Inject] private IHitsCounter hitsCounter;

		private BallMover ballMover;

		private void OnEnable(){
			ui.MainMenu.OnPlanetSelected        += PlanetSelectedHandler;
			ballFacade.OnCollisionEnter         += hitsCounter.CollisionEnterHandler;
			hitsCounter.OnHitsCountValueChanged += HitsCountValueChangedHandler;
		}

		private void OnDisable(){
			ui.MainMenu.OnPlanetSelected        -= PlanetSelectedHandler;
			ballFacade.OnCollisionEnter         -= hitsCounter.CollisionEnterHandler;
			hitsCounter.OnHitsCountValueChanged -= HitsCountValueChangedHandler;
		}

		private void Start(){
			ballMover = ballMoverFactory.Create(ballFacade);

			LoadGameState();
		}

		private void LoadGameState(){
			int savedHitsCount = saveManager.LoadInt(SavingDataKeys.BallHitsCount, 0);
			hitsCounter.BallHitsCount = savedHitsCount;

			string planetName = saveManager.LoadString(SavingDataKeys.PlanetName, mainSettings.PlanetsSettings[0].PlanetName);
			planetController.SetPlanet(planetName);
		}

		private void PlanetSelectedHandler(string planetName){
			planetController.SetPlanet(planetName);
			saveManager.SaveString(SavingDataKeys.PlanetName, planetName);
		}

		private void HitsCountValueChangedHandler(int value){
			ui.MainMenu.SetBallHitsCount(value);
			saveManager.SaveInt(SavingDataKeys.BallHitsCount, value);
		}
	}
}