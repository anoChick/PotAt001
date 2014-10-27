using UnityEngine;
using System.Collections;

public class RetasuWeapon :  Weapon{

	void Awake(){
		base.Awake ();
		bulletPrefab = Resources.Load <GameObject>("Prefabs/Bullet[Retasu]");
		StartCoroutine ("Fire");
	}

	IEnumerator Fire(){
		while (true) {

			float[] d = {2f,1.2f,0.6f};

			//左回り
			GameObject bullet= GenerateBullet (level);
			(bullet.GetComponent<Bullet>() as IBullet).Init (null);
			bullet.GetComponent<RetasuBullet>().SetRight(false);

			yield return new WaitForSeconds (d[level-1]);
		}
	}

	GameObject GenerateBullet(int l){


		GameObject bullet = Instantiate(bulletPrefab) as GameObject ;
		bullet.transform.parent = transform.parent;
		bullet.transform.rotation = transform.rotation;

		bullet.tag = friend+"Bullet";
		bullet.transform.localScale = Vector3.one;
		Vector3 pos = transform.localPosition;
		Vector3 newPos = new Vector3(pos.x ,pos.y,pos.z);
		bullet.transform.localPosition = newPos;


		return bullet;
	}
}
