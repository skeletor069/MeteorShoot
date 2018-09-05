using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LevelConfig{
	public int leftTurretBulletCount;
	public int rightTurretBulletCount;
	public int centerTurretBulletCount;
}

public class BattleController : MonoBehaviour {
	public Interaction interaction;
	public WeaponController weaponController;
	MeteorGeneration meteorGeneration;
	LevelConfig levelConfig;

	void Awake () {
		meteorGeneration = GetComponent<MeteorGeneration>();
		levelConfig = new LevelConfig();
		levelConfig.leftTurretBulletCount = 6;
		levelConfig.centerTurretBulletCount = 8;
		levelConfig.rightTurretBulletCount = 6;

		
	}

	void Start(){
		weaponController.Initiate(levelConfig.leftTurretBulletCount, levelConfig.centerTurretBulletCount, levelConfig.rightTurretBulletCount);
		interaction.Initiate(weaponController);
		meteorGeneration.GenerateWave();
	}
	
}
