using UnityEngine;
using System.Collections;


/// <summary>
/// ステージの管理
/// 敵ユニットの湧き等
/// </summary>
public class StageLevelManager : MonoBehaviour {
	public int nextStageWorkingCount = 30;
	public int stageLevel = 0;
	public int intervalCount = 0;
	private int INTERVAL_TIME = 10;
	public int workingCount;

	[SerializeField]
	private GameObject stageMap;

	private GameObject enemyUnitPrefab;

	void Start(){
		enemyUnitPrefab = Resources.Load <GameObject>("Prefabs/EnemyUnit");
		INTERVAL_TIME = 3;
		nextStageWorkingCount = 10;
		NextLevelStart ();
	}

	void NextLevelStart(){
		stageLevel++;
		StageManager.Instance.SetStage (stageLevel);
		workingCount = nextStageWorkingCount;
		InvokeRepeating ("LevelWorking", 0, 2f);
	}

	void LevelWorking(){
		workingCount--;
		if (workingCount <= 0) {
			intervalCount = INTERVAL_TIME;
			InvokeRepeating ("Interval", 0, 1f);
			CancelInvoke ("LevelWorking");
			return;
		}

		//処理
		GameObject enemyUnit = ObjectPool.instance.GetGameObject(enemyUnitPrefab) as GameObject ;
		enemyUnit.transform.parent = stageMap.transform;
		enemyUnit.transform.localScale = Vector3.one;
		enemyUnit.transform.localPosition = new Vector3 ((float)(UnityEngine.Random.Range(0,800)-400),1100f,0f);
		enemyUnit.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0,180f));
		enemyUnit.GetComponent<EnemyUnit> ().Init(GameSettings.EnemyUnits.UNIT_NO.Suika,stageLevel);
	}

	void Interval(){
		intervalCount--;
		if (intervalCount <= 0) {
			NextLevelStart ();
			CancelInvoke ("Interval");
		}
	}
}
