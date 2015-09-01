using UnityEngine;
using System.Collections;

public class Y1Q5Scene : MonoBehaviour {

	public const string MEASUREMENT_Y1Q5 = "Measurement/Y1/Q5";

	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayLadybug = false;
	
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
	// text
	private Texture2D greenPencilText;
	private Texture2D yellowPencilText;
	private Texture2D bluePencilText;
	
	private string question = ""; // "Choose the longest pencil!";
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		ladybug = (Texture2D)Resources.Load("pics/Lady-Bug_l");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");

		greenPencilText = (Texture2D)Resources.Load ("Text/green_pencil_text");
		yellowPencilText = (Texture2D)Resources.Load ("Text/yellow_pencil_text");
		bluePencilText = (Texture2D)Resources.Load ("Text/blue_pencil_text");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q5);
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
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .25f, Screen.width * .2f, Screen.height * .1f), yellowPencilText)) {
				displayRedCross = true;
				numIncorrect++;
			
			}
		
			// green pencil
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), greenPencilText)) {
				displayRedCross = true;
				numIncorrect++;
			}
			
			// blue pencil
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .65f, Screen.width * .2f, Screen.height * .1f), bluePencilText)) {
				AppManager.Instance.storeNumIncorrect (numIncorrect);
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
			//yellow
			GUI.DrawTexture(new Rect(Screen.width * .09f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .13f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .17f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .21f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .29f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//green
			GUI.DrawTexture(new Rect(Screen.width * .09f, Screen.height * .525f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .13f, Screen.height * .525f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .17f, Screen.height * .525f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//GUI.DrawTexture(new Rect(Screen.width * .21f, Screen.height * .54f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .54f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//blue
			GUI.DrawTexture(new Rect(Screen.width * .09f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .13f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .17f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .21f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .29f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .33f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);

		}
	}
}
