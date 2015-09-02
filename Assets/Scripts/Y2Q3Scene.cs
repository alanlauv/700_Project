using UnityEngine;
using System.Collections;

public class Y2Q3Scene : MonoBehaviour {
	public const string MEASUREMENT_Y2Q3 = "Measurement/Y2/Q3";
	
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
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y2Q3);
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
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), fiveText)) {
				StarDialog.displayStars = true;
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
			GUI.DrawTexture(new Rect(Screen.width * .27f, Screen.height * .28f, Screen.width * .05f, Screen.width * .2f), hint);
			GUI.DrawTexture(new Rect(Screen.width * .07f, Screen.height * .28f, Screen.width * .05f, Screen.width * .2f), hint);
		}
	}
}
