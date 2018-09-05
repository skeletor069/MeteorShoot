using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MissileData{
	public Vector3 startPos;
	public Vector3 targetPos;
	public Transform lockTarget;
	public Missile missile;
	public IMissileListener notifier;
}

public class Missile : MonoBehaviour {

	SpriteRenderer renderer;
	ParticleSystem particleSmoke;
	ParticleSystem explosion;
	GameObject explosion2d;
	TrailRenderer trail;
	static float speed = 7.5f;
	WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();
	WaitForSeconds wait1s = new WaitForSeconds(1);
	CircleCollider2D collider;


	// Use this for initialization
	void Awake () {
		renderer = GetComponent<SpriteRenderer>();
		particleSmoke = transform.GetChild(1).GetComponent<ParticleSystem>();
		explosion = transform.GetChild(0).GetComponent<ParticleSystem>();
		explosion2d = transform.GetChild(2).gameObject;
		collider = GetComponent<CircleCollider2D>();
		trail = GetComponent<TrailRenderer>();
	}
	

	public IEnumerator HitTarget(MissileData missileData){
		explosion2d.SetActive(false);
		collider.enabled = false;
		renderer.enabled = true;
		transform.position = missileData.startPos;
		trail.enabled = true;
		particleSmoke.Play();
		Vector3 dir = (missileData.targetPos - missileData.startPos).normalized;
		float predistance = Vector3.Distance(missileData.targetPos, transform.position);
		while(Vector3.Distance(missileData.targetPos, transform.position) > .2f && Vector3.Distance(transform.position, missileData.startPos) <= predistance){
			transform.Translate(dir * Time.deltaTime * speed);
			yield return endOfFrame;
			//predistance = Vector3.Distance(targetPos, transform.position);
		}
		yield return endOfFrame;
		transform.position = missileData.targetPos;
		// explode
		renderer.enabled = false;
		//explosion.Play();
		explosion2d.SetActive(true);
		collider.enabled = true;
		missileData.lockTarget.gameObject.SetActive(false);
		yield return wait1s;
		collider.enabled = false;
		missileData.notifier.NotifyExplosion(missileData.lockTarget, missileData.missile);
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log(col.name);
		col.GetComponent<Meteor>().Destroyed();
	}
}
