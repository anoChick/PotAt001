using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 追尾弾
/// </summary>
public class Common1Bullet : Bullet {

	public override void Init(Dictionary<string,object> dict){

		pierce = false;
		GameObject[] playerUnitAry = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		GameObject nearestPlayerUnit = null;
		float nearestPlayerUnitDistance=-1;
		foreach (GameObject playerUnit in playerUnitAry) {
			float distance = Vector3.Distance (playerUnit.transform.localPosition, transform.localPosition);
			if (distance>nearestPlayerUnitDistance) {
				nearestPlayerUnitDistance = distance;
				nearestPlayerUnit = playerUnit;
			}

		}
		if (nearestPlayerUnit != null) {
			transform.LookAt2D (nearestPlayerUnit.transform,Vector2.up);
		}

		rigidbody2D.velocity = transform.up.normalized * 1f;
		Invoke ("Destroy",5f);
	}

}
