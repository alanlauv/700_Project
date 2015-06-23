﻿using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	static Vector2 swap; // don't need
	static bool doSwap = false; // don't need
	static bool isMouseDrag = false; // don't need

	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	static bool slot4 = false;

	// X positions 0.13, 0.37, 0.61, 0.87
	static float curGreenRocketPos;
	static float curRedRocketPos;
	static float curBlueRocketPos;
	static float curPurpleRocketPos;
	static float swapPos;

	float distance = 1.0f;
	Vector3 objPosition;

	Vector3 currentPosition;
	float startY;
	float startZ;

	static Texture2D fire;

	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		startY = currentPosition.y;
		startZ = currentPosition.z;

		if (startZ == 1.0f) {
			curGreenRocketPos = currentPosition.x;
		} else if (startZ == 2.0f) {
			curRedRocketPos = currentPosition.x;
		} else if (startZ == 3.0f) {
			curBlueRocketPos = currentPosition.x;
		} else if (startZ == 4.0f) {
			curPurpleRocketPos = currentPosition.x;
		}

		fire = (Texture2D)Resources.Load("pics/Fire sprites/Fire");
	}

	// Update is called once per frame
	void Update () {
		if (currentPosition.x == 0.13f) {
			if (currentPosition.z == 1.0f) { // green rocket z=1
				slot1 = true;
			} else {
				slot1 = false;
			}
		} else if (currentPosition.x == 0.37f) {
			if (currentPosition.z == 2.0f) { // red rocket z=2
				slot2 = true;
			} else {
				slot2 = false;
			}
		} else if (currentPosition.x == 0.61f) {
			if (currentPosition.z == 3.0f) { // blue rocket z=3
				slot3 = true;
			} else {
				slot3 = false;
			}
		} else if (currentPosition.x == 0.87f) {
			if (currentPosition.z == 4.0f) { // purple rocket z=4
				slot4 = true;
			} else {
				slot4 = false;
			}
		}

		if (slot1 == true && slot2 == true && slot3 == true && slot4 == true) {
			Debug.Log ("task completed");
		}

		/**
		if (!isMouseDrag) {
			if (startZ == 1.0f) {
				if (curGreenRocketPos != currentPosition.x) {
					transform.position = new Vector3(curGreenRocketPos, startY, startZ);
				}
			} else if (startZ == 2.0f) {
				if (curRedRocketPos != currentPosition.x) {
					transform.position = new Vector3(curRedRocketPos, startY, startZ);
				}
			} else if (startZ == 3.0f) {
				if (curBlueRocketPos != currentPosition.x) {
					transform.position = new Vector3(curBlueRocketPos, startY, startZ);
				}
			} else if (startZ == 4.0f) {
				if (curPurpleRocketPos != currentPosition.x) {
					transform.position = new Vector3(curPurpleRocketPos, startY, startZ);
				}
			}
		}*/

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
		isMouseDrag = true;
		//Vector3 mousePosition = new Vector3(Input.mousePosition.x + 130.0f, Input.mousePosition.y - 140.0f, distance);

		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		//mousePosition.z = transform.position.z;

		objPosition	= Camera.main.ScreenToViewportPoint(mousePosition);
		objPosition.z = 5.0f;

		transform.position = objPosition;
	}

	void OnGUI () {
		if (slot1) {
			GUI.DrawTexture(new Rect(Screen.width * .08f, Screen.height * .93f, Screen.width * .08f, Screen.height * .07f), fire);
		}
		if (slot2) {
			GUI.DrawTexture(new Rect(Screen.width * .33f, Screen.height * .94f, Screen.width * .08f, Screen.height * .06f), fire);
		}
		if (slot3) {
			GUI.DrawTexture(new Rect(Screen.width * .575f, Screen.height * .95f, Screen.width * .08f, Screen.height * .05f), fire);
		}
		if (slot4) {
			GUI.DrawTexture(new Rect(Screen.width * .832f, Screen.height * .955f, Screen.width * .08f, Screen.height * .045f), fire);
		}
	}

	void OnMouseUp () {
		isMouseDrag = false;

		if (transform.position.x > 0.03f & transform.position.x < 0.16f) { // slot 1
			changePos(0.13f);
			transform.position = new Vector3(0.13f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.24f & transform.position.x < 0.40f) { // slot 2
			//swap = new Vector2(1.0f, 2.0f);
			//doSwap = true;
			changePos(0.37f);
			transform.position = new Vector3(0.37f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.50f & transform.position.x < 0.66f) { // slot 3
			changePos(0.61f);
			transform.position = new Vector3(0.61f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.75f & transform.position.x < 0.90f) { // slot 4
			changePos(0.87f);
			transform.position = new Vector3(0.87f, startY, startZ);
			currentPosition = transform.position;
		} else { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}

		// swap the rocket
		if (startZ == 1.0f) {
			if (curGreenRocketPos != currentPosition.x) {
				transform.position = new Vector3(curGreenRocketPos, startY, startZ);
			}
		} else if (startZ == 2.0f) {
			if (curRedRocketPos != currentPosition.x) {
				transform.position = new Vector3(curRedRocketPos, startY, startZ);
			}
		} else if (startZ == 3.0f) {
			if (curBlueRocketPos != currentPosition.x) {
				transform.position = new Vector3(curBlueRocketPos, startY, startZ);
			}
		} else if (startZ == 4.0f) {
			if (curPurpleRocketPos != currentPosition.x) {
				transform.position = new Vector3(curPurpleRocketPos, startY, startZ);
			}
		}

	}

	void changePos (float xPos) {
		swapPos = currentPosition.x; // don't need this

		// update the xposition of the rocket that is currently in the slot that the rocket
		// was dragged to, update to the xposition to the value of the dragged rocket
		if (curGreenRocketPos == xPos) {
			curGreenRocketPos = currentPosition.x;
		} else if (curBlueRocketPos == xPos) {
			curBlueRocketPos = currentPosition.x;
		} else if (curRedRocketPos == xPos) {
			curRedRocketPos = currentPosition.x;
		} else if (curPurpleRocketPos == xPos) {
			curPurpleRocketPos = currentPosition.x;
		}

		// update cur pos of the rocket that was just dragged
		if (startZ == 1.0f) {
			curGreenRocketPos = xPos;
		} else if (startZ == 2.0f) {
			curRedRocketPos = xPos;
		} else if (startZ == 3.0f) {
			curBlueRocketPos = xPos;
		} else if (startZ == 4.0f) {
			curPurpleRocketPos = xPos;
		}
	}
}