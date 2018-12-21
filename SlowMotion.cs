using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Plays each direction in slow motion
 * When user looks in the correct direction slow motion stops
 * If time is up and user did not yet select direction, then slow motion stops
 */

public class SlowMotion : MonoBehaviour 
{
	private List<float> startAnimation = new List<float>();
	private List<float> endAnimation = new List<float>();
	private Animator animationClip;
	private Tasks taskManager;

	private void Start()
	{
		animationClip = GetComponent<Animator> ();

		taskManager = GameObject.Find ("Data Container").GetComponent<Tasks> ();

		taskManager.activityIndex.Add (0);
		taskManager.currentEnablerIndex.Add (0);
		startAnimation.Add (0.092f);
		taskManager.currentActivity.Add ("Left");
		endAnimation.Add (0.118f);

		taskManager.activityIndex.Add (1);
		taskManager.currentEnablerIndex.Add (1);
		startAnimation.Add (0.161f);
		taskManager.currentActivity.Add ("Right");
		endAnimation.Add (0.307f);

		taskManager.activityIndex.Add (2);
		taskManager.currentEnablerIndex.Add (2);
		startAnimation.Add (0.307f);
		taskManager.currentActivity.Add ("Down");
		endAnimation.Add (0.383f);

		taskManager.activityIndex.Add (3);
		taskManager.currentEnablerIndex.Add (0);
		startAnimation.Add (0.383f);
		taskManager.currentActivity.Add ("Left");
		endAnimation.Add (0.523f);

		taskManager.activityIndex.Add (4);
		taskManager.currentEnablerIndex.Add (1);
		startAnimation.Add (0.54f);
		taskManager.currentActivity.Add ("Right");
		endAnimation.Add (0.598f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (taskManager.activityIncrement < (taskManager.activityIndex.Count)) 
		{
			if (animationClip.GetCurrentAnimatorStateInfo (0).normalizedTime >= startAnimation [taskManager.activityIncrement] && animationClip.GetCurrentAnimatorStateInfo (0).normalizedTime <= endAnimation [taskManager.activityIncrement]) 
			{
				if (taskManager.overrideTimer) 
				{
					//From the time the user chooses the correct direction
					taskManager.lookActivityParent.GetChild (taskManager.currentEnablerIndex [taskManager.activityIncrement]).gameObject.SetActive (false);
					Time.timeScale = 1.0f;
					taskManager.activityIncrement++;
					taskManager.overrideTimer = false;
				} 
				else 
				{
					//From the time the directional animation starts
					taskManager.lookActivityParent.GetChild (taskManager.currentEnablerIndex [taskManager.activityIncrement]).gameObject.SetActive (true);
					Time.timeScale = 0.1f;
					taskManager.currentlyPlayingDirectionAnimation = true;
				}
			} 
			else 
			{
				//If the user does not select any directions
				Time.timeScale = 1.0f;

				if (taskManager.currentlyPlayingDirectionAnimation) 
				{
					taskManager.lookActivityParent.GetChild (taskManager.currentEnablerIndex [taskManager.activityIncrement]).gameObject.SetActive (false);
					taskManager.activityIncrement++;
					taskManager.currentlyPlayingDirectionAnimation = false;
				}
			}
		}
	}
}
