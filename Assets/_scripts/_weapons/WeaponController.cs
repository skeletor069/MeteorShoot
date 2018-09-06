using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour, IInteractionListener, IMissileListener {

	public Transform turret;
	public Transform missilesHolder;
	public Transform lockTargetsHolder;
	public Turret weapon;
	public List<MissileChamber> chamberUI = new List<MissileChamber>();
	float speed = 1;
	List<Missile> missilePool = new List<Missile>();
	List<Transform> lockTargetsPool = new List<Transform>();
	Vector3 lockTrgetDefaultPosition = new Vector3(30,0,0);

	int[] chambers = new int[3];

	List<Vector3> muzzlePositions = new List<Vector3>();

	void Awake () {

		muzzlePositions.Add(new Vector3(-2.5f, -3.6f, 0f));
		muzzlePositions.Add(new Vector3(0f, -3.6f, 0f));
		muzzlePositions.Add(new Vector3(2.5f, -3.6f, 0f));

		for(int i = 0 ; i < missilesHolder.childCount; i++)
			missilePool.Add(missilesHolder.GetChild(i).GetComponent<Missile>());

		for(int i = 0 ; i < lockTargetsHolder.childCount; i++)
			lockTargetsPool.Add(lockTargetsHolder.GetChild(i));

		for(int i = 0 ; i < missilePool.Count; i++)
			missilePool[i].Initiate(this);
	}

	public void Initiate(int leftChamber, int centerChamber, int rightChamber){
		chambers[0] = leftChamber;
		chambers[1] = centerChamber;
		chambers[2] = rightChamber;

		for(int i = 0 ; i < 3; i++)
			chamberUI[i].Initiate(chambers[i]);

	}

	int GetClosestWeaponIndex(float targetX){
		float distance = 2000;
		int selectedIndex = 1;
		for(int i = 0 ; i < 3; i++){
			if(chambers[i] != 0 && Mathf.Abs(targetX - muzzlePositions[i].x) < distance){
				distance = Mathf.Abs(targetX - muzzlePositions[i].x);
				selectedIndex = i;
			}
		}
		return selectedIndex;
	}

	Missile GetMissileFromPool(){
		if(missilePool.Count == 0)
			return null;

		Missile temp = missilePool[0];
		missilePool.RemoveAt(0);
		return temp;
	}

	Transform GetLockTargetFromPool(){
		if(lockTargetsPool.Count == 0)
			return null;

		Transform temp = lockTargetsPool[0];
		lockTargetsPool.RemoveAt(0);
		return temp;
	}

	public void Fire(Vector3 worldPos){
		Transform lockTarget = GetLockTargetFromPool();
		Missile missile = GetMissileFromPool();
		int weaponIndex = GetClosestWeaponIndex(worldPos.x);
		
		if(lockTarget != null && missile != null && chambers[weaponIndex] != 0){
			chambers[weaponIndex]--;
			chamberUI[weaponIndex].Consume();
			lockTarget.position = worldPos;
			MissileData data = new MissileData();
			data.startPos = muzzlePositions[weaponIndex];
			data.targetPos = worldPos;
			data.lockTarget = lockTarget;
			data.missile = missile;
			data.weaponIndex = weaponIndex;
			StartCoroutine(missile.HitTarget(data));
		}
	}

	public void Laser(){

	}

	public void UpdateTargetPos(Vector3 worldPos){
		// turret.LookAt(worldPos);
		//turret.forward = Vector3.Lerp(turret.forward, worldPos - turret.position, Time.deltaTime * speed);
	}

	public void NotifyExplosion(Transform lockTarget, Missile missile){
		lockTarget.position = lockTrgetDefaultPosition;
		lockTargetsPool.Add(lockTarget);
		missilePool.Add(missile);
	}

	public void NotifySuccessfulDestroy(int weaponIndex){
		chambers[weaponIndex]++;
		chamberUI[weaponIndex].ReloadOne();
	}


}
