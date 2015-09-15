using UnityEngine;
using System.Collections;

public class Y1Q12Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q12 = "Measurement/Y1/Q12";
	
	// textures
	private Texture2D hint;

	// finished text
	private Texture2D finishedText;

	// Use this for initialization
	void Start () {
		hint = (Texture2D)Resources.Load ("diary_hint");
		finishedText = (Texture2D)Resources.Load ("Text/finished_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q12);
		AppManager.Instance.setCurrentTaskYearAndNumber (1, 12);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			// finished button
			if (!StarDialog.displayStars) {
				if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), finishedText)) {
					if (Counter.counter == 9) {
						StarDialog.displayStars = true;
						AppManager.Instance.addCompletedTask (MEASUREMENT_Y1Q12, StarDialog.numIncorrect, HintButton.hintUsed);
					} else {
						StarDialog.numIncorrect++;
						IncorrectDialog.displayIncorrectDialog = true;
					}
				}
			}
		
			drawHint ();
		}
	}

	private void drawHint (){
		if (HintButton.displayHint) {
			GUI.DrawTexture(new Rect(Screen.width * .435f, Screen.height * .28f, Screen.width * .05f, Screen.width * .2f), hint);
			GUI.DrawTexture(new Rect(Screen.width * .07f, Screen.height * .28f, Screen.width * .05f, Screen.width * .2f), hint);
		}
	}
}