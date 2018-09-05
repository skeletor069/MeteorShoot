using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public Transform muzzle1;
	public Transform muzzle2;
	
	public Vector3 GetMuzzlePosition(){
		if(Random.Range(0f,1f) < .5f)
			return muzzle1.position;
		else
			return muzzle2.position;
	}
}
