using UnityEngine;
using System.Collections;

/// <summary>
/// Task selection scene for year 1 to 6.
/// </summary>
public class TaskSelectionScene : MonoBehaviour {
	bool displayYear1Tasks = false;
	bool displayYear2Tasks = false;
	bool displayYear3Tasks = false;
	bool displayYear4Tasks = false;
	bool displayYear5Tasks = false;
	bool displayYear6Tasks = false;

	private Texture2D backText;
	private Texture2D comingSoonText;

	private Texture2D year1Text;
	private Texture2D year2Text;
	private Texture2D year3Text;
	private Texture2D year4Text;
	private Texture2D year5Text;
	private Texture2D year6Text;

	// greyed out task numbers to indicate that a task is not implemented
	private Texture2D greyOneText;
	private Texture2D greyTwoText;
	private Texture2D greyThreeText;
	private Texture2D greyFourText;
	private Texture2D greyFiveText;
	private Texture2D greySixText;
	private Texture2D greySevenText;
	private Texture2D greyEightText;
	private Texture2D greyNineText;
	private Texture2D greyTenText;
	private Texture2D greyElevenText;
	private Texture2D greyTwelveText;
	private Texture2D greyThirteenText;
	private Texture2D greyFourteenText;
	private Texture2D greyFifteenText;
	private Texture2D greySixteenText;
	private Texture2D greySeventeenText;
	private Texture2D greyEighteenText;
	private Texture2D greyNineteenText;
	private Texture2D greyTwentyText;

	// year 1 task numbers 1 to 20
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

	// year 2 task numbers 1 to 4
	private Texture2D year2OneText;
	private Texture2D year2TwoText;
	private Texture2D year2ThreeText;
	private Texture2D year2FourText;

