using UnityEngine;
using System.Collections;

public class VegeButton : MonoBehaviour {

	[SerializeField]
	private GameSettings.PlayerUnits.UNIT_NO unitNo;

	[SerializeField]
	private int cost;

	[SerializeField]
	private UISprite img;

	[SerializeField]
	private UISprite disabledPlate;

	[SerializeField]
	private UILabel costLabel;

	[SerializeField]
	private BoxCollider2D collider;



	void Awake(){
		cost = GameSettings.PlayerUnits.UNIT_COST [(int)unitNo];
		costLabel.text = "" + cost;
		img.spriteName = GameSettings.PlayerUnits.UNIT_CODENAME [(int)unitNo];
		
	}


	public int Cost{
		get{ 
			return cost;
		}
		set{ 
			cost = value;
			if (costLabel != null)
				costLabel.text = ""+cost;
		}

	}

	public GameSettings.PlayerUnits.UNIT_NO getUnitNo(){
		return unitNo;
	}

	public void SetEnable(bool b){
		collider.enabled =b;
		disabledPlate.enabled =!b;
	}

}
