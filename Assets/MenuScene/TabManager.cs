using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour {
	const string ppname = "TabActual";
	public float velocity;
	public GameObject title;
	float tabsn;
	float tabActual;
	float swipeBegin;
	void Start () {
		tabsn = 0;
		foreach (GameObject tab in TabList.GetTabs()) {
			GameObject child = Instantiate (tab, new Vector3 (transform.position.x, transform.position.y + tabsn * Stage.width), Quaternion.identity) as GameObject;
			child.transform.parent = transform;
			tabsn++;
		}
		tabActual = PlayerPrefs.GetFloat (ppname, 0);
	}
	void Update () {
		if (SwipeInput.onSwipeBegin) {
			swipeBegin = transform.position.x;
		} else if (SwipeInput.onSwipe) {
			transform.position = new Vector3 (swipeBegin + SwipeInput.swipe, transform.position.y);
		} else if (SwipeInput.onSwipeEnd) {
			tabActual = -Mathf.Clamp ((int)Mathf.Round (transform.position.x / Stage.height), 0, (int)tabsn - 1);
		} else if (SwipeInput.onTap && transform.position.x == Stage.x - tabActual * Stage.width && transform.position.y == Stage.y) {
			TabStart ();
		} else {
			float target = Stage.x - tabActual * Stage.width;
			float dist = target - transform.position.x;
			float delta = velocity * Time.deltaTime;
			if (Mathf.Abs (dist) < delta)
				transform.position = new Vector3 (target, transform.position.y);
			else
				transform.position = new Vector3 (transform.position.x + Mathf.Sign (dist) * delta, transform.position.y);
		}
	}
	void TabStart() {
		PlayerPrefs.SetFloat (ppname, tabActual);
		Transform tab = transform.GetChild ((int) tabActual);
		title.transform.parent = tab;
		tab.parent = null;
		tab.GetComponent<Tab> ().TabStart ();
	}
}
