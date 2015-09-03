using UnityEngine;
using System.Collections;

public class TeacherLoginScene : MonoBehaviour {
	string password = "";
	bool keepLoggedIn = false;

	Texture2D backText;
	Texture2D enterText;

	// Use this for initialization
	void Start () {
		backText = (Texture2D)Resources.Load ("Text/back_text");

		enterText = (Texture2D)Resources.Load ("Text/enter_text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box (new Rect (Screen.width * .25f, Screen.height * .2f, Screen.width * .5f, Screen.height * .6f), "");

		// password
		GUI.Label (new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "Password");
		password = GUI.PasswordField(new Rect(Screen.width * .45f, Screen.height * .3f, Screen.width * .25f, Screen.height * .07f), password, "*"[0], 25);

		// enter button
		if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .5f, Screen.width * .2f, Screen.height * .1f), enterText)) {
			// move to session creation
			// if teacher login successful, teacherMode set true
			if (password.Equals(AppManager.TEACHER_PASSWORD)) {
				AppManager.Instance.teacherMode = true;
				Application.LoadLevel(AppManager.START_SESSION_SCENE);
			}
		}

		// keep logged in
		//keepLoggedIn = GUI.Toggle(new Rect(Screen.width * .4f, Screen.height * .65f, Screen.width * .25f, Screen.height * .07f), keepLoggedIn, "  Keep logged in");

		// back button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .2f, Screen.height * .1f), backText)) {
			Application.LoadLevel(AppManager.START_SCENE);
		}
	}
}
