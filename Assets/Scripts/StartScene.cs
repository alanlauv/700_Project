using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class StartScene : MonoBehaviour {
	string firstName = "First name";
	string lastName = "Last name";
	string className = "Classroom";
	string deviceName = null;

	bool loggedIn = false;

	// Use this for initialization
	void Start () {
		deviceName = SystemInfo.deviceName;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
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
		// set up scaling
		//float rx = Screen.width / 1600;
		//float ry = Screen.height / 1000;
		//GUI.matrix = Matrix4x4.TRS (Vector3(0, 0, 0), Quaternion.identity, Vector3 (rx, ry, 1)); 

		// school label
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		titleStyle.fontSize = 23;
		titleStyle.normal.textColor = Color.white;
		GUI.Box (new Rect (Screen.width * .25f, Screen.height * .2f, Screen.width * .5f, Screen.height * .7f), "");
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .25f, Screen.width * 1.0f, Screen.height * .2f), "What is your name?", titleStyle);

		// name input
		firstName = GUI.TextField(new Rect(Screen.width * .3f, Screen.height * .4f, Screen.width * .4f, Screen.height * .07f), firstName, 25);
		lastName = GUI.TextField(new Rect(Screen.width * .3f, Screen.height * .5f, Screen.width * .4f, Screen.height * .07f), lastName, 25);
		className = GUI.TextField(new Rect(Screen.width * .3f, Screen.height * .6f, Screen.width * .4f, Screen.height * .07f), className, 25);

		// School use button
		if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .7f, Screen.width * .2f, Screen.height * .1f), "Enter")) {
			// sign into Parse
			//signUp();
			newLogIn();
		}

		// teacher login
		if (GUI.Button (new Rect (Screen.width * .8f, Screen.height * .9f, Screen.width * .2f, Screen.height * .1f), "Teacher Login")) {
			// move to teacher login scene
			Application.LoadLevel(AppManager.TEACHER_LOGIN_SCENE);
		}
	}

	// deprecated - can remove
	private void signUp () {
		var user = new ParseUser() {
			Username = firstName + " " + lastName,
			Password = "password"
		};
		user.SignUpAsync().ContinueWith(t => {
			if (t.IsFaulted || t.IsCanceled) {
				// The sign up failed. Check the error to see why.
				Debug.Log("sign up failed");
				logIn();
			} else {
				// sign up was successful.
				loggedIn = true;
			}
		});
	}

	// depreciated - can remove
	private void logIn () {
		ParseUser.LogInAsync(firstName + " " + lastName, "password").ContinueWith(t => {
			if (t.IsFaulted || t.IsCanceled) {
				// The login failed. Check the error to see why.
				Debug.Log("Login failed");
			} else {
				// Login was successful.
				loggedIn = true;
			}
		});
	}

	private void newLogIn () {
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
	