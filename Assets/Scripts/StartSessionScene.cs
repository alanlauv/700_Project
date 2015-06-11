using UnityEngine;
using System.Collections;
using Parse;

public class StartSessionScene : MonoBehaviour {
	string sessionName = "";
	bool sessionCreated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sessionCreated) {
			Application.LoadLevel(AppManager.TEACHER_SCENE);
		}
	}

	void OnGUI () {
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .05f, Screen.width * 1.0f, Screen.height * .1f), "Start Session", titleStyle);
		
		GUI.Box (new Rect (Screen.width * .25f, Screen.height * .2f, Screen.width * .5f, Screen.height * .6f), "");
		
		// enter session name
		GUI.Label (new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "Enter Session Name");
		sessionName = GUI.TextField(new Rect(Screen.width * .3f, Screen.height * .4f, Screen.width * .4f, Screen.height * .07f), sessionName, 25);

		// start button
		if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "Start")) {
			// move to teacher console
			createSession();
		}
	}

	private void createSession () {
		ParseObject session = new ParseObject(sessionName);
		// create fields by empty inputs
		session["device"] = "TEACHER";
		session["firstName"] = "";
		session["lastName"] = "";
		session["currentTask"] = "";
		session["helpNeeded"] = "";
		session.SaveAsync().ContinueWith(t => {
			if (t.IsFaulted || t.IsCanceled) {
				// The session creation failed. Check the error to see why.
				Debug.Log("session creation failed");
			} else {
				// session creation was successful.
				sessionCreated = true;
				AppManager.Instance.currentClass = sessionName;
				// empty session/object created in db so remove as class is now created in Parse
				//session.DeleteAsync(); // actually we need teacher object to start session
			}
		});
	}
}
