using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReceiver : MonoBehaviour {
	bool oldTouch;
	Vector3 initSwipe;
	static public float horizontalAxis;
	static public Vector3 swipe;
	void Update () {
		horizontalAxis = Input.GetAxisRaw ("Horizontal");
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.position.x > Screen.width / 2f)
				horizontalAxis++;
			else
				horizontalAxis--;
			if (oldTouch) {
				swipe = Camera.main.ScreenToWorldPoint (touch.position) - initSwipe;
			} else {
				initSwipe = Camera.main.ScreenToWorldPoint (touch.position);
			}
			oldTouch = true;
		} else {
			oldTouch = false;
			swipe = Vector3.zero;
		}
	}
}
