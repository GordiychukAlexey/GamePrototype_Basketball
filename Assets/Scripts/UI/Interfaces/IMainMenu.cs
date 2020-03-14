using System;

namespace UI.Interfaces {
	public interface IMainMenu : IUIPanel {
		event Action<string> PlanetSelected;

		void SetBallHitsCount(int count);
	}
}