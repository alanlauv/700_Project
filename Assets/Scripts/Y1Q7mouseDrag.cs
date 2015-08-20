using UnityEngine;
using System.Collections;

public class Y1Q7mouseDrag : MonoBehaviour {

	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	
	// Y positions 0.3, 0.5, 0.7
	static float curPinkPencilPos;
	static float curYellowPencilPos;
	static float curGreenPencilPos;
	static float swapPos;

	private bool displaySquiggles = false;
	private bool displayStars = false;
	private bool displayRedCross = false;
	private int numIncorrect = 0;

	private float squigglesTimer = 0.0f;
	private const float squigglesTimerMax = crossTimerMax + 2.0f;
	
	private float crossTimer = 0.0f;
	private const float crossTimerMax = 3.0f;
	
	float distance = 1.0f;
	Vector3 objPosition;
	
	Vector3 currentPosition;
	float startX;
	float startY;
	float startZ;

	private Texture2D star;
	private Texture2D starEmpty;
	private Texture2D redCross;
	private Texture2D squigglyLine;

	// finished text
	private Texture2D finishedText;
	
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;
		
		if (startZ == 1.0f) { // pink
			curPinkPencilPos = currentPosition.y;
		} else if (startZ == 2.0f) { // yellow
			curYellowPencilPos = currentPosition.y;
		} else if (startZ == 3.0f) { // green
			curGreenPencilPos = currentPosition.y;
		}

		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		redCross = (Texture2D)Resources.Load("red-cross");
		squigglyLine = (Texture2D)Resources.Load ("pics/squiggle_left");

		finishedText = (Texture2D)Resources.Load ("Text/finished_text");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPosition.y == 0.3f) {
			if (currentPosition.z == 1.0f) { // pink z=1
				slot1 = true;
			} else {
				slot1 = false;
			}
		} else if (currentPosition.y == 0.5f) {
			if (currentPosition.z == 2.0f) { // yellow z=2
				slot2 = true;
			} else {
				slot2 = false;
			}
		} else if (currentPosition.y == 0.7f) {
			if (currentPosition.z == 3.0f) { // green z=3
				slot3 = true;
			} else {
				slot3 = false;
			}
		}
		
		if (displayRedCross) {
			crossTimer += Time.deltaTime;
			if (crossTimer >= crossTimerMax) {
				displayRedCross = false;
				crossTimer = 0.0f;
			}
		}

		if (displaySquiggles) {
			squigglesTimer += Time.deltaTime;
			if (squigglesTimer >= squigglesTimerMax) {
				displaySquiggles = false;
				squigglesTimer = 0.0f;
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
		if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), finishedText)) {
			displaySquiggles = true;
			if (slot1 == true && slot2 == true && slot3 == true) {
				displayStars = true;
				AppManager.Instance.storeNumIncorrect(numIncorrect);
			} else {
				numIncorrect++;
				displayRedCross = true;
			}
		}

		drawSquigglyLines ();
		//drawStars();
		drawRedCross();
	}
	
	void OnMouseUp () {		
		if (transform.position.y > 0.2f & transform.position.y < 0.39f) { // slot 1
			//changePos(0.3f);
			transform.position = new Vector3(startX, 0.3f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.4f & transform.position.y < 0.59f) { // slot 2
			//changePos(0.5f);
			transform.position = new Vector3(startX, 0.5f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.6f & transform.position.y < 0.79f) { // slot 3
			//changePos(0.7f);
			transform.position = new Vector3(startX, 0.7f, startZ);
			currentPosition = transform.position;
		} else { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}
	}

	private void drawSquigglyLines () {
		if (displaySquiggles) {
			if (slot1)
				GUI.DrawTexture (new Rect (Screen.width * .5f, Screen.height * .625f, Screen.width * .2f, Screen.height * .1f), squigglyLine);

			if (slot2)
				GUI.DrawTexture (new Rect (Screen.width * .4f, Screen.height * .425f, Screen.width * .2f, Screen.height * .1f), squigglyLine);

			if (slot3)
				GUI.DrawTexture (new Rect (Screen.width * .3f, Screen.height * .225f, Screen.width * .2f, Screen.height * .1f), squigglyLine);
		}
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