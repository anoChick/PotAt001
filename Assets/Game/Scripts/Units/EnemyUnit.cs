using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 敵ユニット
/// </summary>
public class EnemyUnit : Unit {
	private int score=0;
	private int osen =0;
	//移動スクリプト
	private MovePattern movePattern;

	void Awake(){

		Init (GameSettings.EnemyUnits.UNIT_NO.Suika,1);
	}



	public void Init(GameSettings.EnemyUnits.UNIT_NO n,int level){

		maxHP = 1000;
		hp = maxHP;
		hpGauge.Init (hp, maxHP);
		score = 200;
		osen = 5;

		if (movePattern != null)
			DestroyImmediate (movePattern);
		movePattern = gameObject.AddComponent<MovePattern> ();
		Dictionary<string,object> mPatDict = new Dictionary<string,object> ();
		mPatDict.Add ("pattern",1);
		movePattern.Init (mPatDict);
		no = (int)n+1;
		this.level = level;
		if (no != 0) {
			//img.spriteName = GameSettings.PlayerUnits.UNIT_CODENAME [no-1];
			if (weapon != null)
				DestroyImmediate (weapon);
			if (weapon == null)
				switch (no) {
			case 1:
				weapon = gameObject.AddComponent<Enemy1Weapon>();
				break;
			case 2:
				//weapon =gameObject.AddComponent<RetasuWeapon>();
				break;
			case 3:
				//weapon =gameObject.AddComponent<JagaWeapon>();
				break;
			case 4:
				//weapon =gameObject.AddComponent<KabotyaWeapon>();
				break;
			case 5:
				//weapon =gameObject.AddComponent<NegiWeapon>();
				break;
			case 6:
				//weapon =gameObject.AddComponent<NasuWeapon>();
				break;

				}

			}

	}


	//衝突判定
	void OnTriggerEnter2D (Collider2D c)
	{
		Debug.Log ("Hit!");
		//畑に突っ込んだ時
		if (c.gameObject.name == "Farm") {
			int newOsen = StageManager.Instance.GetOsen();
			newOsen += osen;
			StageManager.Instance.SetOsen (newOsen);
			ObjectPool.instance.ReleaseGameObject (gameObject);

			//プレイヤー弾に当たった時
		}else if(c.gameObject.tag == "PlayerBullet"){
			IBullet playerBullet = c.gameObject.GetComponent<Bullet> ();


			hp -= playerBullet.GetAP();
			hpGauge.RenewValue (hp);
			if (hp < 0) {
				StageManager.Instance.SetScore (StageManager.Instance.GetScore () + score);
				ObjectPool.instance.ReleaseGameObject (gameObject);
			}
			if(!playerBullet.IsPierce())
			ObjectPool.instance.ReleaseGameObject (c.gameObject);

		}

	}


}
