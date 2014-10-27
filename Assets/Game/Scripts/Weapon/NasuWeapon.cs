using UnityEngine;
using System.Collections;

public class NasuWeapon :  Weapon{
	void Awake(){
		base.Awake ();
		bulletPrefab = Resources.Load <GameObject>("Prefabs/Bullet[Nasu]");
		StartCoroutine ("Fire");
	}


	IEnumerator Fire(){
		while (true) {
			GenerateBullet (level);
			yield return new WaitForSeconds (1f);
		}
	}

	void GenerateBullet(int l){


		// 弾をプレイヤーと同じ位置/角度で作成
		GameObject bullet = Instantiate(bulletPrefab) as GameObject ;
		bullet.transform.parent = transform.parent;
		bullet.transform.rotation = transform.rotation;
		float[] d = {0.7f,1.1f,1.3f};

		bullet.transform.localScale = new Vector3(d[l-1],d[l-1],d[l-1]);
		Vector3 pos = transform.localPosition;
		Vector3 newPos = new Vector3(pos.x ,pos.y,pos.z);
		bullet.transform.localPosition = newPos;

		(bullet.GetComponent<Bullet>() as IBullet).Init (null);

	}
}
