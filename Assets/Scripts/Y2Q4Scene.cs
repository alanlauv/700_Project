using UnityEngine;
using System.Collections;

public class Y2Q4Scene : MonoBehaviour {
	public const string MEASUREMENT_Y2Q4 = "Measurement/Y2/Q4";

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
	// answer pool text
	private Texture2D oneText;
	private Texture2D twoText;
	private Texture2D threeText;
	private Texture2D fourText;
	private Texture2D fiveText;
	private Texture2D sixText;
	private Texture2D sevenText;
	private Texture2D eightText;
	private Texture2D nineText;
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");
		hint = (Texture2D)Resources.Load ("diary_hint");

		oneText = (Texture2D)Resources.Load ("Text/1_2_text");
		twoText = (Texture2D)Resources.Load ("Text/2_2_text");
		threeText = (Texture2D)Resources.Load ("Text/3_2_text");
		fourText = (Texture2D)Resources.Load ("Text/4_2_text");
		fiveText = (Texture2D)Resources.Load ("Text/5_2_text");
		sixText = (Texture2D)Resources.Load ("Text/6_2_text");
		sevenText = (Texture2D)Resources.Load ("Text/7_2_text");
		eightText = (Texture2D)Resources.Load ("Text/8_2_text");
		nineText = (Texture2D)Resources.Load ("Text/9_2_text");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y2Q4);
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
		
			// answer pool
			if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), oneText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), twoText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), threeText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), fourText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), fiveText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), sixText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), sevenText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), eightText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .85f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), nineText)) {
				AppManager.Instance.storeNumIncorrect (numIncorrect);
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
