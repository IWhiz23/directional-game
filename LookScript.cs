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

	private void Start()
	{
		taskData = GameObject.Find ("Data Container").GetComponent<Tasks> ();
	}

	public void OnPointerDown(PointerEventData data)
	{
		pointerStart = data.position;
	}

	public void OnPointerUp(PointerEventData data)
	{
		pointerEnd = data.position;

		pointerDifference = pointerEnd - pointerStart;

		switch(taskData.currentActivity[taskData.activityIncrement])
		{
			case "Up":
			{
				if (pointerDifference.y > 30.0f && pointerDifference.x < 10.0f && pointerDifference.x > -10.0f) 
				{
					Debug.Log ("Looking Up");
					taskData.overrideTimer = true;
					taskData.currentlyPlayingDirectionAnimation = false;
				} 
				else 
				{
					Debug.Log ("Incorrect");
				}

				break;
			}

			case "Down":
			{
				if (pointerDifference.y < -30.0f && pointerDifference.x < 10.0f && pointerDifference.x > -10.0f) 
				{
					Debug.Log ("Looking Down");
					taskData.overrideTimer = true;
					taskData.currentlyPlayingDirectionAnimation = false;
				} 
				else 
				{
					Debug.Log ("Incorrect");
				}

				break;
			} 

			case "Right":
			{
				if (pointerDifference.x > 30.0f && pointerDifference.y < 10.0f && pointerDifference.y > -10.0f) 
				{
					Debug.Log ("Looking to the right");
					taskData.overrideTimer = true;
					taskData.currentlyPlayingDirectionAnimation = false;
				} 
				else 
				{
					Debug.Log ("Incorrect");
				}
					
				break;
			} 

			case "Left":
			{
				if (pointerDifference.x < -30.0f && pointerDifference.y < 10.0f && pointerDifference.y > -10.0f) 
				{
					Debug.Log ("Looking to the left");
					taskData.overrideTimer = true;
					taskData.currentlyPlayingDirectionAnimation = false;
				} 
				else 
				{
					Debug.Log ("Incorrect");
				}

				break;
			}
		}
	}
}
