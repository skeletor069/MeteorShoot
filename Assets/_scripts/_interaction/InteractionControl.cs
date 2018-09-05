using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionControl : Interaction {

	public RectTransform target;
	Vector3 startPos;
	bool touchingDown = false;
	Vector3 currentTranslate = Vector3.zero;
	Vector2 targetStartPosition = new Vector2(360, 600);
	public void TouchStart(){
		touchingDown = true;
		startPos = Input.mousePosition;
	}

	public void TouchEnd(){
		touchingDown = false;
		Fire(target.anchoredPosition);
		target.anchoredPosition = targetStartPosition;
	}

	void Update(){
		if (touchingDown) {
			currentTranslate = Input.mousePosition - startPos;
			currentTranslate *= 1.5f;
			target.transform.Translate (currentTranslate);
			if (target.anchoredPosition.y < 200f) {
				Vector3 temp = target.anchoredPosition;
				temp.y = 200;
				target.anchoredPosition = temp;
			}

			if (target.anchoredPosition.y > 1200) {
				Vector3 temp = target.anchoredPosition;
				temp.y = 1200;
				target.anchoredPosition = temp;
			}

			if (target.anchoredPosition.x < 10) {
				Vector3 temp = target.anchoredPosition;
				temp.x = 10;
				target.anchoredPosition = temp;
			}

			if (target.anchoredPosition.x > 710) {
				Vector3 temp = target.anchoredPosition;
				temp.x = 710;
				target.anchoredPosition = temp;
			}
			startPos = Input.mousePosition;
		}
	}

}
