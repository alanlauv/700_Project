using UnityEngine;
using System.Collections;

public class Y1Q9Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q9 = "Measurement/Y1/Q9";

	private bool displayHelpButton = false;
	private bool displayRedCross = false;
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
	private Texture2D blastOff;

	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");
		hint = (Texture2D)Resources.Load ("space_hint");
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
		if (!SettingsDialog.displaySettings) {
			// help dialog button (15sec wait) and display astronauts
			if (displayHelpButton) {
				if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), helpIcon)) {
					displayHint = true;
					numIncorrect++;
				}
			}

			// blast off button
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .85f, Screen.width * .2f, Screen.height * .1f), blastOff)) {
				if (AppManager.Instance.loadCounter () == 3) {
					AppManager.Instance.storeNumIncorrect (numIncorrect);

					// flames appear when correct answer is chosen
					GameObject fire = GameObject.Find ("Fire");
					fire.GetComponent<Renderer> ().enabled = true;
				} else {
					numIncorrect++;
					displayRedCross = true;
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
			GUI.DrawTexture(new Rect(Screen.width * .15f, Screen.height * .37f, Screen.width * .5f, Screen.width * .05f), hint);
			GUI.DrawTexture(new Rect(Screen.width * .15f, Screen.height * .77f, Screen.width * .5f, Screen.width * .05f), hint);
		}
	}
}
