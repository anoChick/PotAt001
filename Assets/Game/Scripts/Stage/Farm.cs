using UnityEngine;
using System.Collections;

public class Farm : MonoBehaviour {


	[SerializeField]
	private Sprout[] sproutList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//植える
	public void Plant(VegeButton btn){
		int youbun = StageManager.Instance.GetYoubun ();
		int cost = (GameSettings.PlayerUnits.UNIT_COST [((int)btn.getUnitNo ())]);
		if (youbun >= cost) {
			foreach(var sprout in sproutList){
				if (sprout.IsBlank) {
					//植える
					StageManager.Instance.SetYoubun (youbun - cost);
					sprout.Plant (btn.getUnitNo());
					break;
				}
			}

		}
		else//うえない
			Debug.Log ("養分が足りません");
	}

}
