using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NegiBullet : Bullet {

	public override void Init(Dictionary<string,object> dict){
		pierce = false;
		rigidbody2D.velocity = transform.up.normalized *4;
		SetAP (5);
		Invoke ("Destroy", 1f);

	}
}
