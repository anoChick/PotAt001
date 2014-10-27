using UnityEngine;
using System.Collections;

/// <summary>
/// 回復やらの汎用的なビヘイビア
/// </summary>
public class StageWorker : MonoBehaviour {



	void Start () {
		InvokeRepeating ("YoubunAdder",0f, 1f);
	}

	/// <summary>
	/// 養分を増やす
	/// </summary>
	void YoubunAdder(){
		int d = 2;
		int youbun = StageManager.Instance.GetYoubun();
		int maxYoubun = StageManager.Instance.GetMaxYoubun ();
		if (maxYoubun > youbun)
			StageManager.Instance.SetYoubun (youbun + d);
	}

}
