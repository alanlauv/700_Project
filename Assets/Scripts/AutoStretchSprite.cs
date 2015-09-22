using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]

/// <summary>
/// Auto stretch sprite.
/// Used for background sprite to stretch and fill the whole screen.
/// </summary>
public class AutoStretchSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		stretch();
	}

	// Update is called once per frame
	void Update () {
		//stretch();
	}

	/// <summary>
	/// Stretch this sprite to fill the whole screen.
	/// </summary>
	void stretch() {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		transform.localScale = new Vector3(1, 1, 1);
		
		// size of sprite curently
		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;
		
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
