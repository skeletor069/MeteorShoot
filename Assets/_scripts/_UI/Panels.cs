using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panels : MonoBehaviour {

	Animator animator;

	static int animShow = Animator.StringToHash("show");
	static int animHide = Animator.StringToHash("hide");

	public void Awake () {
		animator = GetComponent<Animator>();
	}
	
	public void Show(){
		animator.SetTrigger(animShow);
	}

	public void Hide(){
		animator.SetTrigger(animHide);
	}
}
