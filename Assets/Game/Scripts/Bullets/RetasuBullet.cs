using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RetasuBullet : Bullet {

	float r;
	int angle;
	// Use this for initialization
	int life;
	bool right =true;
	int reTargetCount = 30;
	GameObject targetUnit;
	public override void Init(Dictionary<string,object> dict){
		pierce = true;
		targetUnit = null;
		r = 15;
		SetAP (9);
		rigidbody2D.angularVelocity = 4f;
		Invoke ("Destroy", 10f);
		angle = 0;
		life = 0;
		ReTarget ();

	}

	public void SetRight(bool r){
		right = r;

	}
	void ReTarget(){

		GameObject[] enemyUnitAry = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		GameObject nearestEnemyUnit = null;
		float nearestEnemyUnitDistance=-1;
		foreach (GameObject enemyUnit in enemyUnitAry) {
			float distance = Vector3.Distance (enemyUnit.transform.localPosition, transform.localPosition);
			if (distance>nearestEnemyUnitDistance) {
				nearestEnemyUnitDistance = distance;
				nearestEnemyUnit = enemyUnit;
				}

			}
		if (nearestEnemyUnit != null) {
			transform.LookAt2D (nearestEnemyUnit.transform,Vector2.up);
			rigidbody2D.velocity = transform.up.normalized * 0.3f;
			}


	}

	// Update is called once per frame
	void Update () {
		reTargetCount--;
		if (reTargetCount <= 0) {
			reTargetCount = 15;
			ReTarget ();
		}


		life++;
		if (right)
			angle += 10;
		else
			angle -= 10;
		transform.rotation = Quaternion.Euler (new Vector3(0,0,(float)angle));
		Vector3 pos = transform.localPosition;
		Vector3 newPos;
		if (right)
			newPos = new Vector3 (pos.x+r*Mathf.Sin(((float)life)/8f), pos.y+r*Mathf.Cos(((float)life)/8f), pos.z);
		else 
			newPos = new Vector3 (pos.x-r*Mathf.Sin(((float)life)/8f), pos.y+r*Mathf.Cos(((float)life)/8f), pos.z);
		transform.localPosition = newPos;
	}

}
