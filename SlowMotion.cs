using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour 
{
	private List<float> startAnimation = new List<float>();
	private List<float> endAnimation = new List<float>();
	private Animator animationClip;
	private int increment = 0;
	private bool setIncrementOnce = false;
	[SerializeField]
	private Transform lookActivityParent;
	private Tasks taskManager;
	private int oldIndex = -1;
	[HideInInspector]
	public List<int> currentEnablerIndex = new List<int> ();

	private void Start()
	{
		animationClip = GetComponent<Animator> ();

		taskManager = GameObject.Find ("Data Container").GetComponent<Tasks> ();

		taskManager.activityIndex.Add (0);
		currentEnablerIndex.Add (0);
		startAnimation.Add (0.092f);
		taskManager.nextActivity.Add ("Left");
		endAnimation.Add (0.118f);
		taskManager.activityIndex.Add (1);
		currentEnablerIndex.Add (1);
		startAnimation.Add (0.161f);
		taskManager.nextActivity.Add ("Right");
		endAnimation.Add (0.307f);
		taskManager.activityIndex.Add (2);
		currentEnablerIndex.Add (2);
		startAnimation.Add (0.307f);
		taskManager.nextActivity.Add ("Down");
		endAnimation.Add (0.383f);
		taskManager.activityIndex.Add (3);
		currentEnablerIndex.Add (0);
		startAnimation.Add (0.383f);
		taskManager.nextActivity.Add ("Left");
		endAnimation.Add (0.523f);
		taskManager.activityIndex.Add (4);
		currentEnablerIndex.Add (3);
		startAnimation.Add (0.54f);
		taskManager.nextActivity.Add ("Up");
		endAnimation.Add (0.598f);
		taskManager.activityIndex.Add (5);
		currentEnablerIndex.Add (3);
		startAnimation.Add (0.54f);
		taskManager.nextActivity.Add ("Right");
		endAnimation.Add (0.598f);
		taskManager.activityIndex.Add (6);
		currentEnablerIndex.Add (3);
		startAnimation.Add (0.54f);
		taskManager.nextActivity.Add ("Left");
		endAnimation.Add (0.598f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (!taskManager.overrideSlowMotion && (animationClip.GetCurrentAnimatorStateInfo (0).normalizedTime >= startAnimation[increment] && animationClip.GetCurrentAnimatorStateInfo (0).normalizedTime <= endAnimation[increment]))
		{
			if (currentEnablerIndex.Count > 0) 
			{
				lookActivityParent.GetChild (currentEnablerIndex [0]).gameObject.SetActive (true);
			}

			Time.timeScale = 0.1f;

			if (!setIncrementOnce)
			{
				setIncrementOnce = true;

				oldIndex = currentEnablerIndex [0];

				currentEnablerIndex.RemoveAt (0);

				if (oldIndex >= 0) 
				{
					lookActivityParent.GetChild (oldIndex).gameObject.SetActive (false);
				}
			}
		}
		else
		{
			if (setIncrementOnce)
			{
				if (increment < (startAnimation.Count - 1))
				{
					++increment;
				}
				else
				{
					increment = 0;
				}

				if (currentEnablerIndex.Contains (taskManager.activityIndex[0]))
				{
					currentEnablerIndex.Remove(taskManager.activityIndex[0]);
					taskManager.activityIndex.RemoveAt(0);
				}

				setIncrementOnce = false;
			}
			
			Time.timeScale = 1.0f;

			taskManager.overrideSlowMotion = false;
		}
	}
}
