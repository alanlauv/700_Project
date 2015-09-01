using UnityEngine;
using System.Collections;

public class HintButton : MonoBehaviour
{
	public static bool displayHintButton = false;
	public static bool displayHint = false;
	public static bool flashHintButton = false;
	public static bool hintUsed = false;

	private bool flash = false;

	private float timer = 0.0f;
	private float timerMax = 4.0f;

	private float timer2 = 0.0f;
	private float timerMax2 = 15.0f;

	private Texture2D helpIcon;

	// Use this for initialization
	void Start () {
		helpIcon = (Texture2D)Resources.Load ("hint_icon");
	}
	
	// Update is called once per frame
	void Update () {
		// hint is not used and player just answered incorrectly >= twice so flash button
		if (!displayHint && flashHintButton) {
			timer += Time.deltaTime;

			if (timer >= 0.5f && timer <= 1.0f || timer >= 1.5f && timer <= 2.0f || timer >= 2.5f && timer <= 3.0f || timer >= 3.5f && timer <= 4.0f)
				flash = true;

			if (timer >= 1.0f && timer <= 1.5f || timer >= 2f && timer <= 2.5f || timer >= 3f && timer <= 3.5f)
				flash = false;

			if (timer >= timerMax) {
				displayHintButton = true;
				flashHintButton = false;
				flash = false;
				timer = 0.0f;
			}
		}

		// display this button after 15 seconds if not already
		if (!displayHint && !displayHintButton) {
			timer2 += Time.deltaTime;
			if (timer2 >= timerMax2) {
				HintButton.displayHintButton = true;
			}
		}

		if (StarDialog.numIncorrect >= 1) {
			displayHintButton = true;
		}
	}

	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			if (!flash && !displayHint && displayHintButton) {
				if (GUI.Button (new Rect (Screen.width * .9f, Screen.height * .0f, Screen.width * .1f, Screen.width * .1f), helpIcon)) {
					displayHint = true;
					displayHintButton = false;
					hintUsed = true;
					StarDialog.numIncorrect++;
				}
			}
		}
	}
}

