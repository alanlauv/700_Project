using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	float distance = 1.0f;

	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDrag () {
		//Vector3 mousePosition = new Vector3(Input.mousePosition.x + 130.0f, Input.mousePosition.y - 140.0f, distance);

		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		//mousePosition.z = transform.position.z;

		Vector3 objPosition	= Camera.main.ScreenToViewportPoint(mousePosition);
		objPosition.z = 1.0f;

		transform.position = objPosition;
	}

	void OnMouseUp () {
		if (transform.position.x > 0.03f & transform.position.x < 0.16f) { // slot 1

		} else if (transform.position.x > 0.24f & transform.position.x < 0.40f) { // slot 2

		} else if (transform.position.x > 0.50f & transform.position.x < 0.66f) { // slot 3

		} else if (transform.position.x > 0.75f & transform.position.x < 0.90f) { // slot 4

		} else {
			transform.position = startPosition;
		}
	}
}
