using UnityEngine;
using System.Collections;

/// <summary>
/// Y1 q4mouse drag for the rockets.
/// </summary>
public class Y1Q4mouseDrag : MonoBehaviour {

	private bool displayFlames = false;

	private float flameTimer = 0.0f;
	private const float flameTimerMax = 5.0f;

	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	static bool slot4 = false;

	// X positions 0.13, 0.37, 0.61, 0.87

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
		slot4 = false;
		displayFlames = false;

		currentPosition = transform.position;
		startY = currentPosition.y;
		startZ = currentPosition.z;

		blastOff = (Texture2D)Resources.Load ("Text/blast_off_text");
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
		if (!StarDialog.displayStars && !SettingsDialog.displaySettings) {
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
				if (slot1 == true && slot2 == true && slot3 == true && slot4 == true) {
					StarDialog.displayStars = true;
					AppManager.Instance.addCompletedTask (Y1Q4Scene.MEASUREMENT_Y1Q4, StarDialog.numIncorrect, HintButton.hintUsed);
				} else {
					StarDialog.numIncorrect++;
					IncorrectDialog.displayIncorrectDialog = true;
				}
			}

			drawFlames ();
		}
	}

	void OnMouseUp () {
		if (transform.position.x > 0.03f & transform.position.x < 0.23f) { // slot 1
			transform.position = new Vector3(0.13f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.27f & transform.position.x < 0.47f) { // slot 2
			transform.position = new Vector3(0.37f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.51f & transform.position.x < 0.71f) { // slot 3
			transform.position = new Vector3(0.61f, startY, startZ);
			currentPosition = transform.position;
		} else if (transform.position.x > 0.77f & transform.position.x < 0.97f) { // slot 4
			transform.position = new Vector3(0.87f, startY, startZ);
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
		GameObject fire4 = GameObject.Find("Fire4");

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
			if (slot4) {
				fire4.GetComponent<Renderer> ().enabled = true;
			}
		} else {
			fire1.GetComponent<Renderer> ().enabled = false;
			fire2.GetComponent<Renderer> ().enabled = false;
			fire3.GetComponent<Renderer> ().enabled = false;
			fire4.GetComponent<Renderer> ().enabled = false;
		}
	}
}
