using UnityEngine;
using System.Collections;

public class Y1Q2Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q2 = "Measurement/Y1/Q2";
	
	//textures
	private Texture2D astronaut;

	//answers text
	private Texture2D tallerText;
	private Texture2D longerText;
	private Texture2D thinnerText;
	private Texture2D biggerText;
	private Texture2D shorterText;
	
	// Use this for initialization
	void Start () {
		astronaut = (Texture2D)Resources.Load("pics/astronaut");

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

	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
					
			// answer pool
			// taller
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), tallerText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;

			}
		
			// thinner
			if (GUI.Button (new Rect (Screen.width * .3f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), longerText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			// wider
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), thinnerText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			// bigger
			if (GUI.Button (new Rect (Screen.width * .6f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), biggerText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			// shorter
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .8f, Screen.width * .12f, Screen.height * .1f), shorterText)) {
				StarDialog.displayStars = true;
				AppManager.Instance.addCompletedTask (MEASUREMENT_Y1Q2, StarDialog.numIncorrect, HintButton.hintUsed);

				// flames appear when correct answer is chosen
				GameObject fire1 = GameObject.Find ("Fire1");
				fire1.GetComponent<Renderer> ().enabled = true;
			
				GameObject fire2 = GameObject.Find ("Fire2");
				fire2.GetComponent<Renderer> ().enabled = true;
			}
		
			drawAstronaut ();
		}
	}

	private void drawAstronaut () {
		if (HintButton.displayHint) {

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
