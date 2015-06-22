using UnityEngine;
using System.Collections;

public class Y1Q2Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q2 = "Measurement/Y1/Q2";
	
	private bool displaySettings = false;
	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayHelpDialog = false;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 60.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	private float circleTimer = 0.0f;
	private float circleTimerMax = 3.0f;
	
	//textures
	private Texture2D redCross;
	private Texture2D bg;
	private Texture2D redRocket;
	private Texture2D blueRocket;
	private Texture2D greenRocket;
	private Texture2D purpleRocket;
	private string question = "Sort the 4 rockets from the tallest to the shortest!";
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		redRocket= (Texture2D)Resources.Load("rocket_red");
		blueRocket= (Texture2D)Resources.Load("rocket_blue");
		greenRocket= (Texture2D)Resources.Load("rocket_green");
		purpleRocket= (Texture2D)Resources.Load("rocket_purple");
		bg = (Texture2D)Resources.Load("black-bg");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q2);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timerMax) { // 60 seconds
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
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .05f, Screen.width * 1.0f, Screen.height * .1f), question, titleStyle);

		//drawRedRocket();
		//drawBlueRocket();
		//drawGreenRocket();
		//drawPurpleRocket();

		// settings button

		if (GUI.Button (new Rect (Screen.width * .95f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), "S")) {
			if (displaySettings) {
				displaySettings = false;
			} else {
				displaySettings = true;
			}
		}
		
		// help dialog button (1min wait)
		if (displayHelpButton) {
			if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), "H")) {
				if (displayHelpDialog) {
					displayHelpDialog = false;
				} else {
					displayHelpDialog = true;
				}
			}
		}

		drawRedCross();
		drawHelpDialog();
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
	
	private void drawHelpDialog () {
		if (displayHelpDialog) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .5f), "Help dialog text to give hints");
			
			// call for help
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "Call for help")) {
				displayHelpDialog = false;
			}
		}
	}
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}

	private void drawRedRocket () {
		GUI.DrawTexture(new Rect(Screen.width * .23f, Screen.height * .235f, Screen.width * .24f, Screen.width * .48f), redRocket);

	}
	private void drawBlueRocket () {
		GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .275f, Screen.width * .29f, Screen.width * .45f), blueRocket);
		
	}
	private void drawGreenRocket () {
		GUI.DrawTexture(new Rect(Screen.width * .73f, Screen.height * .07f, Screen.width * .283f, Screen.width * .6f), greenRocket);
		
	}
	private void drawPurpleRocket () {
		GUI.DrawTexture(new Rect(Screen.width * .0f, Screen.height * .52f, Screen.width * .23f, Screen.width * .30f), purpleRocket);
		
	}
	

}
