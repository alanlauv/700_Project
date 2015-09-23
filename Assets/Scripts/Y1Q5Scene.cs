using UnityEngine;
using System.Collections;
/// <summary>
/// Script for game logics of task 5.
/// </summary>

public class Y1Q5Scene : MonoBehaviour {

	public const string MEASUREMENT_Y1Q5 = "Measurement/Y1/Q5";
	
	//textures
	private Texture2D ladybug;

	// Answer pool
	private Texture2D greenPencilText;
	private Texture2D yellowPencilText;
	private Texture2D bluePencilText;
	
	// Use this for initialization
	void Start () {
		ladybug = (Texture2D)Resources.Load("pics/Lady-Bug_l");

		greenPencilText = (Texture2D)Resources.Load ("Text/green_pencil_text");
		yellowPencilText = (Texture2D)Resources.Load ("Text/yellow_pencil_text");
		bluePencilText = (Texture2D)Resources.Load ("Text/blue_pencil_text");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q5);
		AppManager.Instance.setCurrentTaskYearAndNumber (1, 5);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			if (!StarDialog.displayStars) {
				// answer pool
				// yellow pencil
				if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .25f, Screen.width * .2f, Screen.height * .1f), yellowPencilText)) {
					IncorrectDialog.displayIncorrectDialog = true;
					StarDialog.numIncorrect++;
				}
		
				// green pencil
				if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), greenPencilText)) {
					IncorrectDialog.displayIncorrectDialog = true;
					StarDialog.numIncorrect++;
				}
		
				drawLadyBug ();
			}
			// blue pencil
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .65f, Screen.width * .2f, Screen.height * .1f), bluePencilText)) {
				StarDialog.displayStars = true;
				AppManager.Instance.addCompletedTask (MEASUREMENT_Y1Q5, StarDialog.numIncorrect, HintButton.hintUsed);
			}
		}
	}
	/// <summary>
	/// Draws the hints which are lady bugs.
	/// </summary>
	private void drawLadyBug () {
		if (HintButton.displayHint) {
			//Hints drawn for the yellow pencil
			GUI.DrawTexture(new Rect(Screen.width * .09f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .13f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .17f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .21f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .29f, Screen.height * .325f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//Hints drawn for the green pencil
			GUI.DrawTexture(new Rect(Screen.width * .09f, Screen.height * .525f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .13f, Screen.height * .525f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .17f, Screen.height * .525f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//Hints drawn for the blue pencil.
			GUI.DrawTexture(new Rect(Screen.width * .09f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .13f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .17f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .21f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .29f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .33f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .37f, Screen.height * .725f, Screen.width * .04f, Screen.height * .06f), ladybug);

		}
	}
}
