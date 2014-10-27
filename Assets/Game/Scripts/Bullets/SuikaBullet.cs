using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// スイカ弾
/// </summary>
public class SuikaBullet : Bullet {

	public override void Init(Dictionary<string,object> dict){
		pierce = false;
		SetAP (40);
		rigidbody2D.velocity = transform.up.normalized *5;
		Invoke ("Destroy", 1.2f);
	}
}
