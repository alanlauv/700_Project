using UnityEngine;
using System.Collections;

public class MainMenuScene : MonoBehaviour {

	private Texture2D numberText;
	private Texture2D geometryText;
	private Texture2D statisticsText;

	// Use this for initialization
	void Start () {
		numberText = (Texture2D)Resources.Load ("Text/number_and_algebra_text");
		geometryText = (Texture2D)Resources.Load ("Text/geometry_and_measurement_text");
		statisticsText = (Texture2D)Resources.Load ("Text/statistics_text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// toggle sound
		//AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");

		// title
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		titleStyle.normal.textColor = Color.black;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .1f, Screen.width * 1.0f, Screen.height * .1f), "SOME TITLE", titleStyle);

		// Number & Algebra button
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .3f, Screen.width * .25f, Screen.height * .4f), "")) {
			// nothing
		}
		GUI.DrawTexture (new Rect (Screen.width * .1125f, Screen.height * .425f, Screen.width * .125f, Screen.height * .16f), numberText);

		// Geometry & measurement button
		if (GUI.Button (new Rect (Screen.width * .375f, Screen.height * .3f, Screen.width * .25f, Screen.height * .4f), geometryText)) {
			Application.LoadLevel(AppManager.TASK_SELECTION_SCENE);
		}

		// Statistics button
		if (GUI.Button (new Rect (Screen.width * .7f, Screen.height * .3f, Screen.width * .25f, Screen.height * .4f), "")) {
			// nothing
		}
		GUI.DrawTexture (new Rect (Screen.width * .75f, Screen.height * .475f, Screen.width * .15f, Screen.height * .05f), statisticsText);

		// Teacher's console button
		if (AppManager.Instance.teacherMode) {
			if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .25f, Screen.height * .1f), "Teacher's Console")) {
				// move to teacher console
				Application.LoadLevel(AppManager.TEACHER_SCENE);
			}
		}
	}
}
