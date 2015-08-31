using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
	public float xPos = 0.0f;
	public float yPos = 0.0f;

	private Texture2D zeroText;
	private Texture2D oneText;
	private Texture2D twoText;
	private Texture2D threeText;
	private Texture2D fourText;
	private Texture2D fiveText;
	private Texture2D sixText;
	private Texture2D sevenText;
	private Texture2D eightText;
	private Texture2D nineText;

	// Use this for initialization
	void Start ()
	{
		zeroText = (Texture2D)Resources.Load ("Text/0_text");
		oneText = (Texture2D)Resources.Load ("Text/1_text");
		twoText = (Texture2D)Resources.Load ("Text/2_text");
		threeText = (Texture2D)Resources.Load ("Text/3_text");
		fourText = (Texture2D)Resources.Load ("Text/4_text");
		fiveText = (Texture2D)Resources.Load ("Text/5_text");
		sixText = (Texture2D)Resources.Load ("Text/6_text");
		sevenText = (Texture2D)Resources.Load ("Text/7_text");
		eightText = (Texture2D)Resources.Load ("Text/8_text");
		nineText = (Texture2D)Resources.Load ("Text/9_text");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI ()
	{
		int counter = AppManager.Instance.loadCounter ();
		Texture2D textToDisplay = zeroText;

		if (counter == 0)
			textToDisplay = zeroText;
		else if (counter == 1)
			textToDisplay = oneText;
		else if (counter == 2)
			textToDisplay = twoText;
		else if (counter == 3)
			textToDisplay = threeText;
		else if (counter == 4)
			textToDisplay = fourText;
		else if (counter == 5)
			textToDisplay = fiveText;
		else if (counter == 6)
			textToDisplay = sixText;
		else if (counter == 7)
			textToDisplay = sevenText;
		else if (counter == 8)
			textToDisplay = eightText;
		else if (counter == 9)
			textToDisplay = nineText;

		GUI.Box (new Rect (Screen.width * xPos, Screen.height * yPos, Screen.height * .15f, Screen.height * .15f), textToDisplay);
	}
}

