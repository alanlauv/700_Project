using UnityEngine;
using System.Collections;

public class Y1Q10Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q10 = "Measurement/Y1/Q10";

	// textures
	private Texture2D hint;
	private Texture2D blastOff;

	// Use this for initialization
	void Start () {
		hint = (Texture2D)Resources.Load ("space_hint");
		blastOff = (Texture2D)Resources.Load ("Text/blast_off_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q10);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			// blast off button
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .85f, Screen.width * .2f, Screen.height * .1f), blastOff)) {
				if (Counter.counter == 4) {
					StarDialog.displayStars = true;
				
					// flames appear when correct answer is chosen
					GameObject fire = GameObject.Find ("Fire");
					fire.GetComponent<Renderer> ().enabled = true;
				} else {
					StarDialog.numIncorrect++;
					IncorrectDialog.displayIncorrectDialog = true;
				}
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
