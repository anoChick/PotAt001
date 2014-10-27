using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 芽
/// </summary>
public class Sprout : MonoBehaviour {

	[SerializeField]
	private GameObject stageArea;

	private GameObject playerUnitPrefab;

	private int exp = 0;

	public int level = 1;

	private GameSettings.PlayerUnits.UNIT_NO unitNo;

	[SerializeField]
	private UISprite img;

	public bool IsBlank{
		get{ return level == 0;}

	}

	void Awake(){
		playerUnitPrefab = Resources.Load <GameObject>("Prefabs/PlayerUnit");
	}


	// Use this for initialization
	void Start () {
		exp = UnityEngine.Random.Range(0,100);
		level = 0;
		img.spriteName = "me" + level;
	
	}

	public void Plant(GameSettings.PlayerUnits.UNIT_NO u){
		unitNo = u;
		changeLevel (1);
	}

	
	// Update is called once per frame
	void Update () {
		if(level!=0)
			exp++;
			
		if (exp == 300)
			changeLevel (2);
		if (exp == 500)
			changeLevel (3);
	}

	void changeLevel (int l){
		level = l;
		if (l >= 1 && l <= 3)
			img.spriteName = "me" + level;
		else
			img.spriteName = null;
	}

	void OnHover(bool isOver)
	{
		Pull ();
	}
	void OnPress (bool isDown) {
		Pull ();

	}
	void OnDrag (Vector2 delta) {
		Pull ();
	}
	void OnDragOver (GameObject draggedObject) {
		Pull ();
	}

	public void Pull(){
		if (level == 0)
			return;
		GameObject playerUnit = Instantiate (playerUnitPrefab) as GameObject;
		playerUnit.transform.parent = transform.parent;
		playerUnit.transform.localScale = transform.localScale;
		playerUnit.transform.localPosition = transform.localPosition;
		playerUnit.transform.parent = stageArea.transform;



		playerUnit.GetComponent<PlayerUnit>().Init (unitNo,level);
		playerUnit.GetComponent<PlayerUnit> ().Entry ();
		Debug.Log ("生成:Lv"+level);
		exp = 0;
		changeLevel(0);
	}
}
