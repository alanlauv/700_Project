using UnityEngine;
using System.Collections;

public class TaskSelectionScene : MonoBehaviour {
	bool displayTasks = false;

	private Texture2D year1Text;

	private Texture2D oneText;
	private Texture2D twoText;
	private Texture2D threeText;
	private Texture2D fourText;
	private Texture2D fiveText;
	private Texture2D sixText;
	private Texture2D sevenText;
	private Texture2D eightText;
	private Texture2D nineText;
	private Texture2D tenText;
	private Texture2D elevenText;
	private Texture2D twelveText;
	private Texture2D thirteenText;
	private Texture2D fourteenText;
	private Texture2D fifteenText;
	private Texture2D sixteenText;
	private Texture2D seventeenText;
	private Texture2D eighteenText;
	private Texture2D nineteenText;
	private Texture2D twentyText;

	// Use this for initialization
	void Start () {
		year1Text = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/year1_text");

		oneText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-1");
		twoText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-2");
		threeText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-3");
		fourText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-4");
		fiveText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-5");
		sixText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-6");
		sevenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-7");
		eightText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-8");
		nineText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-9");
		tenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-10");
		elevenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-11");
		twelveText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-12");
		thirteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-13");
		fourteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-14");
		fifteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-15");
		sixteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-16");
		seventeenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-17");
		eighteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-18");
		nineteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-19");
		twentyText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-20");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		// sound toggle
		AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");

		// year selection
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .2f, Screen.width * .2f, Screen.height * .1f), year1Text)) {
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
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), oneText)) {
				Application.LoadLevel(AppManager.Y1Q1_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), twoText)) {
				Application.LoadLevel(AppManager.Y1Q2_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), threeText)) {
				Application.LoadLevel(AppManager.Y1Q3_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), fourText)) {
				Application.LoadLevel(AppManager.Y1Q4_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), fiveText)) {
				Application.LoadLevel(AppManager.Y1Q5_SCENE);
			}

			// row2 no6-10
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), sixText)) {
				Application.LoadLevel(AppManager.Y1Q6_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), sevenText)) {
				Application.LoadLevel(AppManager.Y1Q7_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), eightText)) {
				Application.LoadLevel(AppManager.Y1Q8_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), nineText)) {
				Application.LoadLevel(AppManager.Y1Q9_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), tenText)) {
				Application.LoadLevel(AppManager.Y1Q10_SCENE);
			}

			// row3 no10-15
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), elevenText)) {
				Application.LoadLevel(AppManager.Y1Q11_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), twelveText)) {
				Application.LoadLevel(AppManager.Y1Q12_SCENE);
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), thirteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), fourteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), fifteenText)) {
				
			}

			// row4 no16-20
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), sixteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), seventeenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), eighteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), nineteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), twentyText)) {
				
			}
		}
	}
}
