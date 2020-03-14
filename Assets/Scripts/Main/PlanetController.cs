using System;
using GameSettings;
using Misc;
using SaveManager;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace Main {
	public class PlanetController : IInitializable, IDisposable {
		private readonly MainSettings mainSettings;
		private readonly IUI ui;
		private readonly Camera camera;
		private readonly ISaveManager saveManager;

		private int ballHitsCount;

		[Inject]
		public PlanetController(
			MainSettings mainSettings,
			IUI ui,
			[Inject(Id = "Main")] Camera camera,
			ISaveManager saveManager
		){
			this.mainSettings = mainSettings;
			this.ui           = ui;
			this.camera       = camera;
			this.saveManager  = saveManager;
		}

		public void Initialize(){
			ui.MainMenu.PlanetSelected += PlanetSelectedHandler;

			LoadGameState();
		}

		public void Dispose(){
			ui.MainMenu.PlanetSelected -= PlanetSelectedHandler;
		}

		private void LoadGameState(){
			string planetName = saveManager.LoadString(SavingDataKeys.PlanetName, mainSettings.PlanetsSettings[0].PlanetName);
			SetPlanet(planetName);
		}

		private void PlanetSelectedHandler(string planetName) => SetPlanet(planetName);

		private void SetPlanet(string planetName){
			PlanetSettings newPlanetSettings = mainSettings.FindPlanetSettings(planetName);
			if (newPlanetSettings == null){
				throw new ArgumentException($"Unknown planet {planetName}");
			}

			Physics2D.gravity      = Vector2.down * newPlanetSettings.Gravity;
			camera.backgroundColor = newPlanetSettings.SkyColor;

			saveManager.SaveString(SavingDataKeys.PlanetName, newPlanetSettings.PlanetName);
		}
	}
}