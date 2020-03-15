using Entities.Ball.Interfaces;
using Entities.Interfaces;
using Main.Interfaces;
using Misc.InputAdapter;
using SaveManager;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace Main.Installers {
	public class GameInstaller : MonoInstaller {
		[SerializeField] private GameObjectContext _ballFacade;

		public override void InstallBindings(){
			Container.Bind<IUI>().To<UI.UI>().FromResolve().AsSingle().NonLazy();

			Container.Bind<IBallFacade>().FromSubContainerResolve().ByInstanceGetter(ctx => {
					Container.LazyInject(_ballFacade);
					return _ballFacade.Container;
				}
			).AsSingle().NonLazy();

			Container.Bind<IPlanetController>().To<PlanetController>().AsSingle().NonLazy();
			Container.Bind<IHitsCounter>().To<HitsCounter>().AsSingle().NonLazy();

			Container.BindFactory<IBallFacade, BallMover, BallMover.Factory>().AsSingle().NonLazy();

			Container.BindFactory<IPhysicBody, ByScreenXShift_InputAdapter, ByScreenXShift_InputAdapter.Factory>().AsSingle().NonLazy();
			Container.Bind<IFactory<IPhysicBody, IInputAdapter<Vector2, float>>>().To<ByScreenXShift_InputAdapter.Factory>().FromResolve();

			Container.BindInterfacesAndSelfTo<InputManager.InputManager>().AsSingle().NonLazy();

			Container.Bind<ISaveManager>().To<PlayerPrefsSaveManager>().AsSingle().NonLazy();
		}
	}
}