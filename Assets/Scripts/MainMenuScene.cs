using UnityEngine;
using System.Collections;

public class MainMenuScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// toggle sound
		AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");

		// title
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		titleStyle.normal.textColor = Color.black;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .1f, Screen.width * 1.0f, Screen.height * .1f), "SOME TITLE", titleStyle);

		// Number & Algebra button
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .3f, Screen.width * .25f, Screen.height * .4f), "Number\n&\nAlgebra")) {
			// nothing
		}

		// Geometry & measurement button
		if (GUI.Button (new Rect (Screen.width * .375f, Screen.height * .3f, Screen.width * .25f, Screen.height * .4f), "Geometry\n&\nMeasurement")) {
			Application.LoadLevel(AppManager.TASK_SELECTION_SCENE);
		}

		// Statistics button
		if (GUI.Button (new Rect (Screen.width * .7f, Screen.height * .3f, Screen.width * .25f, Screen.height * .4f), "Statistics")) {
			// nothing
		}

		// Teacher's console button
		if (AppManager.Instance.teacherMode) {
			if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .25f, Screen.height * .1f), "Teacher's Console")) {
				// move to teacher console
				Application.LoadLevel(AppManager.TEACHER_SCENE);
			}
		}
	}
}
