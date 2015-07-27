using UnityEngine;
using System.Collections;

public class Y1Q5Scene : MonoBehaviour {

	public const string MEASUREMENT_Y1Q5 = "Measurement/Y1/Q5";
	
	private bool displaySettings = false;
	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayGreenCircle = false;
	private bool displayHelpDialog = false;
	private bool displayLadybug = false;
	private bool displayStars = false;
	
	private int numIncorrect = 0;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	private float circleTimer = 0.0f;
	private float circleTimerMax = 3.0f;
	
	//textures
	private Texture2D redCross;
	private Texture2D greenCircle;
	private Texture2D bg;
	private Texture2D ladybug;
	private Texture2D star;
	private Texture2D starEmpty;
	//settings & help icon
	private Texture2D settingsIcon;
	private Texture2D helpIcon;
	// text
	private Texture2D greenPencilText;
	private Texture2D yellowPencilText;
	private Texture2D bluePencilText;
	
	private string question = "Choose the longest pencil!";
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		greenCircle = (Texture2D)Resources.Load("green-circle");
		bg = (Texture2D)Resources.Load("black-bg");
		ladybug = (Texture2D)Resources.Load("pics/Lady-Bug_l");
		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		settingsIcon = (Texture2D)Resources.Load ("pics/cog");
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
		
		if (displayGreenCircle) {
			circleTimer += Time.deltaTime;
			if (circleTimer >= circleTimerMax) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
		}
		
		if (displayLadybug == false && numIncorrect >= 2) {
			displayLadybug = true;
			displayHelpButton = true;
		}
	}
	
	void OnGUI () {
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		titleStyle.normal.textColor = Color.black;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .07f, Screen.width * 0.5f, Screen.height * .1f), question, titleStyle);
		
		// settings button
		if (GUI.Button (new Rect (Screen.width * .95f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), settingsIcon)) {
			if (displaySettings) {
				displaySettings = false;
			} else {
				displaySettings = true;
			}
		}
		
		// help dialog button (20sec wait) and display astronauts
		if (displayHelpButton) {
			if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), helpIcon)) {
				// TODO don't need help dialog anymore?
				//if (displayHelpDialog) {
				//	displayHelpDialog = false;
				//} else {
				//	displayHelpDialog = true;
				//}
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
			displayStars = true;
		}
		
		drawLadyBug();
		drawRedCross();
		drawHelpDialog();
		drawSettings();
		drawStars();
	}
	
	private void drawSettings () {
		if (displaySettings) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bg);
			
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .4f, Screen.height * .5f), "");
			
			// continue
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .35f, Screen.width * .2f, Screen.height * .1f), "Continue")) {
				displaySettings = false;
			}
			
			// task selection
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .5f, Screen.width * .2f, Screen.height * .1f), "Main Menu")) {
				AppManager.Instance.exitTask(AppManager.MAIN_MENU_SCENE);
			}
			
			// quit
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .65f, Screen.width * .2f, Screen.height * .1f), "Quit")) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
			
			// sound
			AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");
		}
	}
	
	private void drawHelpDialog () {
		if (displayHelpDialog) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .5f), "Look at");
			
			// close dialog button
			if (GUI.Button (new Rect (Screen.width * .64f, Screen.height * .26f, Screen.width * .05f, Screen.width * .05f), "X")) {
				displayHelpDialog = false;
			}
			
			GUI.DrawTexture(new Rect(Screen.width * .41f, Screen.height * .34f, Screen.width * .15f, Screen.height * .23f), ladybug);
			
			// call for help
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "Ask Teacher")) {
				displayHelpDialog = false;
			}
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
