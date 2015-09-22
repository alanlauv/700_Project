using UnityEngine;
using System.Collections;

/// <summary>
/// Settings dialog used in all task scenes, shown on the bottom right hand corner.
/// </summary>
public class SettingsDialog : MonoBehaviour
{
	public static bool displaySettings = false;
	
	private Texture2D settingsIcon;

	private Texture2D continueText;
	private Texture2D quitText;

	// Use this for initialization
	void Start () {
		displaySettings = false;

		settingsIcon = (Texture2D)Resources.Load ("pics/cog");

		continueText = (Texture2D)Resources.Load ("Text/continue_text");
		quitText = (Texture2D)Resources.Load ("Text/quit_text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.depth = -20;

		if (!StarDialog.displayStars) {
			// settings button
			if (GUI.Button (new Rect (Screen.width * .95f, Screen.height * .918f, Screen.width * .05f, Screen.width * .05f), settingsIcon)) {
				if (displaySettings) {
					displaySettings = false;
				} else {
					displaySettings = true;
				}
			}
			drawSettings ();
		}
	}

	// displaying the settings dialog
	private void drawSettings () {
		if (displaySettings) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .4f, Screen.height * .5f), "");
			
			// continue
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .4f, Screen.width * .3f, Screen.height * .1f), continueText)) {
				displaySettings = false;
			}
			
			// quit to task selection
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .6f, Screen.width * .3f, Screen.height * .1f), quitText)) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
			
			// sound
			//AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");
		}
	}
}

