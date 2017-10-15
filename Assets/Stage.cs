using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Stage : MonoBehaviour {
	public float setEditorWidth;
	public float setEditortHeight;
	static public float x;
	static public float y;
	static public float width;
	static public float height;
	static public float editorWidth;
	static public float editorHeight;
	static public float scaleX;
	static public float scaleY;
	static public float top;
	static public float right;
	static public float bottom;
	static public float left;
	static public float velocity;
	void Awake () {
		editorWidth = setEditorWidth;
		editorHeight = setEditortHeight;
		Camera cam = GetComponent<Camera>();
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		scaleX = width / editorWidth;
		scaleY = height / editorHeight;
		x = transform.position.x;
		y = transform.position.y;
		top = y + (height / 2f);
		right = x + (width / 2f);
		bottom = y - (height / 2f);
		left = x - (width / 2f);
	}
}
