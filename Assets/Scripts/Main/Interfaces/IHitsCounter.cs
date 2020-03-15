using System;

namespace Main.Interfaces {
	public interface IHitsCounter {
		event Action<int> OnHitsCountValueChanged;
		int BallHitsCount{ get; set; }
		void CollisionEnterHandler(object collision);
	}
}