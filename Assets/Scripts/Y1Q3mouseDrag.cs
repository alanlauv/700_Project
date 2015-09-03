using UnityEngine;
using System.Collections;

public class Y1Q3mouseDrag : MonoBehaviour {
	
	static Vector2 swap; // don't need
	static bool doSwap = false; // don't need
	static bool isMouseDrag = false; // don't need

	private bool displayFlames = false;

	private float flameTimer = 0.0f;
	private const float flameTimerMax = 5.0f;
	
	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	
	// X positions 0.17, 0.37, 0.61, 0.84
	static float curRedRocketPos;
	static float curBlueRocketPos;
	static float curPurpleRocketPos;
	static float swapPos;
	
	float distance = 1.0f;
	Vector3 objPosition;
	
	Vector3 currentPosition;
	float startY;
	float startZ;

	private Texture2D blastOff;

	// Use this for initialization
	void Start () {
		slot1 = false;
		slot2 = false;
		slot3 = false;

		currentPosition = transform.position;
		startY = currentPosition.y;
		startZ = currentPosition.z;

		if (startZ == 1.0f) {
			curBlueRocketPos = currentPosition.x;
		} else if (startZ == 2.0f) {
			curRedRocketPos = currentPosition.x;
		} else if (startZ == 3.0f) {
			curPurpleRocketPos = currentPosition.x;
		}

		blastOff = (Texture2D)Resources.Load ("Text/blast_off_text");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPosition.x == 0.17f) {
			if (currentPosition.z == 3.0f) { // purple rocket z=1
				slot1 = true;
			} else {
				slot1 = false;
			}
		} else if (currentPosition.x == 0.5f) {
			if (currentPosition.z == 2.0f) { // red rocket z=2
				slot2 = true;
			} else {
				slot2 = false;
			}
		} else if (currentPosition.x == 0.84f) {
			if (currentPosition.z == 1.0f) { // blue rocket z=3
				slot3 = true;
			} else {
				slot3 = false;
			}
		}

		if (displayFlames) {
			flameTimer += Time.deltaTime;
			if (flameTimer >= flameTimerMax) {
				displayFlames = false;
				flameTimer = 0.0f;
			}
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
			if (swap.x == 1.0f && currentPosition.x == 0.17f) {
				if (swap.y == 2.0f) {
					transform.position = new Vector3(0.37f, startY, 1.0f);
				} else if (swap.y == 3.0f) {
					transform.position = new Vector3(0.62f, startY, 1.0f);
				} else if (swap.y == 4.0f) {
					transform.position = new Vector3(0.84f, startY, 1.0f);
				}
			}
			doSwap = false;
		}
		*/
	}
	
	void OnMouseDrag () {
		if (!StarDialog.displayStars  && !SettingsDialog.displaySettings) {
			isMouseDrag = true;
			//Vector3 mousePosition = new Vector3(Input.mousePosition.x + 130.0f, Input.mousePosition.y - 140.0f, distance);
		
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			//mousePosition.z = transform.position.z;
		
			objPosition = Camera.main.ScreenToViewportPoint (mousePosition);
			objPosition.z = 5.0f;
		
			transform.position = objPosition;
		}
	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings && !StarDialog.displayStars) {
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .13f, Screen.width * .2f, Screen.height * .1f), blastOff)) {
				displayFlames = true;
				if (slot1 == true && slot2 == true && slot3 == true) {
					StarDialog.displayStars = true;
					AppManager.Instance.addCompletedTask (Y1Q3Scene.MEASUREMENT_Y1Q3, StarDialog.numIncorrect, HintButton.hintUsed);
				} else {
					StarDialog.numIncorrect++;
					IncorrectDialog.displayIncorrectDialog = true;
				}
			}

			drawFlames ();
		}
	}
	
	void OnMouseUp () {
		isMouseDrag = false;
		
		if (transform.position.x > 0.07f & transform.position.x < 0.27f) { // slot 1
			changePos(0.17f);
			transform.position = new Vector3(0.17f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.35f & transform.position.x < 0.6f) { // slot 2
			//swap = new Vector2(1.0f, 2.0f);
			//doSwap = true;
			changePos(0.5f);
			transform.position = new Vector3(0.5f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.74f & transform.position.x < 0.94f) { // slot 3
			changePos(0.84f);
			transform.position = new Vector3(0.84f, startY, startZ);
			currentPosition = transform.position;
		} else { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}

		/** TODO
		// swap the rocket
		if (startZ == 1.0f) {
			if (curBlueRocketPos != currentPosition.x) {
				transform.position = new Vector3(curBlueRocketPos, startY, startZ);
			}
		} else if (startZ == 2.0f) {
			if (curRedRocketPos != currentPosition.x) {
				transform.position = new Vector3(curRedRocketPos, startY, startZ);
			}
		} else if (startZ == 3.0f) {
			if (curPurpleRocketPos != currentPosition.x) {
				transform.position = new Vector3(curPurpleRocketPos, startY, startZ);
			}
		}
		*/
		
	}
	
	void changePos (float xPos) {
		swapPos = currentPosition.x; // don't need this
		
		// update the xposition of the rocket that is currently in the slot that the rocket
		// was dragged to, update to the xposition to the value of the dragged rocket
		if (curBlueRocketPos == xPos) {
			curBlueRocketPos = currentPosition.x;
		} else if (curRedRocketPos == xPos) {
			curRedRocketPos = currentPosition.x;
		} else if (curPurpleRocketPos == xPos) {
			curPurpleRocketPos = currentPosition.x;
		}
		
		// update cur pos of the rocket that was just dragged
		if (startZ == 1.0f) {
			curBlueRocketPos = xPos;
		} else if (startZ == 2.0f) {
			curRedRocketPos = xPos;
		} else if (startZ == 3.0f) {
			curPurpleRocketPos = xPos;
		}
	}

	private void drawFlames () {
		GameObject fire1 = GameObject.Find("Fire1");
		GameObject fire2 = GameObject.Find("Fire2");
		GameObject fire3 = GameObject.Find("Fire3");

		if (displayFlames) {
			// fire for correct slot
			if (slot1) {
				fire1.GetComponent<Renderer> ().enabled = true;
			}
			if (slot2) {
				fire2.GetComponent<Renderer> ().enabled = true;
			}
			if (slot3) {
				fire3.GetComponent<Renderer> ().enabled = true;
			}
		} else {
			fire1.GetComponent<Renderer> ().enabled = false;
			fire2.GetComponent<Renderer> ().enabled = false;
			fire3.GetComponent<Renderer> ().enabled = false;
		}
	}
}
