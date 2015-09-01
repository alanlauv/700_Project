using UnityEngine;
using System.Collections;

public class Y1Q11mouseDrag : MonoBehaviour {

	static bool slot0 = false;
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
	
	private Texture2D ladybugOutline;
	
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;

		ladybugOutline = (Texture2D)Resources.Load ("Sprites/Lady-Bug_l_outline");
	}
	
	// Update is called once per frame
	void Update () {		
		
	}

	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			if (slot0 == false)
				GUI.DrawTexture (new Rect (Screen.width * .09f, Screen.height * .385f, Screen.width * .042f, Screen.height * .066f), ladybugOutline);
		}
	}

	void OnMouseDrag () {
		if (!isSlotted) {
			//Vector3 mousePosition = new Vector3(Input.mousePosition.x + 130.0f, Input.mousePosition.y - 140.0f, distance);
			
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			//mousePosition.z = transform.position.z;
			
			objPosition = Camera.main.ScreenToViewportPoint (mousePosition);
			objPosition.z = 5.0f;
			
			transform.position = objPosition;
		}
	}
	
	void OnMouseUp () {	
		if (transform.position.y > 0.535f && transform.position.y < 0.635f) {
			if (slot0 == false &&
			    transform.position.x > 0.095f && transform.position.x < 0.125f) { // slot1, +-1.5
				
				transform.position = new Vector3 (0.11f, 0.585f, startZ);
				slot0 = true;
				isSlotted = true;
				AppManager.Instance.incrementCounter();

			} else if (slot1 == false && slot0 == true &&
			    transform.position.x > 0.135f && transform.position.x < 0.165f) { // slot1, +-1.5
				
				transform.position = new Vector3 (0.15f, 0.585f, startZ);
				slot1 = true;
				isSlotted = true;
				AppManager.Instance.incrementCounter();
				
			} else if (slot2 == false && slot1 == true &&
			           transform.position.x > 0.175f && transform.position.x < 0.205f) { // slot 2
				
				transform.position = new Vector3 (0.19f, 0.585f, startZ);
				slot2 = true;
				isSlotted = true;
				AppManager.Instance.incrementCounter();
				
			} else if (slot3 == false && slot2 == true &&
			           transform.position.x > 0.215f && transform.position.x < 0.245f) {
				
				transform.position = new Vector3 (0.23f, 0.585f, startZ);
				slot3 = true;
				isSlotted = true;
				AppManager.Instance.incrementCounter();
				
			} else if (slot4 == false && slot3 == true &&
			           transform.position.x > 0.255f && transform.position.x < 0.285f) {
				
				transform.position = new Vector3 (0.27f, 0.585f, startZ);
				slot4 = true;
				isSlotted = true;
				AppManager.Instance.incrementCounter();
				
			} else if (slot5 == false && slot4 == true &&
			           transform.position.x > 0.295f && transform.position.x < 0.325f) {
				
				transform.position = new Vector3 (0.31f, 0.585f, startZ);
				slot5 = true;
				isSlotted = true;
				AppManager.Instance.incrementCounter();

			} else if (!isSlotted) { // not valid drop slot, move back to before slot.
				transform.position = currentPosition;
			}
			
			
		} else if (!isSlotted) { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}
		
		/**
		if (transform.position.y > 0.1f & transform.position.y < 0.29f) { // slot 1
			//changePos(0.3f);
			transform.position = new Vector3(startX, 0.2f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.3f & transform.position.y < 0.49f) { // slot 2
			//changePos(0.5f);
			transform.position = new Vector3(startX, 0.4f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.5f & transform.position.y < 0.69f) { // slot 3
			//changePos(0.7f);
			transform.position = new Vector3(startX, 0.6f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.7f & transform.position.y < 0.89f) { // slot 3
			//changePos(0.7f);
			transform.position = new Vector3(startX, 0.8f, startZ);
			currentPosition = transform.position;
		} else { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}
		*/
	}
}
