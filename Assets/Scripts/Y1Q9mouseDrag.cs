using UnityEngine;
using System.Collections;

public class Y1Q9mouseDrag : MonoBehaviour {

	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	static bool slot4 = false;
	
	private bool displayStars = false;
	private bool displayRedCross = false;
	private int numIncorrect = 0;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	float distance = 1.0f;
	Vector3 objPosition;
	
	Vector3 currentPosition;
	float startX;
	float startY;
	float startZ;
	
	private Texture2D star;
	private Texture2D starEmpty;
	private Texture2D redCross;
	
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;
		
		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		redCross = (Texture2D)Resources.Load("red-cross");
	}
	
	// Update is called once per frame
	void Update () {		
		if (displayRedCross) {
			crossTimer += Time.deltaTime;
			if (crossTimer >= crossTimerMax) {
				displayRedCross = false;
				crossTimer = 0.0f;
			}
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
		if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), "Done!")) {
			if (slot1 == true && slot2 == true && slot3 == true) {
				displayStars = true;
			} else {
				numIncorrect++;
				displayRedCross = true;
			}
		}
		
		drawStars();
		drawRedCross();
	}
	
	void OnMouseUp () {	
		if (transform.position.x > 0.5f && transform.position.x < 0.6f) {
			if (slot1 == false &&
			    transform.position.y > 0.2f && transform.position.y < 0.32f) { // slot1, +-6 from 0.26f

				transform.position = new Vector3 (0.55f, 0.26f, startZ);
				slot1 = true;
			
			} else if (slot2 == false && slot1 == true &&
			           transform.position.y > 0.33f && transform.position.y < 0.45f) { // slot 2, height of astro is 0.13f

				transform.position = new Vector3 (0.55f, 0.39f, startZ);
				slot2 = true;

			} else if (slot3 == false && slot1 == true && slot2 == true &&
			           transform.position.y > 0.46f && transform.position.y < 0.58f) {

				transform.position = new Vector3 (0.55f, 0.52f, startZ);
				slot3 = true;
			
			} else if (slot4 == false && slot1 == true && slot2 == true && slot3 == true &&
			           transform.position.y > 0.59f && transform.position.y < 0.71f) {
				
				transform.position = new Vector3 (0.55f, 0.65f, startZ);
				slot4 = true;

			} else { // not valid drop slot, move back to before slot.
				transform.position = currentPosition;
			}


		} else { // not valid drop slot, move back to before slot.
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
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}
	
	private void drawStars () {
		if (displayStars) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .5f), "Completed");
			
			GUI.DrawTexture(new Rect(Screen.width * .35f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			
			if (numIncorrect == 1) {
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else if (numIncorrect >= 2) {
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), starEmpty);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else {
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			}
			
			// ok
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "OK")) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
		}
	}
}
