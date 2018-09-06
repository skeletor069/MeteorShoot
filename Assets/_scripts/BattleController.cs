using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LevelConfig{
	public int leftTurretBulletCount;
	public int rightTurretBulletCount;
	public int centerTurretBulletCount;
}

public class BattleController : MonoBehaviour {
	public static BattleController instance;
	public Interaction interaction;
	public WeaponController weaponController;
	MeteorGeneration meteorGeneration;
	UIController uiController;
	LevelConfig levelConfig;
	int score;
	int bestScore;

	void Awake () {
		instance = this;
		meteorGeneration = GetComponent<MeteorGeneration>();
		uiController = GetComponent<UIController>();
		levelConfig = new LevelConfig();
		levelConfig.leftTurretBulletCount = 6;
		levelConfig.centerTurretBulletCount = 8;
		levelConfig.rightTurretBulletCount = 6;

		
	}

	void Start(){
		weaponController.Initiate(levelConfig.leftTurretBulletCount, levelConfig.centerTurretBulletCount, levelConfig.rightTurretBulletCount);
		interaction.Initiate(weaponController);
		uiController.Initiate(this);
		//meteorGeneration.GenerateWave();
		interaction.gameObject.SetActive(false);
		StartCoroutine(uiController.StartJourney());
	}

	public void StartGame(){
		score = 0;
		meteorGeneration.GenerateWave();
		interaction.gameObject.SetActive(true);
	}

	public void MeteorDestroyed(){
		score++;
		uiController.SetScore(score);
	}

	public void GameOver(){
		interaction.gameObject.SetActive(false);
		bool newBest = false;
		if(score > bestScore){
			bestScore = score;
			newBest = true;
		}
		UIController.LoadGameOver(score, bestScore, newBest);
	}
	
}
