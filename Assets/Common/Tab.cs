using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tab : MonoBehaviour {
	public Object scene;
	virtual public void TabStart() {
		DontDestroyOnLoad (gameObject);
		Application.LoadLevel (scene.name);
	}
}
