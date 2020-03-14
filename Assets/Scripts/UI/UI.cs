using System.Collections.Generic;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace UI {
	public class UI : MonoBehaviour, IUI {
		public IMainMenu MainMenu{ get; private set; }
		public IInGameUI InGameUi{ get; private set; }

		private List<IUIPanel> panels;

		[Inject]
		public void Construct(IMainMenu mainMenu, IInGameUI inGameUi){
			MainMenu = mainMenu;
			InGameUi = inGameUi;
		}

		private void Awake(){
			panels = new List<IUIPanel>(){MainMenu, InGameUi};
		}

		public void ShowMainMenu() => ShowPanel(MainMenu);
		public void ShowGameUi() => ShowPanel(InGameUi);

		private void ShowPanel(IUIPanel panel){
			foreach (IUIPanel uiPanel in panels){
				if (uiPanel == panel){
					uiPanel.Show();
				} else{
					uiPanel.Hide();
				}
			}
		}
	}
}