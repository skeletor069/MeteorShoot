using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	TrailRenderer trail;
	Vector3 translateDir;
	bool falling = false;
	Vector3 startPos;
	Vector3 defaultPos = new Vector3(0, 10, 0);


	void Awake(){
		trail = GetComponent<TrailRenderer>();
		//InitiateFall (2,2,0);

	}

	public void InitiateFall(float speed, float startX, float endX){
		startPos = new Vector3 (startX, 5.5f);
		translateDir = new Vector3 (endX, -4f) - startPos;
		translateDir = translateDir.normalized * speed;
		transform.position = startPos;
		falling = true;
		trail.enabled = true;
	}

	public bool Destroyed(){
		if(falling){
			trail.enabled = false;
			transform.position = defaultPos;
			BattleController.instance.MeteorDestroyed();
			MeteorGeneration.instance.AddToMeteorPool(this);
			falling = false;
			return true;
		}
		return false;
	}

	void Update () {
		if (falling) {
			transform.Translate (translateDir * Time.deltaTime);
			if (transform.position.y <= -4f) {
				falling = false;
				trail.enabled = false;
				transform.position = startPos;
				BattleController.instance.GameOver();
			}
		}
	}


}
