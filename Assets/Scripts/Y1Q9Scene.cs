using UnityEngine;
using System.Collections;

public class Y1Q9Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q9 = "Measurement/Y1/Q9";

	private bool displaySettings = false;
	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayHelpDialog = false;

	private int numIncorrect = 0;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;

	// textures
	private Texture2D redCross;
	private Texture2D bg;
	//settings & help icon
	private Texture2D settingsIcon;
	private Texture2D helpIcon;

	private Texture2D blastOff;

//	private string question = "How many astronauts tall is the purple rocket?";

	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		bg = (Texture2D)Resources.Load("black-bg");
		settingsIcon = (Texture2D)Resources.Load ("pics/cog");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");

		blastOff = (Texture2D)Resources.Load ("Text/blast_off_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q9);

		AppManager.Instance.resetCounter ();
		AppManager.Instance.resetNumIncorrect ();
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
				numIncorrect++;
			}
		}

		// blast off button
		if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .85f, Screen.width * .2f, Screen.height * .1f), blastOff)) {
			if (AppManager.Instance.loadCounter() == 3) {
				AppManager.Instance.storeNumIncorrect(numIncorrect);

				// flames appear when correct answer is chosen
				GameObject fire = GameObject.Find("Fire");
				fire.GetComponent<Renderer>().enabled = true;
			} else {
				numIncorrect++;
				displayRedCross = true;
			}
		}

		drawRedCross();
		drawSettings();
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
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}
}
