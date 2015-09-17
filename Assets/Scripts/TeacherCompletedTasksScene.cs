using UnityEngine;
using System.Collections;

public class TeacherCompletedTasksScene : MonoBehaviour {

	public Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		scrollPosition = GUI.BeginScrollView(new Rect(10, 0, Screen.width * 0.98f, Screen.height * 1f), scrollPosition, new Rect(0, 0, Screen.width * 0.94f, Screen.height * .1f * 500));

		// font size
		GUIStyle style = new GUIStyle ();
		style.fontSize = 26;
		style.normal.textColor = Color.white;

		// display completed tasks
		GUI.Label(new Rect (Screen.width * .05f, Screen.height * .05f, Screen.width * .95f, Screen.height * .95f), AppManager.Instance.loadCompletedTasks (), style);

		// back button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .1f, Screen.height * .1f), "Back")) {
			// move to teacher console
			Application.LoadLevel(AppManager.TEACHER_SCENE);
		}

		GUI.EndScrollView();
	}
}
