using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class StartScene : MonoBehaviour {
	string firstName = "First name";
	string lastName = "Last name";
	string className = "";
	string classNameToDisplay = "Choose your classroom";
	string deviceName = null;

	bool displayClassSelection = false;

	bool loggedIn = false;

	const string ROOM_1 = "Room 1";
	const string ROOM_2 = "Room 2";
	const string ROOM_3 = "Room 3";
	const string ROOM_4 = "Room 4";
	const string ROOM_5 = "Room 5";
	const string ROOM_6 = "Room 6";
	const string ROOM_7 = "Room 7";
	const string ROOM_8 = "Room 8";
	const string ROOM_9 = "Room 9";

	private Texture2D oneText;
	private Texture2D twoText;
	private Texture2D threeText;
	private Texture2D fourText;
	private Texture2D fiveText;
	private Texture2D sixText;
	private Texture2D sevenText;
	private Texture2D eightText;
	private Texture2D nineText;
	
	Texture2D enterText;

	// Use this for initialization
	void Start () {
		deviceName = SystemInfo.deviceName;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		oneText = (Texture2D)Resources.Load ("Text/1_text");
		twoText = (Texture2D)Resources.Load ("Text/2_text");
		threeText = (Texture2D)Resources.Load ("Text/3_text");
		fourText = (Texture2D)Resources.Load ("Text/4_text");
		fiveText = (Texture2D)Resources.Load ("Text/5_text");
		sixText = (Texture2D)Resources.Load ("Text/6_text");
		sevenText = (Texture2D)Resources.Load ("Text/7_text");
		eightText = (Texture2D)Resources.Load ("Text/8_text");
		nineText = (Texture2D)Resources.Load ("Text/9_text");

		enterText = (Texture2D)Resources.Load ("Text/enter_text");
	}
	
	// Update is called once per frame
	void Update () {
		if (loggedIn) {
			// move to main menu
			AppManager.Instance.teacherMode = false;
			Application.LoadLevel(AppManager.MAIN_MENU_SCENE);
		}
	}

	void OnGUI () {
		if (!displayClassSelection) {
			GUI.Box (new Rect (Screen.width * .25f, Screen.height * .3f, Screen.width * .5f, Screen.height * .6f), "");

			// name input
			firstName = GUI.TextField (new Rect (Screen.width * .3f, Screen.height * .4f, Screen.width * .4f, Screen.height * .07f), firstName, 25);
			lastName = GUI.TextField (new Rect (Screen.width * .3f, Screen.height * .5f, Screen.width * .4f, Screen.height * .07f), lastName, 25);

			//className = GUI.TextField(new Rect(Screen.width * .3f, Screen.height * .6f, Screen.width * .4f, Screen.height * .07f), className, 25);
			if (GUI.Button (new Rect (Screen.width * .3f, Screen.height * .6f, Screen.width * .4f, Screen.height * .07f), classNameToDisplay)) {
				displayClassSelection = true;
			}

			// School use button
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .75f, Screen.width * .2f, Screen.height * .1f), enterText)) {
				// login to Parse
				logIn ();
			}

			// teacher login
			if (GUI.Button (new Rect (Screen.width * .85f, Screen.height * .9f, Screen.width * .15f, Screen.height * .1f), "Teacher Login")) {
				// move to teacher login scene
				Application.LoadLevel (AppManager.TEACHER_LOGIN_SCENE);
			}

			// offline mode
			if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .15f, Screen.height * .1f), "Offline Mode")) {
				Application.LoadLevel (AppManager.MAIN_MENU_SCENE);
			}
		}
		drawClassSelection ();
	}

	private void drawClassSelection () {
		if (displayClassSelection) {
			GUI.Box (new Rect (Screen.width * .2f, Screen.height * .2f, Screen.width * .6f, Screen.height * .7f), "");

			if (GUI.Button (new Rect (Screen.width * .27f, Screen.height * .25f, Screen.width * .1f, Screen.width * .1f), oneText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_1;
				className = AppManager.room1;
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .25f, Screen.width * .1f, Screen.width * .1f), twoText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_2;
				className = AppManager.room2;
			}

			if (GUI.Button (new Rect (Screen.width * .63f, Screen.height * .25f, Screen.width * .1f, Screen.width * .1f), threeText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_3;
				className = AppManager.room3;
			}

			if (GUI.Button (new Rect (Screen.width * .27f, Screen.height * .45f, Screen.width * .1f, Screen.width * .1f), fourText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_4;
				className = AppManager.room4;
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .45f, Screen.width * .1f, Screen.width * .1f), fiveText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_5;
				className = AppManager.room5;
			}

			if (GUI.Button (new Rect (Screen.width * .63f, Screen.height * .45f, Screen.width * .1f, Screen.width * .1f), sixText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_6;
				className = AppManager.room6;
			}

			if (GUI.Button (new Rect (Screen.width * .27f, Screen.height * .65f, Screen.width * .1f, Screen.width * .1f), sevenText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_7;
				className = AppManager.room7;
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .65f, Screen.width * .1f, Screen.width * .1f), eightText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_8;
				className = AppManager.room8;
			}

			if (GUI.Button (new Rect (Screen.width * .63f, Screen.height * .65f, Screen.width * .1f, Screen.width * .1f), nineText)) {
				displayClassSelection = false;
				classNameToDisplay = ROOM_9;
				className = AppManager.room9;
			}
		}
	}

	private void logIn () {
		ParseObject.GetQuery(className).FindAsync().ContinueWith(t => {
			if (t.IsFaulted || t.IsCanceled) {
				// The login failed. Check the error to see why.
				Debug.Log("class does not exist");
			} else {
				// Login was successful.

				// get list of students from Parse class
				IEnumerable<ParseObject> students = t.Result;
				bool classExists = false;
				// if there is something in the collection then class exists
				foreach (var student in students) {
					classExists = true;
					break;
				}
				if (classExists) {
					Debug.Log ("class exist");
					createStudent ();
				} else {
					Debug.Log("class does not exist");
				}
			}
		});
	}

	private void createStudent () {
		ParseObject student = new ParseObject(className);
		student["device"] = deviceName;
		student["firstName"] = firstName;
		student["lastName"] = lastName;
		student["currentTask"] = "None";
		student["helpNeeded"] = "No";
		student["completedTasks"] = "";
		student.SaveAsync().ContinueWith(t => {
			if (t.IsFaulted || t.IsCanceled) {
				// The login failed. Check the error to see why.
				Debug.Log("Login failed");
			} else {
				// Login was successful.
				loggedIn = true;
				AppManager.Instance.currentClass = className;
				AppManager.Instance.student = student;
			}
		});
	}
}
	