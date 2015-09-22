using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

/// <summary>
/// Teacher scene - the teacher console where teachers are shown a list of students and their
/// progress in a classroom.
/// </summary>
public class TeacherScene : MonoBehaviour {
	public Vector2 scrollPosition = Vector2.zero;
	private bool displaySettings = false;
	private IEnumerable<ParseObject> students;
	private int numEntries = 0;

	private Texture2D settingsIcon;

	// update data timer
	private float timer = 0.0f;
	private float timerMax = 3.0f;

	// Use this for initialization
	void Start () {
		AppManager.Instance.teacherMode = true;

		queryStudentList();

		settingsIcon = (Texture2D)Resources.Load ("pics/cog");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timerMax) { // 3 s
			// poll student list every 3 s
			queryStudentList();
			// reset timer
			timer = 0.0f;
		}
	}

	void OnGUI () {
		// settings button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.height * .1f, Screen.height * .1f), settingsIcon)) {
			if (displaySettings) {
				displaySettings = false;
			} else {
				displaySettings = true;
			}
		}

		// scroll view for table
		scrollPosition = GUI.BeginScrollView(new Rect(10, 0, Screen.width * 0.98f, Screen.height * 1f), scrollPosition, new Rect(0, 0, Screen.width * 0.94f, Screen.height * .1f * (numEntries+1)));

		// table headers
		drawStudentEntry(0, "DEVICE", "STUDENT", "CURRENT TASK", "HELP?", "");

		// list students
		if (students != null) {
			int i = 1;
			foreach (var student in students) {
				// This does not require a network access.
				if (student["device"].Equals("TEACHER")) {
					if (i != 1)
						student.DeleteAsync(); // delete useless teacher entry if it's not the only entry in the databaseF
				} else {
					//string device = student["device"] + "";
					string device = student.Get<string>("device");
					string fullName = student["firstName"] + " " + student["lastName"];
					string currentTask = student.Get<string>("currentTask");
					string helpNeeded = student.Get<string>("helpNeeded");
					string completedTasks = student.Get<string>("completedTasks");
					drawStudentEntry(i, device, fullName, currentTask, helpNeeded, completedTasks);
					i++;
					numEntries = i;
					//Debug.Log("Device: " + student["device"]);
				}
			}
		}

		GUI.EndScrollView();

		drawSettings ();
	}

	/// <summary>
	/// Draws a student entry in the list view of students. Each entry is a clickable button.
	/// </summary>
	/// <param name="pos">Position.</param>
	/// <param name="device">Device.</param>
	/// <param name="name">Name.</param>
	/// <param name="task">Task.</param>
	/// <param name="helpNeeded">Help needed.</param>
	/// <param name="completedTasks">Completed tasks.</param>
	private void drawStudentEntry (int pos, string device, string name, string task, string helpNeeded, string completedTasks) {
		if (pos != 0) {
			if (!displaySettings) {
				if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .1f * pos, Screen.width * .9f, Screen.height * .1f), "")) {
					AppManager.Instance.storeCompletedTasks(name, completedTasks);
					Application.LoadLevel(AppManager.TEACHER_COMPLETED_TASKS_SCENE);
				}
			}
		}

		// font style
		GUIStyle style = new GUIStyle ();
		style.fontSize = 26;
		style.normal.textColor = Color.white;

		// overlay labels over the stringless button
		GUI.Label(new Rect (Screen.width * .0f, Screen.height * .1f * pos, Screen.width * .15f, Screen.height * .1f), device, style);
		GUI.Label(new Rect (Screen.width * .2f, Screen.height * .1f * pos, Screen.width * .2f, Screen.height * .1f), name, style);
		GUI.Label(new Rect (Screen.width * .45f, Screen.height * .1f * pos, Screen.width * .3f, Screen.height * .1f), task, style);

		// make "Yes" red color for HELPNEEDED otherwise just white for "no"
		if (helpNeeded.Equals ("Yes")) {
			GUIStyle redStyle = new GUIStyle ();
			redStyle.fontSize = 26;
			redStyle.normal.textColor = Color.red;
			
			GUI.Label (new Rect (Screen.width * .8f, Screen.height * .1f * pos, Screen.width * .2f, Screen.height * .1f), helpNeeded, redStyle);
		} else {
			GUI.Label (new Rect (Screen.width * .8f, Screen.height * .1f * pos, Screen.width * .2f, Screen.height * .1f), helpNeeded, style);
		}
	}

	/// <summary>
	/// Draws the settings dialog for the teacher console - different from the 'SettingsDialog'
	/// </summary>
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

			// end session
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .55f, Screen.width * .2f, Screen.height * .1f), "End Session")) {
				endSession();
			}

			// logout
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .7f, Screen.width * .2f, Screen.height * .1f), "Logout")) {
				Application.LoadLevel(AppManager.START_SCENE);
				AppManager.Instance.teacherMode = false;
			}

		}
	}

	/// <summary>
	/// Queries the student list from Parse.
	/// </summary>
	private void queryStudentList () {
		ParseObject.GetQuery(AppManager.Instance.currentClass).FindAsync().ContinueWith(t => {
			students = t.Result;
		});
	}
	
	/// <summary>
	/// Ends the session and deletes all the objects in the classroom in Parse.
	/// </summary>
	private void endSession () {
		if (students != null) {
			foreach (var student in students) {
				student.DeleteAsync();
			}
		}
	}
}
