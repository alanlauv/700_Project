using UnityEngine;
using System.Collections;
using Parse;

public class StartSessionScene : MonoBehaviour {
	string sessionName = "Choose your classroom";
	bool sessionCreated = false;

	bool displayClassSelection = false;
	
	private Texture2D oneText;
	private Texture2D twoText;
	private Texture2D threeText;
	private Texture2D fourText;
	private Texture2D fiveText;
	private Texture2D sixText;
	private Texture2D sevenText;
	private Texture2D eightText;
	private Texture2D nineText;

	// Use this for initialization
	void Start () {
		oneText = (Texture2D)Resources.Load ("Text/1_text");
		twoText = (Texture2D)Resources.Load ("Text/2_text");
		threeText = (Texture2D)Resources.Load ("Text/3_text");
		fourText = (Texture2D)Resources.Load ("Text/4_text");
		fiveText = (Texture2D)Resources.Load ("Text/5_text");
		sixText = (Texture2D)Resources.Load ("Text/6_text");
		sevenText = (Texture2D)Resources.Load ("Text/7_text");
		eightText = (Texture2D)Resources.Load ("Text/8_text");
		nineText = (Texture2D)Resources.Load ("Text/9_text");
	}
	
	// Update is called once per frame
	void Update () {
		if (sessionCreated) {
			Application.LoadLevel(AppManager.TEACHER_SCENE);
		}
	}

	void OnGUI () {
		if (!displayClassSelection) {
			GUI.Box (new Rect (Screen.width * .25f, Screen.height * .2f, Screen.width * .5f, Screen.height * .6f), "");

			// enter session name
			//GUI.Label (new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "Enter Class Name");
			//sessionName = GUI.TextField(new Rect(Screen.width * .3f, Screen.height * .4f, Screen.width * .4f, Screen.height * .07f), sessionName, 25);
			if (GUI.Button (new Rect (Screen.width * .3f, Screen.height * .4f, Screen.width * .4f, Screen.height * .07f), sessionName)) {
				displayClassSelection = true;
			}

			// start button
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "Start")) {
				// move to teacher console
				createSession ();
			}
		}
		drawClassSelection ();
	}

	private void drawClassSelection () {
		if (displayClassSelection) {
			GUI.Box (new Rect (Screen.width * .2f, Screen.height * .2f, Screen.width * .6f, Screen.height * .7f), "");
			
			if (GUI.Button (new Rect (Screen.width * .27f, Screen.height * .25f, Screen.width * .1f, Screen.width * .1f), oneText)) {
				displayClassSelection = false;
				sessionName = AppManager.room1;
			}
			
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .25f, Screen.width * .1f, Screen.width * .1f), twoText)) {
				displayClassSelection = false;
				sessionName = AppManager.room2;
			}
			
			if (GUI.Button (new Rect (Screen.width * .63f, Screen.height * .25f, Screen.width * .1f, Screen.width * .1f), threeText)) {
				displayClassSelection = false;
				sessionName = AppManager.room3;
			}
			
			if (GUI.Button (new Rect (Screen.width * .27f, Screen.height * .45f, Screen.width * .1f, Screen.width * .1f), fourText)) {
				displayClassSelection = false;
				sessionName = AppManager.room4;
			}
			
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .45f, Screen.width * .1f, Screen.width * .1f), fiveText)) {
				displayClassSelection = false;
				sessionName = AppManager.room5;
			}
			
			if (GUI.Button (new Rect (Screen.width * .63f, Screen.height * .45f, Screen.width * .1f, Screen.width * .1f), sixText)) {
				displayClassSelection = false;
				sessionName = AppManager.room6;
			}
			
			if (GUI.Button (new Rect (Screen.width * .27f, Screen.height * .65f, Screen.width * .1f, Screen.width * .1f), sevenText)) {
				displayClassSelection = false;
				sessionName = AppManager.room7;
			}
			
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .65f, Screen.width * .1f, Screen.width * .1f), eightText)) {
				displayClassSelection = false;
				sessionName = AppManager.room8;
			}
			
			if (GUI.Button (new Rect (Screen.width * .63f, Screen.height * .65f, Screen.width * .1f, Screen.width * .1f), nineText)) {
				displayClassSelection = false;
				sessionName = AppManager.room9;
			}
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
		session["completedTasks"] = "";
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
