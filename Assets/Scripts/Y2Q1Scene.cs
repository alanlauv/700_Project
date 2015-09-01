﻿using UnityEngine;
using System.Collections;

public class Y2Q1Scene : MonoBehaviour {
	public const string MEASUREMENT_Y2Q1 = "Measurement/Y2/Q1";

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
		hint = (Texture2D)Resources.Load ("space_hint");

		oneText = (Texture2D)Resources.Load ("Text/1_text");
		twoText = (Texture2D)Resources.Load ("Text/2_text");
		threeText = (Texture2D)Resources.Load ("Text/3_text");
		fourText = (Texture2D)Resources.Load ("Text/4_text");
		fiveText = (Texture2D)Resources.Load ("Text/5_text");
		sixText = (Texture2D)Resources.Load ("Text/6_text");
		sevenText = (Texture2D)Resources.Load ("Text/7_text");
		eightText = (Texture2D)Resources.Load ("Text/8_text");
		nineText = (Texture2D)Resources.Load ("Text/9_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y2Q1);
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
				AppManager.Instance.storeNumIncorrect (numIncorrect);

				// flames appear when correct answer is chosen
				GameObject fire = GameObject.Find ("Fire");
				fire.GetComponent<Renderer> ().enabled = true;
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
				displayRedCross = true;
				numIncorrect++;
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
