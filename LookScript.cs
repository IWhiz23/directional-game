using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LookScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private Vector3 pointerStart;
	private Vector3 pointerEnd;
	private Vector3 pointerDifference;
	private Tasks taskData;
	[SerializeField]
	private bool upDirection = false;
	[SerializeField]
	private bool downDirection = false;
	[SerializeField]
	private bool rightDirection = false;
	[SerializeField]
	private bool leftDirection = false;

	private void Start()
	{
		taskData = GameObject.Find ("Data Container").GetComponent<Tasks> ();
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (!taskData.gameOver)
		{
			pointerStart = data.position;
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		if (!taskData.gameOver && !taskData.completedActivities.Contains(data.pointerEnter.name)) 
		{
			pointerEnd = data.position;

			pointerDifference = pointerEnd - pointerStart;

			switch(taskData.nextActivity[0])
			{
				case "Up":
				{
					if (pointerDifference.y > 30.0f && pointerDifference.x < 10.0f && pointerDifference.x > -10.0f) 
					{
						Debug.Log ("Looking Up");
						taskData.completedActivities.Add (data.pointerEnter.name);
						taskData.numberOfTasks--;
						taskData.nextActivity.RemoveAt (0);
						Time.timeScale = 1.0f;
						taskData.overrideSlowMotion = true;
						taskData.doneActivity.Add (taskData.increment);
						taskData.activityIndex.Remove (0);
						taskData.increment++;
					} 
					else 
					{
						Debug.Log ("That was the incorrect direction");

						Debug.Log (pointerDifference.x + " " + pointerDifference.y);
					}

					break;
				} 
				case "Down":
				{
					if (pointerDifference.y < -30.0f && pointerDifference.x < 10.0f && pointerDifference.x > -10.0f) 
					{
						Debug.Log ("Looking Down");
						taskData.completedActivities.Add (data.pointerEnter.name);
						taskData.numberOfTasks--;
						taskData.nextActivity.RemoveAt (0);
						Time.timeScale = 1.0f;
						taskData.overrideSlowMotion = true;
						taskData.doneActivity.Add (taskData.increment);
						taskData.activityIndex.Remove (0);
						taskData.increment++;
					} 
					else 
					{
						Debug.Log ("That was the incorrect direction");

						Debug.Log (pointerDifference.x + " " + pointerDifference.y);
					}

					break;
				} 
				case "Right":
				{
					if (pointerDifference.x > 30.0f && pointerDifference.y < 10.0f && pointerDifference.y > -10.0f) 
					{
						Debug.Log ("Looking to the right");
						taskData.completedActivities.Add (data.pointerEnter.name);
						taskData.numberOfTasks--;
						taskData.nextActivity.RemoveAt (0);
						Time.timeScale = 1.0f;
						taskData.overrideSlowMotion = true;
						taskData.doneActivity.Add (taskData.increment);
						taskData.activityIndex.Remove (0);
						taskData.increment++;
					} 
					else 
					{
						Debug.Log ("That was the incorrect direction");

						Debug.Log (pointerDifference.x + " " + pointerDifference.y);
					}

					break;
				} 
				case "Left":
				{
					if (pointerDifference.x < -30.0f && pointerDifference.y < 10.0f && pointerDifference.y > -10.0f) 
					{
						Debug.Log ("Looking to the left");
						taskData.completedActivities.Add (data.pointerEnter.name);
						taskData.numberOfTasks--;
						taskData.nextActivity.RemoveAt (0);
						Time.timeScale = 1.0f;
						taskData.overrideSlowMotion = true;
						taskData.doneActivity.Add (taskData.increment);
						taskData.activityIndex.Remove (0);
						taskData.increment++;
					} 
					else 
					{
						Debug.Log ("That was the incorrect direction");

						Debug.Log (pointerDifference.x + " " + pointerDifference.y);
					}

					break;
				}
			}

			if (taskData.nextActivity.Count <= 0) 
			{
				taskData.gameOver = true;
			}
		}
	}
}
