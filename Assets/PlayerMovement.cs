using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float horizontalVelocity;
	static GameObject player;
	static public float playerHeight;
	static public float playerWidth;

	void Update() {
		if (player != null) {
			Rigidbody rb = player.GetComponent<Rigidbody> ();
			float v0 = rb.velocity.x;
			float v1 = horizontalVelocity * InputReceiver.horizontalAxis;
			float m = rb.mass;
			rb.AddForce (Vector3.right * m * (v1 - v0) / Time.deltaTime);
		}
	}

	static public void setPlayer(GameObject newPlayer) {
		player = newPlayer;
		Vector3 playerSize = player.GetComponent<Renderer> ().bounds.size;
		playerHeight = playerSize.y;
		playerWidth = playerSize.x;
	}
	static public void removePlayer(GameObject oldPlayer) {
		if (player == oldPlayer)
			removePlayer ();
	}
	static public void removePlayer() {
		player = null;
		playerHeight = 0;
		playerWidth = 0;
	}
}
