using UnityEngine;
using System.Collections;

public class Y1Q8mouseDrag : MonoBehaviour {

	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	static bool slot4 = false;
	
	// Y positions 0.2, 0.4, 0.6, 0.8
	static float curPinkPencilPos;
	static float curYellowPencilPos;
	static float curGreenPencilPos;
	static float curBluePencilPos;
	static float swapPos;
	
	float distance = 1.0f;
	Vector3 objPosition;
	
	Vector3 currentPosition;
	float startX;
	float startY;
	float startZ;
	
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;
		
		if (startZ == 1.0f) { // yellow
			curPinkPencilPos = currentPosition.y;
		} else if (startZ == 2.0f) { // green
			curYellowPencilPos = currentPosition.y;
		} else if (startZ == 3.0f) { // blue
			curGreenPencilPos = currentPosition.y;
		} else if (startZ == 4.0f) { // pink
			curPinkPencilPos = currentPosition.y;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPosition.y == 0.8f) {
			if (currentPosition.z == 1.0f) { // yellow
				slot1 = true;;
			} else {
				slot1 = false;
			}
		} else if (currentPosition.y == 0.6f) {
			if (currentPosition.z == 2.0f) { // green
				slot2 = true;
			} else {
				slot2 = false;
			}
		} else if (currentPosition.y == 0.4f) {
			if (currentPosition.z == 3.0f) { // blue
				slot3 = true;
			} else {
				slot3 = false;
			}
		} else if (currentPosition.y == 0.2f) {
			if (currentPosition.z == 4.0f) { // pink
				slot4 = true;
			} else {
				slot4 = false;
			}
		}
		
		if (slot1 == true && slot2 == true && slot3 == true && slot4 == true) {
			Debug.Log ("task completed");
		}
	}
	
	void OnMouseDrag () {
		//Vector3 mousePosition = new Vector3(Input.mousePosition.x + 130.0f, Input.mousePosition.y - 140.0f, distance);
		
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		//mousePosition.z = transform.position.z;
		
		objPosition	= Camera.main.ScreenToViewportPoint(mousePosition);
		objPosition.z = 5.0f;
		
		transform.position = objPosition;
	}
	
	void OnGUI () {
		
	}
	
	void OnMouseUp () {		
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
	}
}
