using UnityEngine;
using System.Collections;

public class Y2Q2Scene : MonoBehaviour {
	public const string MEASUREMENT_Y2Q2 = "Measurement/Y2/Q2";
	
	// textures
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
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y2Q2);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			// answer pool
			if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), oneText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), twoText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), threeText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), fourText)) {
				StarDialog.displayStars = true;

				// flames appear when correct answer is chosen
				GameObject fire = GameObject.Find ("Fire");
				fire.GetComponent<Renderer> ().enabled = true;
			}
		
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), fiveText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), sixText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), sevenText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), eightText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .85f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), nineText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
			
			drawHint ();
		}
	}

	private void drawHint (){
		if (HintButton.displayHint) {
			GUI.DrawTexture(new Rect(Screen.width * .15f, Screen.height * .235f, Screen.width * .5f, Screen.width * .05f), hint);
			GUI.DrawTexture(new Rect(Screen.width * .15f, Screen.height * .77f, Screen.width * .5f, Screen.width * .05f), hint);
		}
	}
}
