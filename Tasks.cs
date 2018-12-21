using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour 
{
	[SerializeField]
	public List<Transform> tasks;
	[HideInInspector]
	public bool gameOver = false;
	[HideInInspector]
	public int numberOfTasks = 0;
	[HideInInspector]
	public HashSet<string> completedActivities = new HashSet<string>();
	[HideInInspector]
	public bool overrideSlowMotion = false;
	[HideInInspector]
	public List<string> nextActivity = new List<string> ();
	[HideInInspector]
	public List<int> doneActivity = new List<int> ();
	[HideInInspector]
	public int increment = 0;
	[HideInInspector]
	public List<int> activityIndex = new List<int> ();

	private void Start()
	{
		numberOfTasks = tasks.Count;
	}
}
