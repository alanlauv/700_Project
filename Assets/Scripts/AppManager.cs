using UnityEngine;
using System.Collections;
using Parse;

public class AppManager {
	// list of scenes
	public const string START_SCENE = "StartScene";
	public const string TEACHER_LOGIN_SCENE = "TeacherLoginScene";
	public const string MAIN_MENU_SCENE = "MainMenuScene";
	public const string TASK_SELECTION_SCENE = "TaskSelectionScene";
	public const string START_SESSION_SCENE = "StartSessionScene";
	public const string TEACHER_SCENE = "TeacherScene";
	public const string TEACHER_COMPLETED_TASKS_SCENE = "TeacherCompletedTasksScene";

	public const string Y1Q1_SCENE = "Y1Q1Scene";
	public const string Y1Q2_SCENE = "Y1Q2Scene";
	public const string Y1Q3_SCENE = "Y1Q3Scene";
	public const string Y1Q4_SCENE = "Y1Q4Scene";
	public const string Y1Q5_SCENE = "Y1Q5Scene";
	public const string Y1Q6_SCENE = "Y1Q6Scene";
	public const string Y1Q7_SCENE = "Y1Q7Scene";
	public const string Y1Q8_SCENE = "Y1Q8Scene";
	public const string Y1Q9_SCENE = "Y1Q9Scene";
	public const string Y1Q10_SCENE = "Y1Q10Scene";
	public const string Y1Q11_SCENE = "Y1Q11Scene";
	public const string Y1Q12_SCENE = "Y1Q12Scene";

	public const string Y2Q1_SCENE = "Y2Q1Scene";
	public const string Y2Q2_SCENE = "Y2Q2Scene";
	public const string Y2Q3_SCENE = "Y2Q3Scene";
	public const string Y2Q4_SCENE = "Y2Q4Scene";

	public bool sound = false; //{ get; set; }
	public bool teacherMode = false; //{ get; set; }

	// player/student info
	public ParseObject student = null; // student object reference in Parse
	public string firstName = null;
	public string lastName = null;

	public string currentClass = null;
	public string currentTask = null;

	// Singleton
	private static readonly object padlock = new object();
	private static AppManager instance;
	private AppManager() {}
	public static AppManager Instance
	{
		get 
		{
			lock (padlock) // thread-safety
			{
				if (instance == null)
				{
					instance = new AppManager();
				}
				return instance;
			}
		}
	}

	public void resetTaskSceneData() {
		HintButton.displayHintButton = false;
		HintButton.displayHint = false;
		HintButton.flashHintButton = false;
		HintButton.hintUsed = false;

		StarDialog.displayStars = false;
		StarDialog.numIncorrect = 0;
	}

	public void setCurrentTask(string task) {
		if (student != null) {
			student["helpNeeded"] = "No"; // default to no helpNeeded
			student["currentTask"] = task;
			student.SaveAsync().ContinueWith(t => {
				if (t.IsFaulted || t.IsCanceled) {
					Debug.Log("Set currentTask failed");
				} else {
					// successful.
				}
			});
		}
	}

	public void setHelpNeeded(bool helpNeeded) {
		if (student != null) {
			if (helpNeeded) {
				student["helpNeeded"] = "Yes";
			} else {
				student["helpNeeded"] = "No";
			}
			student.SaveAsync().ContinueWith(t => {
				if (t.IsFaulted || t.IsCanceled) {
					Debug.Log("Set helpNeeded failed");
				} else {
					// successful.
				}
			});
		}
	}

	// append to Parse DB the completed task
	public void addCompletedTask(string task, int numIncorrect, bool hintUsed) {
		if (student != null) {
			int numStars = 1;
			if (numIncorrect == 0)
				numStars = 3;
			else if (numIncorrect == 1)
				numStars = 2;

			string append = task + "; Stars: " + numStars + "; Incorrect attempts: " + numIncorrect + "; Hint used?: " + hintUsed;
			if (student["completedTasks"] != "") {
				student["completedTasks"] += "\n" + append;
			} else {
				student["completedTasks"] += append;
			}
		}
	}

	// use this method for exiting a task scene instead of Application.LoadLevel
	public void exitTask(string scene) {
		Application.LoadLevel(scene);
		setCurrentTask("None");
	}

	// passing numIncorrect [-1 = task not yet completed, else if >=0 then completed]
	public void storeNumIncorrect(int numIncorrect) {
		PlayerPrefs.SetInt ("NUM_INCORRECT", numIncorrect);
	}

	public int loadNumIncorrect() {
		if (PlayerPrefs.GetInt ("NUM_INCORRECT") == null) {
			PlayerPrefs.SetInt ("NUM_INCORRECT", -1);
		}
		return PlayerPrefs.GetInt ("NUM_INCORRECT");
	}

	public void resetNumIncorrect () {
		PlayerPrefs.SetInt ("NUM_INCORRECT", -1);
	}

	// store and load number of slots for incrementing q9-12
	public void incrementCounter() {
		int counter = loadCounter ();
		counter++;
		PlayerPrefs.SetInt ("COUNTER", counter);
	}

	public int loadCounter() {
		if (PlayerPrefs.GetInt ("COUNTER") == null) {
			PlayerPrefs.SetInt ("COUNTER", 0);
		}
		return PlayerPrefs.GetInt ("COUNTER");
	}

	public void resetCounter () {
		PlayerPrefs.SetInt ("COUNTER", 0);
	}

	// passing student completedTasks of a student in Teacher Scene
	public void storeCompletedTasks(string studentName, string tasks) {
		string s = studentName + "\n" + tasks;
		if (tasks.Equals(""))
			s += "Has not yet completed any tasks";
		PlayerPrefs.SetString ("COMPLETED_TASKS", s);	
	}

	public string loadCompletedTasks() {
		return PlayerPrefs.GetString ("COMPLETED_TASKS");
	}
}
