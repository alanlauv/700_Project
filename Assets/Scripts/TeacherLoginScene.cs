using UnityEngine;
using System.Collections;

public class TeacherLoginScene : MonoBehaviour {
	string password = "";
	bool keepLoggedIn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		titleStyle.normal.textColor = Color.black;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .1f, Screen.width * 1.0f, Screen.height * .1f), "This is a Teacher's only Area!", titleStyle);

		GUI.Box (new Rect (Screen.width * .25f, Screen.height * .2f, Screen.width * .5f, Screen.height * .6f), "");

		// password
		GUI.Label (new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "Password");
		password = GUI.PasswordField(new Rect(Screen.width * .45f, Screen.height * .3f, Screen.width * .25f, Screen.height * .07f), password, "*"[0], 25);

		// enter button
		if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), "Enter")) {
			// move to session creation
			// if teacher login successful, teacherMode set true
			AppManager.Instance.teacherMode = true;
			Application.LoadLevel(AppManager.START_SESSION_SCENE);
		}

		// keep logged in
		keepLoggedIn = GUI.Toggle(new Rect(Screen.width * .4f, Screen.height * .65f, Screen.width * .25f, Screen.height * .07f), keepLoggedIn, "  Keep logged in");

		// back button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .2f, Screen.height * .1f), "Back")) {
			Application.LoadLevel(AppManager.START_SCENE);
		}
	}
}
