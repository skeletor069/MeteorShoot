using UnityEngine;
public interface IInteractionListener {
	void Fire(Vector3 targetScreenPos);
	void UpdateTargetPos(Vector3 targetScreenPos);
	void Laser();
}
