using UnityEngine;
using System.Collections;

public class SuikaWeapon : Weapon {


	void Awake(){
		base.Awake ();
		bulletPrefab = Resources.Load <GameObject>("Prefabs/Bullet[Suika]");
		StartCoroutine ("Fire");
	}

	IEnumerator Fire(){
		while (true) {

			GenerateBullet (level);
			// 0.05秒待つ
			yield return new WaitForSeconds (0.15f);
		}
	}

	void GenerateBullet(int l){

		int deltaR = -5 * (l - 1);//0,-5,-10
		int deltaP = -20 * (l - 1);//0,-20,-40
		for (int i = 0; i < l; i++) {

			// 弾をプレイヤーと同じ位置/角度で作成
			GameObject bullet = Instantiate(bulletPrefab) as GameObject ;
			bullet.transform.parent = transform.parent;
			bullet.transform.rotation = transform.rotation;
			bullet.transform.localScale = Vector3.one;
			Vector3 pos = transform.localPosition;
			Vector3 newPos = new Vector3(pos.x-(deltaP+(40*i)) ,pos.y,pos.z);
			bullet.transform.localPosition = newPos;
			bullet.tag = friend+"Bullet";

			bullet.transform.rotation = Quaternion.Euler (new Vector3(0,0,deltaR+(10*i)));
			(bullet.GetComponent<Bullet>() as IBullet).Init (null);
		}

	}
}
