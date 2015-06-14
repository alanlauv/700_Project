using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	static Vector2 swap;
	static bool doSwap = false;

	static bool slot1 = false;
	static bool slot2 = true;
	static bool slot3 = true;
	static bool slot4 = false;

	float distance = 1.0f;
	Vector3 objPosition;

	Vector3 currentPosition;
	float startY;
	float startZ;

	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		startY = currentPosition.y;
		startZ = currentPosition.z;
	}

	// Update is called once per frame
	void Update () {
		if (currentPosition.x == 0.13f) {
			if (currentPosition.z == 1.0f) {
				slot1 = true;
			} else {
				slot1 = false;
			}
		}

		if (currentPosition.x == 0.37f) {
			if (currentPosition.z == 2.0f) {
				slot2 = true;
			} else {
				slot2 = false;
			}
		}

		if (currentPosition.x == 0.61f) {
			if (currentPosition.z == 3.0f) {
				slot3 = true;
			} else {
				slot3 = false;
			}
		}

		if (currentPosition.x == 0.87f) {
			if (currentPosition.z == 4.0f) {
				slot4 = true;
			} else {
				slot4 = false;
			}
		}

		if (slot1 == true && slot2 == true && slot3 == true && slot4 == true) {
			Debug.Log ("task completed");
		}


		/**
		if (doSwap == true) {
			if (swap.x == 1.0f && currentPosition.x == 0.13f) {
				if (swap.y == 2.0f) {
					transform.position = new Vector3(0.37f, startY, 1.0f);
				} else if (swap.y == 3.0f) {
					transform.position = new Vector3(0.62f, startY, 1.0f);
				} else if (swap.y == 4.0f) {
					transform.position = new Vector3(0.87f, startY, 1.0f);
				}
			}
			doSwap = false;
		}
		*/
	}

	void OnMouseDrag () {
		//Vector3 mousePosition = new Vector3(Input.mousePosition.x + 130.0f, Input.mousePosition.y - 140.0f, distance);

		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		//mousePosition.z = transform.position.z;

		objPosition	= Camera.main.ScreenToViewportPoint(mousePosition);
		objPosition.z = 5.0f;

		transform.position = objPosition;
	}

	void OnMouseUp () {
		if (transform.position.x > 0.03f & transform.position.x < 0.16f) { // slot 1
			transform.position = new Vector3(0.13f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.24f & transform.position.x < 0.40f) { // slot 2
			//swap = new Vector2(1.0f, 2.0f);
			//doSwap = true;
			transform.position = new Vector3(0.37f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.50f & transform.position.x < 0.66f) { // slot 3
			transform.position = new Vector3(0.61f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.75f & transform.position.x < 0.90f) { // slot 4
			transform.position = new Vector3(0.87f, startY, startZ);
			currentPosition = transform.position;
		} else {
			transform.position = currentPosition;
		}
	}
}
