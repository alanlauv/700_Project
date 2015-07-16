using UnityEngine;
using System.Collections;

public class Y1Q9Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q9 = "Measurement/Y1/Q9";

	private bool displayHelpButton = false;

	// textures
	private Texture2D redCross;
	private Texture2D bg;
	private Texture2D star;
	private Texture2D starEmpty;

	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private string question = "How many Astronauts tall is the Blue Rocket?";

	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		bg = (Texture2D)Resources.Load("black-bg");
		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q9);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (displayHelpButton == false && timer >= timerMax) {
			//Debug.Log("timerMax reached!");
			displayHelpButton = true;
		}
	}

	void OnGUI () {
		GUIStyle titleStyle = new GUIStyle ("Label");
		titleStyle.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect (Screen.width * .0f, Screen.height * .05f, Screen.width * 1.0f, Screen.height * .1f), question, titleStyle);


	}
}
