using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Stage : MonoBehaviour {
	public float setEditorWidth;
	public float setEditorHeight;
	static public float x;
	static public float y;
	static public float width;
	static public float height;
	static public float editorWidth;
	static public float editorHeight;
	static public float scaleX;
	static public float scaleY;
	static public Camera cam;
	void Awake () {
		x = transform.position.x;
		y = transform.position.y;
		cam = GetComponent<Camera> ();
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		editorHeight = setEditorHeight;
		editorWidth = setEditorWidth;
		scaleY = height / editorHeight;
		scaleX = width / editorWidth;
	}
}
