using UnityEngine;
using System.Collections;

public class Y1Q12Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q12 = "Measurement/Y1/Q12";

	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayFinishButton = true;
	private bool displayHint = false;

	private int numIncorrect = 0;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	// textures
	private Texture2D redCross;
	//settings & help icon
	private Texture2D helpIcon;
	private Texture2D hint;
	// finished text
	private Texture2D finishedText;

//	private string question = "How many ladybugs long is the blue pencil?";
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");
		hint = (Texture2D)Resources.Load ("diary_hint");
		finishedText = (Texture2D)Resources.Load ("Text/finished_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q12);

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
		if (!SettingsDialog.displaySettings) {		
			// help dialog button (20sec wait) and display astronauts
			if (displayHelpButton) {
				if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), helpIcon)) {
					displayHint = true;
					numIncorrect++;
				}
			}

			// finished button
			if (displayFinishButton) {
				if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), finishedText)) {
					if (AppManager.Instance.loadCounter () == 9) {
						AppManager.Instance.storeNumIncorrect (numIncorrect);
						displayFinishButton = false;
					} else {
						numIncorrect++;
						displayRedCross = true;
					}
				}
			}
		
			drawRedCross ();
			drawHint ();
		}
	}
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}
	private void drawHint (){
		if (displayHint) {
			GUI.DrawTexture(new Rect(Screen.width * .435f, Screen.height * .28f, Screen.width * .05f, Screen.width * .2f), hint);
			GUI.DrawTexture(new Rect(Screen.width * .07f, Screen.height * .28f, Screen.width * .05f, Screen.width * .2f), hint);
		}
	}
}