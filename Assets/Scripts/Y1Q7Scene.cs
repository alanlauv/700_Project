using UnityEngine;
using System.Collections;

public class Y1Q7Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q7 = "Measurement/Y1/Q7";
	
	//textures
	private Texture2D hintLine;

	// Use this for initialization
	void Start () {
		hintLine = (Texture2D)Resources.Load("y1q7_hintline");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q7);
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
			GUI.DrawTexture(new Rect(Screen.width * .17f, Screen.height * .23f, Screen.width * 0.45f, Screen.height * .5f), hintLine);
		}
	}
}
