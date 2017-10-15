using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class SetPlayer : MonoBehaviour {
	void Update() {
		if (transform.position.y + PlayerMovement.playerHeight / 2f > Stage.bottom) {
			PlayerMovement.setPlayer (gameObject);
			GetComponent<Rigidbody> ().useGravity = true;
			enabled = false;
		}
	}
	void OnDestroy() {
		PlayerMovement.removePlayer (gameObject);
		GetComponent<Rigidbody> ().useGravity = false;
	}
}
