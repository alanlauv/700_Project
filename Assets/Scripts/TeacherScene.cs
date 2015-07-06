using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class TeacherScene : MonoBehaviour {
	public Vector2 scrollPosition = Vector2.zero;
	private bool displaySettings = false;
	private IEnumerable<ParseObject> students;

	// update data timer
	private float timer = 0.0f;
	private float timerMax = 3.0f;

	// Use this for initialization
	void Start () {
		queryStudentList();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timerMax) { // 3 s
			//Debug.Log("timerMax reached!");
			queryStudentList();
			// reset timer
			timer = 0.0f;
		}
	}

	void OnGUI () {
		// settings button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.height * .1f, Screen.height * .1f), "S")) {
			if (displaySettings) {
				displaySettings = false;
			} else {
				displaySettings = true;
			}
		}

		// scroll view for table
		scrollPosition = GUI.BeginScrollView(new Rect(10, 0, Screen.width * 0.98f, Screen.height * 1f), scrollPosition, new Rect(0, 0, Screen.width * 0.94f, 1000));

		// table headers
		drawStudentEntry(0, "DEVICE", "STUDENT", "CURRENT TASK", "HELP?");

		// list students
		if (students != null) {
			int i = 1;
			foreach (var student in students) {
				// This does not require a network access.
				if (!student["firstName"].Equals("")) { // firstName exists so not a blank entry row
					//string device = student["device"] + "";
					string device = student.Get<string>("device");
					string fullName = student["firstName"] + " " + student["lastName"];
					string currentTask = student.Get<string>("currentTask");
					string helpNeeded = student.Get<string>("helpNeeded");;
					drawStudentEntry(i, device, fullName, currentTask, helpNeeded);
					i++;
					//Debug.Log("Device: " + student["device"]);
				}
			}
		}

		GUI.EndScrollView();

		drawSettings ();
	}

	private void drawStudentEntry (int pos, string device, string name, string task, string helpNeeded) {
		GUI.Label(new Rect (Screen.width * .0f, Screen.height * .1f * pos, Screen.width * .15f, Screen.height * .1f), device);
		GUI.Label(new Rect (Screen.width * .2f, Screen.height * .1f * pos, Screen.width * .2f, Screen.height * .1f), name);
		GUI.Label(new Rect (Screen.width * .45f, Screen.height * .1f * pos, Screen.width * .3f, Screen.height * .1f), task);
		GUI.Label(new Rect (Screen.width * .8f, Screen.height * .1f * pos, Screen.width * .2f, Screen.height * .1f), helpNeeded);
	}

	private void drawSettings () {
		if (displaySettings) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .2f, Screen.width * .4f, Screen.height * .65f), "");

			// main menu
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .25f, Screen.width * .2f, Screen.height * .1f), "Main Menu")) {
				Application.LoadLevel(AppManager.MAIN_MENU_SCENE);
			}

			// new session
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .4f, Screen.width * .2f, Screen.height * .1f), "New Session")) {
				Application.LoadLevel(AppManager.START_SESSION_SCENE);
			}

			// TODO end session
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .55f, Screen.width * .2f, Screen.height * .1f), "End Session")) {
				endSession();
			}

			// TODO logout
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .7f, Screen.width * .2f, Screen.height * .1f), "Logout")) {
				Application.LoadLevel(AppManager.START_SCENE);
			}

		}
	}

	private void queryStudentList () {
		ParseObject.GetQuery(AppManager.Instance.currentClass).FindAsync().ContinueWith(t => {
			students = t.Result;
		});
	}

	// delete all the objects in the classroom
	private void endSession () {
		if (students != null) {
			foreach (var student in students) {
				student.DeleteAsync();
			}
		}
	}
}
