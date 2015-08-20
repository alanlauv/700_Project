using UnityEngine;
using System.Collections;

public class TeacherCompletedTasksScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// display completed tasks
		GUI.Label(new Rect (Screen.width * .05f, Screen.height * .05f, Screen.width * .95f, Screen.height * .95f), AppManager.Instance.loadCompletedTasks ());

		// back button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .1f, Screen.height * .1f), "Back")) {
			// move to teacher console
			Application.LoadLevel(AppManager.TEACHER_SCENE);
		}
	}
}
