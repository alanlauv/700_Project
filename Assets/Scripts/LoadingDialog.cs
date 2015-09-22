using UnityEngine;
using System.Collections;

/// <summary>
/// Loading dialog used for logging in children and when teachers start a session.
/// </summary>
public class LoadingDialog : MonoBehaviour {

	public static bool showLoading = false;

	// Use this for initialization
	void Start () {
		showLoading = false;
	}
	
	// Update is called once per frame
	void Update () {
		// show loading dialog
		if (showLoading) {
			GameObject loading = GameObject.Find ("Loading");
			loading.GetComponent<Renderer> ().enabled = true;
		} else { // hide loading dialog when done loading
			GameObject loading = GameObject.Find ("Loading");
			loading.GetComponent<Renderer> ().enabled = false;
		}
	}

	void OnGUI () {
		if (showLoading) {
			// font style
			GUIStyle style = new GUIStyle ();
			style.fontSize = 26;
			style.alignment = TextAnchor.UpperCenter;
			style.normal.textColor = Color.white;

			GUI.Box (new Rect (Screen.width * .0f, Screen.height * .0f, Screen.width * 1f, Screen.height * 1f), "");
			GUI.Label (new Rect (Screen.width * .0f, Screen.height * .7f, Screen.width * 1f, Screen.height * 0.2f), "Loading...", style);
		}
	}
}
