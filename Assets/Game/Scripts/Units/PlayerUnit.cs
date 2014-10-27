using UnityEngine;
using System.Collections;

public class PlayerUnit : Unit {



	//無敵
	private bool invincible =true;

	//精製後の時間
	private int entryCount = 0;

	private int ENTRY_TIME =10;

	//抜いた後ちょっと前に出る
	public void Entry(){
		entryCount = ENTRY_TIME;
		invincible = true;
	}


	public void Init(GameSettings.PlayerUnits.UNIT_NO n,int level){
		hp = 300;
		maxHP = 300;
		hpGauge.Init (hp, maxHP);

		no = (int)n+1;

		this.level = level;
		if (no != 0) {
			img.spriteName = GameSettings.PlayerUnits.UNIT_CODENAME [no-1];

			if (weapon == null)
				switch (no) {
				case 1:
				weapon = gameObject.AddComponent<SuikaWeapon>();
				break;
			case 2:
				weapon =gameObject.AddComponent<RetasuWeapon>();
				break;
			case 3:
				weapon =gameObject.AddComponent<JagaWeapon>();
				break;
			case 4:
				weapon =gameObject.AddComponent<KabotyaWeapon>();
				break;
			case 5:
				weapon =gameObject.AddComponent<NegiWeapon>();
				break;
			case 6:
				weapon =gameObject.AddComponent<NasuWeapon>();
				break;

			}

		}

	}

	void Update(){
		if (entryCount > 0) {
			Vector3 pos = transform.localPosition;
			Vector3 newPos = new Vector3 (pos.x+UnityEngine.Random.Range(0,10)-5, pos.y+UnityEngine.Random.Range(16,20), pos.z);
			transform.localPosition = newPos;

			entryCount--;
		} else {
			invincible = false;
		}
	}
		
	void OnTriggerEnter2D (Collider2D c)
	{

		if (c.gameObject.tag == "EnemyBullet") {
			hp -= 10;
			hpGauge.RenewValue (hp);
			if (hp < 0) {
				ObjectPool.instance.ReleaseGameObject (gameObject);
			}

			ObjectPool.instance.ReleaseGameObject (c.gameObject);
		}
	}


	void OnDrag(Vector2 delta)
	{
		Vector2 mousePoint = UICamera.lastTouchPosition;
		Vector2 worldPoint = UICamera.currentCamera.ScreenToWorldPoint(mousePoint);

		transform.position = new Vector3(worldPoint.x, worldPoint.y, transform.position.z);
	}
}
