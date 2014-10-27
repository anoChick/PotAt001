using UnityEngine;
using System.Collections;

public class NegiWeapon :  Weapon {

	void Awake(){
		base.Awake ();
		bulletPrefab = Resources.Load <GameObject>("Prefabs/Bullet[Negi]");
	}
	void Start () {
		StartCoroutine ("Fire");

	}


	IEnumerator Fire(){
		while (true) {



			GenerateBullet (level);
			// 0.05秒待つ
			yield return new WaitForSeconds (0.016f);
		}
	}

	void GenerateBullet(int l){


			// 弾をプレイヤーと同じ位置/角度で作成
			GameObject bullet = Instantiate(bulletPrefab) as GameObject ;
			bullet.transform.parent = transform.parent;
			bullet.transform.rotation = transform.rotation;
		float[] d = {1f,1.5f,2f};

		bullet.transform.localScale = new Vector3(d[l-1],1f,1f);
			Vector3 pos = transform.localPosition;
		Vector3 newPos = new Vector3(pos.x ,pos.y+64,pos.z);
			bullet.transform.localPosition = newPos;
		bullet.tag = friend+"Bullet";
		(bullet.GetComponent<Bullet>() as IBullet).Init (null);

	
	}
}
