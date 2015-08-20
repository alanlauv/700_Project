using UnityEngine;
using System.Collections;

public class testAnimation : MonoBehaviour {

	// update data timer
	private float timer = 0.0f;
	private float timerMax = 1.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timerMax) {
			if (gameObject.GetComponent<Renderer> ().enabled) {
				gameObject.GetComponent<Renderer> ().enabled = false;
			} else {
				gameObject.GetComponent<Renderer> ().enabled = true;
			}
			timer = 0.0f;
		}
	}
}
