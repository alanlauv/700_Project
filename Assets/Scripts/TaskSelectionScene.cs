using UnityEngine;
using System.Collections;

public class TaskSelectionScene : MonoBehaviour {
	bool displayTasks = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// topic title
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		titleStyle.normal.textColor = Color.black;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .05f, Screen.width * 1.0f, Screen.height * .1f), "Geometry & Measurement", titleStyle);

		// sound toggle
		AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");

		// year selection
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .2f, Screen.width * .2f, Screen.height * .1f), "Year 1")) {
			displayTasks = true;
		}

		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .3f, Screen.width * .2f, Screen.height * .1f), "Year 2")) {
			displayTasks = true;
		}

		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .4f, Screen.width * .2f, Screen.height * .1f), "Year 3")) {
			displayTasks = true;
		}

		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .5f, Screen.width * .2f, Screen.height * .1f), "Year 4")) {
			displayTasks = true;
		}

		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "Year 5")) {
			displayTasks = true;
		}

		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .7f, Screen.width * .2f, Screen.height * .1f), "Year 6")) {
			displayTasks = true;
		}

		// task selection
		drawTasks ();

		// back button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .2f, Screen.height * .1f), "Back")) {
			Application.LoadLevel(AppManager.MAIN_MENU_SCENE);
		}
	}

	void drawTasks () {
		if (displayTasks) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .2f, Screen.width * .57f, Screen.height * .6f), "");

			// task buttons
			// row1 no1-5
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), "1")) {
				Application.LoadLevel(AppManager.Y1Q1_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), "2")) {
				Application.LoadLevel(AppManager.Y1Q2_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), "3")) {
				Application.LoadLevel(AppManager.Y1Q3_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), "4")) {
				Application.LoadLevel(AppManager.Y1Q4_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), "5")) {
				Application.LoadLevel(AppManager.Y1Q5_SCENE);
			}

			// row2 no6-10
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), "6")) {
				Application.LoadLevel(AppManager.Y1Q6_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), "7")) {
				Application.LoadLevel(AppManager.Y1Q7_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), "8")) {
				Application.LoadLevel(AppManager.Y1Q8_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), "9")) {
				Application.LoadLevel(AppManager.Y1Q9_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), "10")) {
				Application.LoadLevel(AppManager.Y1Q10_SCENE);
			}

			// row3 no10-15
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), "11")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), "12")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), "13")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), "14")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), "15")) {
				
			}

			// row4 no16-20
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), "16")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), "17")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), "18")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), "19")) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), "20")) {
				
			}
		}
	}
}
