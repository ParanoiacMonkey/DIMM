using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public delegate void Callback();

public class SwipeInput : MonoBehaviour {
	static public bool onSwipeBegin;
	static public bool onSwipeEnd;
	static public bool onSwipe;
	static public float swipe;
	static public bool onTap;
	void Update() {
		float xAxis = Input.GetAxisRaw ("Horizontal");
		if (xAxis == 0) {
			if (onSwipe == true)
				onSwipeEnd = true;
			else
				onSwipeEnd = false;
			onSwipe = false;
		} else {
			if (onSwipe == false)
				onSwipeBegin = true;
			else
				onSwipeBegin = false;
			onSwipe = true;
			if (xAxis == 1)
				swipe = Stage.width;
			else
				swipe = -Stage.width;
		}
		if (Input.GetAxisRaw ("Vertical") < 0)
			onTap = true;
		else
			onTap = false;
	}
}
