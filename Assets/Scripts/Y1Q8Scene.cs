using UnityEngine;
using System.Collections;

public class Y1Q8Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q8 = "Measurement/Y1/Q8";

	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayHintLine = false;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	private int numIncorrect = 0;
	
	//textures
	private Texture2D redCross;
	private Texture2D hintLine;
	//settings & help icon
	private Texture2D helpIcon;

	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		hintLine = (Texture2D)Resources.Load("y1q8_hintline");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q8);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timerMax) { // 60 seconds
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
			// help dialog button
			if (displayHelpButton) {
				if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), helpIcon)) {
					displayHintLine = true;
				}
			}
		
			drawRedCross ();
			drawHintLine ();
		}
	}
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}
	
	private void drawHintLine () {
		if (displayHintLine) { // TODO temp fix
			GUI.DrawTexture(new Rect(Screen.width * .055f, Screen.height * .0f, Screen.width * 0.9f, Screen.height * 1.0f), hintLine);
		}
	}
}
