using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MissileChamber : MonoBehaviour {

	List<GameObject> bullets = new List<GameObject>();
	int totalCount = 0;
	int currentIndex = 0;

	void Awake () {
		for(int i = 0; i < transform.childCount; i++)
			bullets.Add(transform.GetChild(i).gameObject);
	}
	
	public void Initiate(int count){
		this.totalCount = count;
		for(int i = 0 ; i < bullets.Count; i++){
			if(i >= count)
				bullets[i].SetActive(false);
		}
	}

	public void Consume(){
		bullets[currentIndex].SetActive(false);
		currentIndex++;
	}

	public void ReloadOne(){
		currentIndex--;
		bullets[currentIndex].SetActive(true);
	}
}
