using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {
	IInteractionListener notifier;
	
	public void Initiate(IInteractionListener notifier){
		this.notifier = notifier;
	}

	protected void Fire(Vector3 worldPosition){
		notifier.Fire(worldPosition);
	}

	protected void UpdateTargetPos(Vector3 worldPosition){
		notifier.UpdateTargetPos(worldPosition);
	}
}
