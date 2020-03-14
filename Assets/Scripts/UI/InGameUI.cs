using UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI {
	public class InGameUI : MonoBehaviour, IInGameUI {
		[SerializeField] private Button showMainMenuButton;

		private UI ui;

		[Inject]
		public void Construct(UI ui){
			this.ui = ui;
		}

		private void Awake(){
			showMainMenuButton.onClick.AddListener(delegate(){ ui.ShowMainMenu(); });
		}

		public void Show() => gameObject.SetActive(true);
		public void Hide() => gameObject.SetActive(false);
	}
}