	// Use this for initialization
	void Start () {
		backText = (Texture2D)Resources.Load ("Text/back_text");
		comingSoonText = (Texture2D)Resources.Load ("Text/coming_soon_text");

		year1Text = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/year1_text");
		year2Text = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/year2_text");
		year3Text = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/year3_text");
		year4Text = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/year4_text");
		year5Text = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/year5_text");
		year6Text = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/year6_text");

		greyOneText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/1-grey");
		greyTwoText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/2-grey");
		greyThreeText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/3-grey");
		greyFourText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/4-grey");
		greyFiveText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/5-grey");
		greySixText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/6-grey");
		greySevenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/7-grey");
		greyEightText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/8-grey");
		greyNineText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/9-grey");
		greyTenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/10-grey");
		greyElevenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/11-grey");
		greyTwelveText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/12-grey");
		greyThirteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/13-grey");
		greyFourteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/14-grey");
		greyFifteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/15-grey");
		greySixteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/16-grey");
		greySeventeenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/17-grey");
		greyEighteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/18-grey");
		greyNineteenText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/19-grey");
		greyTwentyText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/20-grey");

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

		year2OneText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/2-1");
		year2TwoText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/2-2");
		year2ThreeText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/2-3");
		year2FourText = (Texture2D)Resources.Load ("Text/Task_Selection_Scene/2-4");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// sound toggle
		//AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");

		// year 1
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .2f, Screen.width * .2f, Screen.height * .1f), year1Text)) {
			displayYear1Tasks = true;

			displayYear2Tasks = false;
			displayYear3Tasks = false;
			displayYear4Tasks = false;
			displayYear5Tasks = false;
			displayYear6Tasks = false;
		}

		// year 2
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .3f, Screen.width * .2f, Screen.height * .1f), year2Text)) {
			displayYear2Tasks = true;

			displayYear1Tasks = false;
			displayYear3Tasks = false;
			displayYear4Tasks = false;
			displayYear5Tasks = false;
			displayYear6Tasks = false;
		}

		// year 3
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .4f, Screen.width * .2f, Screen.height * .1f), year3Text)) {
			displayYear3Tasks = true;

			displayYear1Tasks = false;
			displayYear2Tasks = false;
			displayYear4Tasks = false;
			displayYear5Tasks = false;
			displayYear6Tasks = false;
		}

		// year 4
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .5f, Screen.width * .2f, Screen.height * .1f), year4Text)) {
			displayYear4Tasks = true;

			displayYear1Tasks = false;
			displayYear2Tasks = false;
			displayYear3Tasks = false;
			displayYear5Tasks = false;
			displayYear6Tasks = false;
		}

		// year 5
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), year5Text)) {
			displayYear5Tasks = true;

			displayYear1Tasks = false;
			displayYear2Tasks = false;
			displayYear3Tasks = false;
			displayYear4Tasks = false;
			displayYear6Tasks = false;
		}

		// year 6
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .7f, Screen.width * .2f, Screen.height * .1f), year6Text)) {
			displayYear6Tasks = true;

			displayYear1Tasks = false;
			displayYear2Tasks = false;
			displayYear3Tasks = false;
			displayYear4Tasks = false;
			displayYear5Tasks = false;
		}

		// task selection
		drawYear1Tasks ();
		drawYear2Tasks ();
		drawYear3Tasks ();
		drawYear4Tasks ();
		drawYear5Tasks ();
		drawYear6Tasks ();

		// back button
		if (GUI.Button (new Rect (Screen.width * .0f, Screen.height * .9f, Screen.width * .2f, Screen.height * .1f), backText)) {
			Application.LoadLevel(AppManager.MAIN_MENU_SCENE);
		}
	}

	/// <summary>
	/// Draws the year1 tasks dialog selection.
	/// </summary>
	void drawYear1Tasks () {
		if (displayYear1Tasks) {
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

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyThirteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyFourteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyFifteenText)) {
				
			}

			// row4 no16-20
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greySixteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greySeventeenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greyEighteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greyNineteenText)) {
				
			}

			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greyTwentyText)) {
				
			}
		}
	}

	/// <summary>
	/// Draws the year2 tasks dialog selection.
	/// </summary>
	void drawYear2Tasks () {
		if (displayYear2Tasks) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .2f, Screen.width * .57f, Screen.height * .6f), "");
			
			// task buttons
			// row1 no1-5
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), year2OneText)) {
				Application.LoadLevel(AppManager.Y2Q1_SCENE);
			}
			
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), year2TwoText)) {
				Application.LoadLevel(AppManager.Y2Q2_SCENE);
			}
			
			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), year2ThreeText)) {
				Application.LoadLevel(AppManager.Y2Q3_SCENE);
			}
			
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), year2FourText)) {
				Application.LoadLevel(AppManager.Y2Q4_SCENE);
			}
			
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .22f, Screen.height * .1f, Screen.height * .1f), greyFiveText)) {

			}
			
			// row2 no6-10
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), greySixText)) {

			}
			
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), greySevenText)) {

			}
			
			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), greyEightText)) {

			}
			
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), greyNineText)) {

			}
			
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .37f, Screen.height * .1f, Screen.height * .1f), greyTenText)) {

			}
			
			// row3 no10-15
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyElevenText)) {

			}
			
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyTwelveText)) {

			}
			
			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyThirteenText)) {
				
			}
			
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyFourteenText)) {
				
			}
			
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .52f, Screen.height * .1f, Screen.height * .1f), greyFifteenText)) {
				
			}
			
			// row4 no16-20
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greySixteenText)) {
				
			}
			
			if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greySeventeenText)) {
				
			}
			
			if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greyEighteenText)) {
				
			}
			
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greyNineteenText)) {
				
			}
			
			if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .67f, Screen.height * .1f, Screen.height * .1f), greyTwentyText)) {
				
			}
		}
	}

	/// <summary>
	/// Draws the year3 tasks - coming soon.
	/// </summary>
	void drawYear3Tasks () {
		if (displayYear3Tasks) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .2f, Screen.width * .57f, Screen.height * .6f), "");

			GUI.DrawTexture (new Rect (Screen.width * .33f, Screen.height * .4f, Screen.width * .5f, Screen.height * .2f), comingSoonText);
		}
	}

	/// <summary>
	/// Draws the year4 tasks - coming soon.
	/// </summary>
	void drawYear4Tasks () {
		if (displayYear4Tasks) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .2f, Screen.width * .57f, Screen.height * .6f), "");
			
			GUI.DrawTexture (new Rect (Screen.width * .33f, Screen.height * .4f, Screen.width * .5f, Screen.height * .2f), comingSoonText);
		}
	}

	/// <summary>
	/// Draws the year5 tasks - coming soon.
	/// </summary>
	void drawYear5Tasks () {
		if (displayYear5Tasks) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .2f, Screen.width * .57f, Screen.height * .6f), "");
			
			GUI.DrawTexture (new Rect (Screen.width * .33f, Screen.height * .4f, Screen.width * .5f, Screen.height * .2f), comingSoonText);
		}
	}

	/// <summary>
	/// Draws the year6 tasks - coming soon.
	/// </summary>
	void drawYear6Tasks () {
		if (displayYear6Tasks) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .2f, Screen.width * .57f, Screen.height * .6f), "");
			
			GUI.DrawTexture (new Rect (Screen.width * .33f, Screen.height * .4f, Screen.width * .5f, Screen.height * .2f), comingSoonText);
		}
	}
}
