using UnityEngine;
using System.Collections;
using Parse;

public class Y1Q1Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q1 = "Measurement/Y1/Q1";

	private bool displayRedCross = false;

	//private int numIncorrect = 0;

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
	private Texture2D widerText;
	private Texture2D biggerText;
	private Texture2D shorterText;

	// Use this for initialization
	void Start () {
		AppManager.Instance.resetTaskSceneData ();

		redCross = (Texture2D)Resources.Load("incorrect");
		astronaut = (Texture2D)Resources.Load("pics/astronaut");
		helpIcon = (Texture2D)Resources.Load ("hint_icon");

		tallerText = (Texture2D)Resources.Load ("Text/taller_text");
		longerText = (Texture2D)Resources.Load ("Text/longer_text");
		widerText = (Texture2D)Resources.Load ("Text/wider_text");
		biggerText = (Texture2D)Resources.Load ("Text/bigger_text");
		shorterText = (Texture2D)Resources.Load ("Text/shorter_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q1);
	}
	
	// Update is called once per frame
	void Update () {

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

			// answer pool
			// taller
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), tallerText)) {
				//AppManager.Instance.storeNumIncorrect (numIncorrect);
				StarDialog.displayStars = true;
				AppManager.Instance.addCompletedTask (MEASUREMENT_Y1Q1, StarDialog.numIncorrect, HintButton.hintUsed);

				// flames appear when correct answer is chosen
				GameObject fire1 = GameObject.Find ("Fire1");
				fire1.GetComponent<Renderer> ().enabled = true;

				GameObject fire2 = GameObject.Find ("Fire2");
				fire2.GetComponent<Renderer> ().enabled = true;
			}

			// thinner
			if (GUI.Button (new Rect (Screen.width * .3f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), longerText)) {
				displayRedCross = true;
				StarDialog.numIncorrect++;
			}

			// wider
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), widerText)) {
				displayRedCross = true;
				StarDialog.numIncorrect++;
			}

			// bigger
			if (GUI.Button (new Rect (Screen.width * .6f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), biggerText)) {
				displayRedCross = true;
				StarDialog.numIncorrect++;
			}

			// shorter
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), shorterText)) {
				displayRedCross = true;
				StarDialog.numIncorrect++;
			}

			drawAstronaut ();
			drawRedCross ();
		}
	}

	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .33f, Screen.height * .15f, Screen.width * .43f, Screen.width * .35f), redCross);

			if (StarDialog.numIncorrect >= 2)
				HintButton.flashHintButton = true;
		}
	}

	private void drawAstronaut () {
		if (HintButton.displayHint) {
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
}