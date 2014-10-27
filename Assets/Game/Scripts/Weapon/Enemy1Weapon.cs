using UnityEngine;
using System.Collections;
using System;
public class Enemy1Weapon :  Weapon {

	void Awake(){
		base.Awake ();
		bulletPrefab = Resources.Load <GameObject>("Prefabs/BaseBullet");
		StartCoroutine ("Fire");
	}
		
	IEnumerator Fire(){
		while (true) {
			GenerateBullet (level);
			yield return new WaitForSeconds (1.50f);
		}
	}

	void GenerateBullet(int l){

			GameObject bullet =ObjectPool.instance.GetGameObject(bulletPrefab) as GameObject ;
			bullet.tag = friend+"Bullet";
		bullet.transform.parent = transform.parent = StageManager.Instance.stageArea.transform;;

			bullet.transform.rotation = gameObject.transform.rotation;
			bullet.transform.localScale = Vector3.one;
			bullet.transform.localPosition = transform.localPosition;
			IBullet bulletComp =bullet.GetComponent<Bullet>();
			bulletComp.Init (null);


	}
}