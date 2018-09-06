using UnityEngine;

public interface IMissileListener {
	void NotifyExplosion(Transform lockTarget, Missile missile);
	void NotifySuccessfulDestroy(int weaponIndex);
}
