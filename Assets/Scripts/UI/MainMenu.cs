using System;
using System.Collections.Generic;
using GameSettings;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI {
	public class MainMenu : MonoBehaviour, IMainMenu {
		public event Action<string> OnPlanetSelected;

		[SerializeField] private Button backToGameButton;
		[SerializeField] private Text ballHitsCountText;
		[SerializeField] private RectTransform planetsButtonsParent;
		[SerializeField] private Button planetsButtonsPrefab;

		private UI ui;
		private MainSettings mainSettings;

		private List<Button> planetsButtons = new List<Button>();

		[Inject]
		public void Construct(
			UI ui,
			MainSettings mainSettings){
			this.ui           = ui;
			this.mainSettings = mainSettings;
		}

		private void Awake(){
			backToGameButton.onClick.AddListener(ui.ShowGameUi);

			foreach (PlanetSettings planetSettings in mainSettings.PlanetsSettings){
				Button newPlanetButton = InitNewPlanetButton(planetSettings);
				newPlanetButton.onClick.AddListener(delegate(){ OnPlanetSelected?.Invoke(planetSettings.PlanetName); });
				planetsButtons.Add(newPlanetButton);
			}
		}

		public void Show() => gameObject.SetActive(true);
		public void Hide() => gameObject.SetActive(false);

		public void SetBallHitsCount(int count){
			Debug.Log($"Show ball hits count {count}");
			ballHitsCountText.text = count.ToString();
		}

		private Button InitNewPlanetButton(PlanetSettings planetSettings){
			Button newPlanetButton = Instantiate(planetsButtonsPrefab, planetsButtonsParent);
			newPlanetButton.gameObject.name                                = planetSettings.PlanetName;
			newPlanetButton.image.color                                    = planetSettings.SkyColor;
			newPlanetButton.gameObject.GetComponentInChildren<Text>().text = planetSettings.PlanetName;

			return newPlanetButton;
		}
	}
}