using UI.Interfaces;
using Zenject;

namespace UI.Installers {
	public class UIInstaller : MonoInstaller {
		public override void InstallBindings(){
			Container.Bind<IUI>().To<UI>().FromComponentOnRoot().AsSingle().NonLazy();
			Container.Bind<IMainMenu>().To<MainMenu>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<IInGameUI>().To<InGameUI>().FromComponentInHierarchy().AsSingle().NonLazy();
		}
	}
}