using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour {
	void Awake () {
		Vector3 actualScale = transform.localScale;
		Vector3 newScale = new Vector3 (actualScale.x * Stage.scaleX, actualScale.y * Stage.scaleY, 1);
		transform.localScale = newScale;
	}
}
