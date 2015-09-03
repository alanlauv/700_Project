﻿using UnityEngine;
using System.Collections;

public class Y1Q3Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q3 = "Measurement/Y1/Q3";

	//textures
	private Texture2D hintLine;

	// Use this for initialization
	void Start () {
		hintLine = (Texture2D)Resources.Load("Short2Long");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q3);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI () {
		if (!SettingsDialog.displaySettings) {		
			drawHintLine ();
		}
	}
	
	private void drawHintLine () {
		if (HintButton.displayHint) {
			GUI.DrawTexture(new Rect(Screen.width * .0f, Screen.height * .23f, Screen.width * 1.0f, Screen.height * .55f), hintLine);
		}
	}
}
