using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGeneration : MonoBehaviour {

	public Transform meteorHolder;
	List<Meteor> meteorPool = new List<Meteor>();
	int generationCount = 1;
	int enemyThisLevel = 0;
	WaitForSeconds wait1s = new WaitForSeconds(1);
	public static MeteorGeneration instance;
	public List<float> targetPositions = new List<float>();

	void Awake () {
		instance = this;
		for(int i = 0 ; i < meteorHolder.childCount; i++)
			meteorPool.Add(meteorHolder.GetChild(i).GetComponent<Meteor>());
	}

	Meteor GetFromMeteorPool(){
		if(meteorPool.Count == 0)
			return null;

		Meteor temp = meteorPool[0];
		meteorPool.RemoveAt(0);
		return temp;
	}

	IEnumerator GenerationRoutine(){
		// gc
		// battle controller notify
		yield return wait1s;
		GenerateWave();
	}

	public void GenerateWave(){
		enemyThisLevel = GetEnemyCount();
		int specialEnemyCount = GetSpecialEnemyCount();
		int enemyCount =  enemyThisLevel - specialEnemyCount;
		GenerateEnemy(enemyCount);
		generationCount++;
	}

	public void AddToMeteorPool(Meteor meteor){
		meteorPool.Add(meteor);
		enemyThisLevel--;
		if(enemyThisLevel == 0){
			StartCoroutine(GenerationRoutine());
		}
	}



	void GenerateEnemy(int enemyCount){
		for(int i = 0 ; i < enemyCount; i++){
			float startX = Random.Range(-2.5f,2.5f);
			float endX = targetPositions[Random.Range(0, targetPositions.Count)];
			float speed = Random.Range(1.7f,3.5f);
			Meteor meteor = GetFromMeteorPool();
			if(meteor != null){
				meteor.InitiateFall(speed, startX, endX);
			}
		}
	}

	int GetEnemyCount(){
		// if(generationCount >= 8)
		// 	return 8;

		return Mathf.Min(Mathf.Max(generationCount/2, 1), 5);
	}

	int GetSpecialEnemyCount(){
		// if(generationCount > 5)
		// 	return Random.Range(0,3);

		return 0;
	}
	
}
