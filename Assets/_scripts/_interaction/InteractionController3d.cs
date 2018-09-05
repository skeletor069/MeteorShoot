﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController3d : Interaction {

	public Transform target;
	Vector3 startPos;
	bool touchingDown = false;
	Vector3 currentTranslate = Vector3.zero;
	SpriteRenderer renderer;
	Color defaultColor, activeColor;

	void Awake(){
		renderer = target.GetComponent<SpriteRenderer>();
		activeColor = renderer.color;
		defaultColor = activeColor;
		defaultColor.a = .5f;
		renderer.color = defaultColor;
	}

	public void TouchStart(){
		renderer.color = activeColor;
		touchingDown = true;
		startPos = Input.mousePosition;
	}

	public void TouchEnd(){
		renderer.color = defaultColor;
		touchingDown = false;
		Fire(target.position);
		//target.position = Vector3.zero;
	}

	void Update(){
		if (touchingDown) {
			currentTranslate = Input.mousePosition - startPos;
			currentTranslate.z = 0;
			float length = currentTranslate.magnitude * 2.5f / 200f; 
			currentTranslate = currentTranslate.normalized * length;
			target.Translate(currentTranslate);
			//Debug.Log(currentTranslate);
			if (target.position.y < -1f) {
				Vector3 temp = target.position;
				temp.y = -1;
				target.position = temp;
			}
			else if (target.position.y > 3.5f) {
				Vector3 temp = target.position;
				temp.y = 3.5f;
				target.position = temp;
			}
			else if (target.position.x < -2.5f) {
				Vector3 temp = target.position;
				temp.x = -2.5f;
				target.position = temp;
			}
			else if (target.position.x > 2.5f) {
				Vector3 temp = target.position;
				temp.x = 2.5f;
				target.position = temp;
			}
			startPos = Input.mousePosition;
			UpdateTargetPos(target.position);
		}
	}
}
