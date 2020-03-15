using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities.Platform {
	[RequireComponent(typeof(SpriteRenderer))]
	public class Platform : MonoBehaviour {
		private SpriteRenderer spriteRenderer;

		private void Awake(){
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void OnCollisionEnter2D(Collision2D other){
			spriteRenderer.color = Random.ColorHSV(0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f);
		}
	}
}