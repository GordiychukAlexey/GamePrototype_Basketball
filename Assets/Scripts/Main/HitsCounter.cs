using System;
using Main.Interfaces;

namespace Main {
	public class HitsCounter : IHitsCounter {
		public event Action<int> OnHitsCountValueChanged;

		private int ballHitsCount;

		public int BallHitsCount{
			get => ballHitsCount;
			set{
				ballHitsCount = value;
				OnHitsCountValueChanged?.Invoke(ballHitsCount);
			}
		}

		public void CollisionEnterHandler(object collision) => ++BallHitsCount;
	}
}