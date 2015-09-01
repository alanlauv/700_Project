using UnityEngine;
using System.Collections;

public class Y1Q6Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q6 = "Measurement/Y1/Q6";

	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayLadybug = false;
	private bool displayHint = false;
	
	private int numIncorrect = 0;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	//textures
	private Texture2D redCross;
	private Texture2D ladybug;
	//settings & help icon
	private Texture2D helpIcon;
	private Texture2D hint;
	// text
	private Texture2D greenPencilText;
	private Texture2D yellowPencilText;
	private Texture2D bluePencilText;
	private Texture2D pinkPencilText;
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		ladybug = (Texture2D)Resources.Load("pics/Lady-Bug_r");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");

		greenPencilText = (Texture2D)Resources.Load ("Text/green_pencil_text");
		yellowPencilText = (Texture2D)Resources.Load ("Text/yellow_pencil_text");
		bluePencilText = (Texture2D)Resources.Load ("Text/blue_pencil_text");
		pinkPencilText = (Texture2D)Resources.Load ("Text/pink_pencil_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q6);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (displayHelpButton == false && timer >= timerMax) {
			//Debug.Log("timerMax reached!");
			displayHelpButton = true;
		}
		
		if (displayRedCross) {
			crossTimer += Time.deltaTime;
			if (crossTimer >= crossTimerMax) {
				displayRedCross = false;
				crossTimer = 0.0f;
			}
		}
		
		if (displayLadybug == false && numIncorrect >= 2) {
			displayLadybug = true;
			displayHelpButton = true;
		}
	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			// help dialog button (20sec wait) and display astronauts
			if (displayHelpButton) {
				if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), helpIcon)) {
					displayLadybug = true;
					numIncorrect++;
				}
			}
		
			// answer pool
			// Yellow
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .15f, Screen.width * .2f, Screen.height * .1f), greenPencilText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			// green pencil
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .35f, Screen.width * .2f, Screen.height * .1f), bluePencilText)) {
				displayRedCross = true;
				numIncorrect++;
			}

			// blue pencil
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .55f, Screen.width * .2f, Screen.height * .1f), pinkPencilText)) {
				AppManager.Instance.storeNumIncorrect (numIncorrect);
			}

			//pink pencil
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .75f, Screen.width * .2f, Screen.height * .1f), yellowPencilText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			drawLadyBug ();
			drawRedCross ();
		}
	}
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}

	private void drawLadyBug () {
		if (displayLadybug) {
			//green
			//GUI.DrawTexture(new Rect(Screen.width * .67f, Screen.height * .12f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//GUI.DrawTexture(new Rect(Screen.width * .72f, Screen.height * .12f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .775f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//blue
			//GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .32f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .615f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .655f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .695f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .735f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .775f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//pink
			//GUI.DrawTexture(new Rect(Screen.width * .72f, Screen.height * .52f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//GUI.DrawTexture(new Rect(Screen.width * .77f, Screen.height * .52f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .63f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .63f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .63f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//yellow
			//GUI.DrawTexture(new Rect(Screen.width * .62f, Screen.height * .72f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .695f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .735f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .775f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
		}
	}
}
