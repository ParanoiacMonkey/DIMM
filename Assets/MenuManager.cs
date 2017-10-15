using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public GameObject setMenu;
	public float setVelocity;
	static float target;
	static bool thenDestroy;
	static GameObject menuPrefab;
	static GameObject menu;
	static float velocity;
	void Start () {
		menuPrefab = setMenu;
		velocity = setVelocity;
		target = transform.position.y;
	}
	void Update () {
		float delta = Stage.velocity * Time.deltaTime;
		if (delta > 0 && target - menu.transform.position.y < delta) {
			menu.transform.position = new Vector3 (Stage.x, target);
			if (thenDestroy)
				Destroy (menu);
			else
				Stage.velocity = 0;
		} else {
			menu.transform.position = new Vector3 (Stage.x, menu.transform.position.y + delta);
		}
	}
	static public void GetIn() {
		menu = Instantiate (menuPrefab, new Vector3 (Stage.x, Stage.y - Stage.height), Quaternion.identity);
		target = Stage.y;
		if (Stage.velocity < velocity)
			Stage.velocity = velocity;
		thenDestroy = false;
	}
	static public void GetOut() {
		target = Stage.y + Stage.height;
		thenDestroy = true;
	}
}
