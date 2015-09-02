using UnityEngine;
using System.Collections;

public class Y1Q6Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q6 = "Measurement/Y1/Q6";

	//textures
	private Texture2D ladybug;

	// text
	private Texture2D greenPencilText;
	private Texture2D yellowPencilText;
	private Texture2D bluePencilText;
	private Texture2D pinkPencilText;
	
	// Use this for initialization
	void Start () {
		ladybug = (Texture2D)Resources.Load("pics/Lady-Bug_r");

		greenPencilText = (Texture2D)Resources.Load ("Text/green_pencil_text");
		yellowPencilText = (Texture2D)Resources.Load ("Text/yellow_pencil_text");
		bluePencilText = (Texture2D)Resources.Load ("Text/blue_pencil_text");
		pinkPencilText = (Texture2D)Resources.Load ("Text/pink_pencil_text");

		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q6);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			// answer pool
			// Yellow
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .15f, Screen.width * .2f, Screen.height * .1f), greenPencilText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			// green pencil
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .35f, Screen.width * .2f, Screen.height * .1f), bluePencilText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}

			// blue pencil
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .55f, Screen.width * .2f, Screen.height * .1f), pinkPencilText)) {
				StarDialog.displayStars = true;
				AppManager.Instance.addCompletedTask (MEASUREMENT_Y1Q6, StarDialog.numIncorrect, HintButton.hintUsed);
			}

			//pink pencil
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .75f, Screen.width * .2f, Screen.height * .1f), yellowPencilText)) {
				IncorrectDialog.displayIncorrectDialog = true;
				StarDialog.numIncorrect++;
			}
		
			drawLadyBug ();
		}
	}

	private void drawLadyBug () {
		if (HintButton.displayHint) {
			//green
			//GUI.DrawTexture(new Rect(Screen.width * .67f, Screen.height * .12f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//GUI.DrawTexture(new Rect(Screen.width * .72f, Screen.height * .12f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .775f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .23f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//blue
			//GUI.DrawTexture(new Rect(Screen.width * .52f, Screen.height * .32f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .615f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .655f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .695f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .735f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .775f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .43f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//pink
			//GUI.DrawTexture(new Rect(Screen.width * .72f, Screen.height * .52f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//GUI.DrawTexture(new Rect(Screen.width * .77f, Screen.height * .52f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .63f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .63f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .63f, Screen.width * .04f, Screen.height * .06f), ladybug);
			//yellow
			//GUI.DrawTexture(new Rect(Screen.width * .62f, Screen.height * .72f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .695f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .735f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .775f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .815f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .855f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
			GUI.DrawTexture(new Rect(Screen.width * .895f, Screen.height * .83f, Screen.width * .04f, Screen.height * .06f), ladybug);
		}
	}
}
