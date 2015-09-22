using UnityEngine;
using System.Collections;
using Parse;

/// <summary>
/// App manager. Singleton Class. Contains constant strings of scene names and room names.
/// Primarily deals with uploading of data into Parse and the student object of Parse is contained
/// in this class.
/// </summary>
public class AppManager {
	// list of room names
	public const string room1 = "room1";
	public const string room2 = "room2";
	public const string room3 = "room3";
	public const string room4 = "room4";
	public const string room5 = "room5";
	public const string room6 = "room6";
	public const string room7 = "room7";
	public const string room8 = "room8";
	public const string room9 = "room9";

	// list of scenes, used to LoadLevel()
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


	public const string YEAR = "Y";
	public const string QUES = "Q";
	public const string SCENE = "SCENE";

	// shared teacher password
	public const string TEACHER_PASSWORD = "Teacher";

	// whether sound is on/off
	public bool sound = false;

	// if application is in teachermode or being used by the teacher
	public bool teacherMode = false;

	// player/student info
	public ParseObject student = null; // student object reference in Parse
	public string firstName = null;
	public string lastName = null;

	public string currentClass = null;
	public string currentTask = null;

	// [0] stores int year | [1] stores int task number
	public int[] currentTaskYearAndNumber = new int[2];

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

	/// <summary>
	/// Sets the current task into Parse, and helpNeeded is set back to "No".
	/// </summary>
	/// <param name="task">Task.</param>
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

	/// <summary>
	/// Sets helpNeeded to "Yes" if true, else "No" into Parse.
	/// </summary>
	/// <param name="helpNeeded">If set to <c>true</c> help needed.</param>
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

	/// <summary>
	/// Sets the current task year and task number.
	/// </summary>
	/// <param name="year">Year.</param>
	/// <param name="number">Number.</param>
	public void setCurrentTaskYearAndNumber(int year, int number) {
		currentTaskYearAndNumber [0] = year;
		currentTaskYearAndNumber [1] = number;
	}
	
	/// <summary>
	/// Adds the completed task to Parse to the string of completed task.
	/// </summary>
	/// <param name="task">Task.</param>
	/// <param name="numIncorrect">Number incorrect.</param>
	/// <param name="hintUsed">If set to <c>true</c> hint used.</param>
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

	/// <summary>
	/// Loads the scene of the next task of the current task.
	/// </summary>
	public void nextTask() {
		currentTaskYearAndNumber [1]++;
		string nextTaskName = YEAR + currentTaskYearAndNumber [0] + QUES + currentTaskYearAndNumber [1] + SCENE;
		Application.LoadLevel (nextTaskName);
	}

	/// <summary>
	/// Exits the task.
	/// Use this method for exiting a task scene instead of Application.LoadLevel().
	/// </summary>
	/// <param name="scene">Scene.</param>
	public void exitTask(string scene) {
		Application.LoadLevel(scene);
		setCurrentTask("None");
	}
	
	/// <summary>
	/// Stores the completed tasks string into PlayerPrefs.
	/// Used for passing student completedTasks of a student in Teacher Scene.
	/// </summary>
	/// <param name="studentName">Student name.</param>
	/// <param name="tasks">Tasks.</param>
	public void storeCompletedTasks(string studentName, string tasks) {
		string s = studentName + "\nList of Completed Tasks\n\n" + tasks;
		if (tasks.Equals(""))
			s += "Has not yet completed any tasks";
		PlayerPrefs.SetString ("COMPLETED_TASKS", s);	
	}

	/// <summary>
	/// Gets the completed tasks string from PlayerPrefs.
	/// </summary>
	/// <returns>The completed tasks.</returns>
	public string loadCompletedTasks() {
		return PlayerPrefs.GetString ("COMPLETED_TASKS");
	}
}
