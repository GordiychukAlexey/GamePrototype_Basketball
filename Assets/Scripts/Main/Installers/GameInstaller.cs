using Entities.Ball;
using Entities.Interfaces;
using Misc.BallMovementInputAdapter;
using SaveManager;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace Main.Installers {
	public class GameInstaller : MonoInstaller {
		public override void InstallBindings(){
			Container.Bind<IUI>().To<UI.UI>().FromResolve().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<PlanetController>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<BallMover>().AsSingle().NonLazy();

			Container.BindFactory<IPhysicBody, ByScreenXShift_InputAdapter, ByScreenXShift_InputAdapter.Factory>().AsSingle().NonLazy();
			Container.Bind<IFactory<IPhysicBody, IInputAdapter<Vector2, float>>>().To<ByScreenXShift_InputAdapter.Factory>().FromResolve();

			Container.BindInterfacesAndSelfTo<HitsCounter>().AsSingle().NonLazy();
			Container.Bind<ICollisionDetector>().FromResolveGetter<BallFacade>(x => x);

			Container.BindInterfacesAndSelfTo<InputManager.InputManager>().AsSingle().NonLazy();

			Container.Bind<ISaveManager>().To<PlayerPrefsSaveManager>().AsSingle().NonLazy();
		}
	}
}