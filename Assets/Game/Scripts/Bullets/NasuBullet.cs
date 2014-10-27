using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NasuBullet : Bullet {

	public override void Init(Dictionary<string,object> dict){
		pierce = false;
		rigidbody2D.AddForce (new Vector2(0f,300f));
		Invoke ("Destroy", 2f);
	}

}
