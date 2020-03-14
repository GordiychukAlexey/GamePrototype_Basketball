using System;
using System.Collections.Generic;

namespace GameSettings {
	[Serializable]
	public class MainSettings {
		public List<PlanetSettings> PlanetsSettings = new List<PlanetSettings>();

		public PlanetSettings FindPlanetSettings(string planetName) =>
			PlanetsSettings.Find(planetSettings => planetSettings.PlanetName == planetName);
	}
}