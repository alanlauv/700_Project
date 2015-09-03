using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]

public class AutoStretchSprite : MonoBehaviour {

	void Start () {
		Resize();
	}
	
	void FixedUpdate () {
		Resize();
	}
	
	void Resize() {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		transform.localScale = new Vector3(1, 1, 1);
		
		// example of a 640x480 sprite
		float width = sr.sprite.bounds.size.x; // 4.80f
		float height = sr.sprite.bounds.size.y; // 6.40f
		
		// and a 2D camera at 0,0,-10
		float worldScreenHeight = Camera.main.orthographicSize * 2f; // 10f
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width; // 10f
		
		Vector3 imgScale = new Vector3(1f, 1f, 1f);
		
		imgScale.x = worldScreenWidth / width;
		imgScale.y = worldScreenHeight / height;
				
		// apply change
		transform.localScale = imgScale;
	}
}
