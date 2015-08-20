using UnityEngine;
using System.Collections;
using Parse;

public class Y1Q1Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q1 = "Measurement/Y1/Q1";

	private bool displaySettings = false;
	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayGreenCircle = false;
	private bool displayHelpDialog = false;
	private bool displayAstronaut = false;
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
	private Texture2D astronaut;
	private Texture2D star;
	private Texture2D starEmpty;
	//settings & help icon
	private Texture2D settingsIcon;
	private Texture2D helpIcon;
	//answers text
	private Texture2D tallerText;
	private Texture2D longerText;
	private Texture2D widerText;
	private Texture2D biggerText;
	private Texture2D shorterText;

	private Texture2D excellentText;
	private Texture2D goodText;
	private Texture2D completedText;
	private Texture2D okText;

	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("incorrect");
		greenCircle = (Texture2D)Resources.Load("green-circle");
		bg = (Texture2D)Resources.Load("black-bg");
		astronaut = (Texture2D)Resources.Load("pics/astronaut");
		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		settingsIcon = (Texture2D)Resources.Load ("pics/cog");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");

		tallerText = (Texture2D)Resources.Load ("Text/taller_text");
		longerText = (Texture2D)Resources.Load ("Text/longer_text");
		widerText = (Texture2D)Resources.Load ("Text/wider_text");
		biggerText = (Texture2D)Resources.Load ("Text/bigger_text");
		shorterText = (Texture2D)Resources.Load ("Text/shorter_text");

		excellentText = (Texture2D)Resources.Load ("Text/excellent_text");
		goodText = (Texture2D)Resources.Load ("Text/good_text");
		completedText = (Texture2D)Resources.Load ("Text/completed_text");
		okText = (Texture2D)Resources.Load ("Text/ok_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q1);
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

		if (displayAstronaut == false && numIncorrect >= 2) {
			displayAstronaut = true;
			displayHelpButton = true;
		}
	}

	void OnGUI () {

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
				displayAstronaut = true;
				numIncorrect++;
			}
		}

		// answer pool
		// taller
		if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), tallerText)) {
			//displayGreenCircle = true;
			displayStars = true;
//			question = "The green rocket is taller than the blue rocket";

			// flames appear when correct answer is chosen
			GameObject fire1 = GameObject.Find("Fire1");
			fire1.GetComponent<Renderer>().enabled = true;

			GameObject fire2 = GameObject.Find("Fire2");
			fire2.GetComponent<Renderer>().enabled = true;
		}

		// thinner
		if (GUI.Button (new Rect (Screen.width * .3f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), longerText)) {
			displayRedCross = true;
			numIncorrect++;
		}

		// wider
		if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), widerText)) {
			displayRedCross = true;
			numIncorrect++;
		}

		// bigger
		if (GUI.Button (new Rect (Screen.width * .6f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), biggerText)) {
			displayRedCross = true;
			numIncorrect++;
		}

		// shorter
		if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), shorterText)) {
			displayRedCross = true;
			numIncorrect++;
		}

		drawAstronaut();
		drawGreenCircle();
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

			GUI.DrawTexture(new Rect(Screen.width * .41f, Screen.height * .34f, Screen.width * .15f, Screen.height * .23f), astronaut);

			// call for help
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "Ask Teacher")) {
				displayHelpDialog = false;
			}
		}
	}

	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .33f, Screen.height * .15f, Screen.width * .35f, Screen.width * .35f), redCross);
		}
	}

	private void drawGreenCircle () {
		if (displayGreenCircle) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), greenCircle);
		}
	}

	private void drawAstronaut () {
		if (displayAstronaut) {
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .66f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .53f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .4f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .27f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .14f, Screen.width * .08f, Screen.height * .13f), astronaut);

			GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .66f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .53f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .4f, Screen.width * .08f, Screen.height * .13f), astronaut);
		}
	}

	private void drawStars () {
		if (displayStars) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .5f), "");
			
			GUI.DrawTexture(new Rect(Screen.width * .35f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			
			if (numIncorrect == 1) {
				GUI.DrawTexture(new Rect (Screen.width * .4f, Screen.height * .25f, Screen.width * .2f, Screen.height * .1f), goodText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else if (numIncorrect >= 2) {
				GUI.DrawTexture(new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .1f), completedText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), starEmpty);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else {
				GUI.DrawTexture(new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .1f), excellentText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			}

			// ok
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), okText)) {
				AppManager.Instance.addCompletedTask(MEASUREMENT_Y1Q1, 2);
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
		}
	}
}
