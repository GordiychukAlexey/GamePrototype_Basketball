using Entities.Ball.Interfaces;
using UnityEngine;
using Zenject;

namespace Entities.Ball {
	public class BallInstaller : MonoInstaller {
		public override void InstallBindings(){
			Container.Bind<IBallFacade>().To<BallFacade>().FromComponentOnRoot().AsSingle().NonLazy();
			Container.Bind<IBallView>().To<BallView>().FromComponentOnRoot().AsSingle().NonLazy();
			Container.Bind<IBallMovementController>().To<BallMovementController>().AsSingle().NonLazy();
			Container.Bind<Rigidbody2D>().FromComponentOnRoot().AsSingle().NonLazy();
		}
	}
}