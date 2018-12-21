using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour 
{
	[HideInInspector]
	public List<string> currentActivity = new List<string> ();
	[HideInInspector]
	public List<int> activityIndex = new List<int> ();
	[HideInInspector]
	public int activityIncrement = 0;
	[HideInInspector]
	public bool overrideTimer = false;
	public Transform lookActivityParent;
	[HideInInspector]
	public List<int> currentEnablerIndex = new List<int> ();
	public bool currentlyPlayingDirectionAnimation = false;
}
