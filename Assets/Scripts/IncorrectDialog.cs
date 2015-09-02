using UnityEngine;
using System.Collections;

public class IncorrectDialog : MonoBehaviour
{
	public static bool displayIncorrectDialog = false;

	private float Timer = 0.0f;
	private float TimerMax = 3.0f;

	private Texture2D incorrect;

	// Use this for initialization
	void Start ()
	{
		displayIncorrectDialog = false;

		incorrect = (Texture2D)Resources.Load("incorrect");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (displayIncorrectDialog) {
			Timer += Time.deltaTime;
			if (Timer >= TimerMax) {
				displayIncorrectDialog = false;
				Timer = 0.0f;
			}
		}
	}

	void OnGUI ()
	{
		if (displayIncorrectDialog) {
			GUI.DrawTexture(new Rect(Screen.width * .27f, Screen.height * .15f, Screen.width * .46f, Screen.width * .35f), incorrect);

			if (StarDialog.numIncorrect >= 2)
				HintButton.flashHintButton = true;
		}
	}
}

