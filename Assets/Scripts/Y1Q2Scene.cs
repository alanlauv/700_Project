using UnityEngine;
using System.Collections;

public class Y1Q2Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q2 = "Measurement/Y1/Q2";
	
	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayAstronaut = false;
	
	private int numIncorrect = 0;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	//textures
	private Texture2D redCross;
	private Texture2D astronaut;
	//settings & help icon
	private Texture2D helpIcon;
	//answers text
	private Texture2D tallerText;
	private Texture2D longerText;
	private Texture2D thinnerText;
	private Texture2D biggerText;
	private Texture2D shorterText;
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		astronaut = (Texture2D)Resources.Load("pics/astronaut");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");

		tallerText = (Texture2D)Resources.Load ("Text/taller_text");
		longerText = (Texture2D)Resources.Load ("Text/longer_text");
		thinnerText = (Texture2D)Resources.Load ("Text/thinner_text");
		biggerText = (Texture2D)Resources.Load ("Text/bigger_text");
		shorterText = (Texture2D)Resources.Load ("Text/shorter_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q2);
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
		
		if (displayAstronaut == false && numIncorrect >= 1) {
			displayHelpButton = true;
		}
	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			// help dialog button (20sec wait) and display astronauts
			if (displayHelpButton) {
				if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), helpIcon)) {
					displayAstronaut = true;
					numIncorrect++;
				}
			}
		
			// answer pool
			// taller
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), tallerText)) {
				displayRedCross = true;
				numIncorrect++;

			}
		
			// thinner
			if (GUI.Button (new Rect (Screen.width * .3f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), longerText)) {
				displayRedCross = true;
				numIncorrect++;
			}
		
			// wider
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), thinnerText)) {
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
				AppManager.Instance.addCompletedTask (MEASUREMENT_Y1Q2, 1);
				AppManager.Instance.storeNumIncorrect (numIncorrect);


				// flames appear when correct answer is chosen
				GameObject fire1 = GameObject.Find ("Fire1");
				fire1.GetComponent<Renderer> ().enabled = true;
			
				GameObject fire2 = GameObject.Find ("Fire2");
				fire2.GetComponent<Renderer> ().enabled = true;
			}
		
			drawAstronaut ();
			drawRedCross ();
		}
	}
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}
	
	private void drawAstronaut () {
		if (displayAstronaut) {

			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .66f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .53f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .4f, Screen.width * .08f, Screen.height * .13f), astronaut);

			GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .66f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .53f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .4f, Screen.width * .08f, Screen.height * .13f), astronaut);
			GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .27f, Screen.width * .08f, Screen.height * .13f), astronaut);
		}
	}
}
