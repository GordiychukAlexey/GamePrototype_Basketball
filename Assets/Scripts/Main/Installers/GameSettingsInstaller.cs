using Entities.Ball;
using GameSettings;
using UnityEngine;
using Zenject;

namespace Main.Installers {
	[CreateAssetMenu(menuName = "Game/Game settings")]
	public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller> {
		public MainSettings MainSettings;
		public BallSettings BallSettings;

		public override void InstallBindings(){
			Container.BindInstance(MainSettings).AsSingle();
			Container.BindInstance(BallSettings).AsSingle();
		}
	}
}