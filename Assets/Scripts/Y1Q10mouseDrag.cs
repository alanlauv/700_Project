using UnityEngine;
using System.Collections;

/// <summary>
/// Y1 q10mouse drag for the astronauts.
/// </summary>
public class Y1Q10mouseDrag : MonoBehaviour {

	// slots next to the rocket
	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	static bool slot4 = false;
	static bool slot5 = false;
	
	float distance = 1.0f;
	Vector3 objPosition;
	
	Vector3 currentPosition;
	float startX;
	float startY;
	float startZ;
	
	private bool isSlotted = false;
	private bool canRemove = false;

	private Texture2D astronautOutline;
	
	// Use this for initialization
	void Start () {
		slot1 = false;
		slot2 = false;
		slot3 = false;
		slot4 = false;
		slot5 = false;

		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;

		astronautOutline = (Texture2D)Resources.Load ("Sprites/astronaut_outline");
	}
	
	// Update is called once per frame
	void Update () {		

	}

	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			// draw first green outline
			if (slot1 == false)
				GUI.DrawTexture (new Rect (Screen.width * .507f, Screen.height * .67f, Screen.width * .086f, Screen.height * .14f), astronautOutline);
		}
	}
	
	void OnMouseDrag () {
		if (!isSlotted && !StarDialog.displayStars && !SettingsDialog.displaySettings) {
			// drag logic
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			
			objPosition = Camera.main.ScreenToViewportPoint (mousePosition);
			objPosition.z = 5.0f;
			
			transform.position = objPosition;
		}
	}
	
	void OnMouseUp () {	
		if (transform.position.x > 0.5f && transform.position.x < 0.6f) {
			if (slot1 == false &&
			    transform.position.y > 0.2f && transform.position.y < 0.32f) { // slot1, +-6 from 0.26f

				transform.position = new Vector3 (0.55f, 0.26f, startZ);
				slot1 = true;
				isSlotted = true;
				Counter.counter++;
			
			} else if (slot2 == false && slot1 == true &&
			           transform.position.y > 0.33f && transform.position.y < 0.45f) { // slot 2, height of astro is 0.13f

				transform.position = new Vector3 (0.55f, 0.39f, startZ);
				slot2 = true;
				isSlotted = true;
				Counter.counter++;

			} else if (slot3 == false && slot2 == true &&
			           transform.position.y > 0.46f && transform.position.y < 0.58f) {

				transform.position = new Vector3 (0.55f, 0.52f, startZ);
				slot3 = true;
				isSlotted = true;
				Counter.counter++;
			
			} else if (slot4 == false && slot3 == true &&
			           transform.position.y > 0.59f && transform.position.y < 0.71f) {
				
				transform.position = new Vector3 (0.55f, 0.65f, startZ);
				slot4 = true;
				isSlotted = true;
				Counter.counter++;

			} else if (slot5 == false && slot4 == true &&
			           transform.position.y > 0.72f && transform.position.y < 0.84f) {

				transform.position = new Vector3 (0.55f, 0.78f, startZ);
				slot5 = true;
				canRemove = true;
				Counter.counter++;

			} else if (!isSlotted) { // not valid drop slot, move back to before slot.
				transform.position = currentPosition;
				if (canRemove) {
					canRemove = false;
					Counter.counter--;
				}
			}

		} else if (!isSlotted) { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
			if (canRemove) {
				canRemove = false;
				Counter.counter--;
			}
		}
	}
}
