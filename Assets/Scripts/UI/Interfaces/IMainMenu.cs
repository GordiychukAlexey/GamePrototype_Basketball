using System;

namespace UI.Interfaces {
	public interface IMainMenu : IUIPanel {
		event Action<string> OnPlanetSelected;

		void SetBallHitsCount(int count);
	}
}