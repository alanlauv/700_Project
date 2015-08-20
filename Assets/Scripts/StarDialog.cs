﻿using UnityEngine;
using System.Collections;

public class StarDialog : MonoBehaviour {

	private bool displayStars = false;
	private int numIncorrect = 0;

	private Texture2D star;
	private Texture2D starEmpty;

	private Texture2D excellentText;
	private Texture2D goodText;
	private Texture2D completedText;
	private Texture2D okText;

	// Use this for initialization
	void Start () {
		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");

		excellentText = (Texture2D)Resources.Load ("Text/excellent_text");
		goodText = (Texture2D)Resources.Load ("Text/good_text");
		completedText = (Texture2D)Resources.Load ("Text/completed_text");
		okText = (Texture2D)Resources.Load ("Text/ok_text");
	}
	
	// Update is called once per frame
	void Update () {
		if (AppManager.Instance.loadNumIncorrect () != -1 && AppManager.Instance.loadNumIncorrect () != null) {
			displayStars = true;
			numIncorrect = AppManager.Instance.loadNumIncorrect ();
			AppManager.Instance.resetNumIncorrect();
		}
	}

	void OnGUI () {
		if (displayStars) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .5f), "");
			
			GUI.DrawTexture(new Rect(Screen.width * .35f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			
			if (numIncorrect == 1) {
				GUI.DrawTexture(new Rect (Screen.width * .4f, Screen.height * .25f, Screen.width * .2f, Screen.height * .1f), goodText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else if (numIncorrect >= 2) {
				GUI.DrawTexture(new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .1f), completedText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), starEmpty);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else {
				GUI.DrawTexture(new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .1f), excellentText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			}
			
			// ok
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), okText)) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
		}
	}
}