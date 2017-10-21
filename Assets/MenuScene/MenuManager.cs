using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public float velocity;
	void Start() {
		transform.position = new Vector3 (Stage.x, Stage.y - Stage.height);
	}
	void Update() {
		float newY = transform.position.y + velocity * Time.deltaTime;
		if (newY > Stage.y) {
			transform.position = new Vector3 (Stage.x, Stage.y);
			enabled = false;
		} else
			transform.position = new Vector3 (Stage.x, newY);
	}
}
