using System;
using GameSettings;
using Main.Interfaces;
using UnityEngine;
using Zenject;

namespace Main {
	public class PlanetController : IPlanetController {
		[Inject] private readonly MainSettings mainSettings;
		[Inject(Id = "Main")] private readonly Camera camera;

		public void SetPlanet(string planetName){
			PlanetSettings newPlanetSettings = mainSettings.FindPlanetSettings(planetName);
			if (newPlanetSettings == null){
				throw new ArgumentException($"Unknown planet {planetName}");
			}

			Physics2D.gravity      = Vector2.down * newPlanetSettings.Gravity;
			camera.backgroundColor = newPlanetSettings.SkyColor;
		}
	}
}