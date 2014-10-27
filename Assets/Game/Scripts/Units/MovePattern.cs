using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 移動パターン
/// </summary>
public class MovePattern : MonoBehaviour {

	public int pattern = 0;


	public void Init(Dictionary<string,object> dic){

		if (dic.ContainsKey ("pattern"))
			pattern = int.Parse (dic ["pattern"].ToString ());

		switch (pattern) {
		case 1:

			Pattern1 (dic);
			break;
		}
	}



	//直線移動;
	void Pattern1(Dictionary<string,object> dic){
		transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 180f));
		rigidbody2D.velocity = transform.up.normalized * 0.1f;
	}

}
