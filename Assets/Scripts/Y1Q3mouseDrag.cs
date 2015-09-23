using UnityEngine;
using System.Collections;

/// <summary>
/// Y1 q3mouse drag for the rockets.
/// </summary>
public class Y1Q3mouseDrag : MonoBehaviour {

	private bool displayFlames = false;

	private float flameTimer = 0.0f;
	private const float flameTimerMax = 5.0f;
	
	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	
	// X positions 0.17, 0.37, 0.61, 0.84
	
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

		// instant feedback - flames under rocket for 5 seconds.
		if (displayFlames) {
			flameTimer += Time.deltaTime;
			if (flameTimer >= flameTimerMax) {
				displayFlames = false;
				flameTimer = 0.0f;
			}
		}
	}
	
	void OnMouseDrag () {
		if (!StarDialog.displayStars  && !SettingsDialog.displaySettings) {
			// drag logic
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		
			objPosition = Camera.main.ScreenToViewportPoint (mousePosition);
			objPosition.z = 5.0f;
		
			transform.position = objPosition;
		}
	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings && !StarDialog.displayStars) {
			// blast off button
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .13f, Screen.width * .2f, Screen.height * .1f), blastOff)) {
				displayFlames = true;
				// correct answer
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
		if (transform.position.x > 0.07f & transform.position.x < 0.27f) { // slot 1
			transform.position = new Vector3(0.17f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.35f & transform.position.x < 0.6f) { // slot 2
			transform.position = new Vector3(0.5f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.74f & transform.position.x < 0.94f) { // slot 3
			transform.position = new Vector3(0.84f, startY, startZ);
			currentPosition = transform.position;
		} else { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}
	}

	/// <summary>
	/// Draws the flames for instant feedback under the rockets.
	/// </summary>
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
