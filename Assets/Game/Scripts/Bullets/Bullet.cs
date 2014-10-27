using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : EntityObject,IBullet {
	public bool PLAYER_SIDE;
	public bool pierce;
	private int ap;
	public virtual void Init(){
	}
	public int GetAP(){
		return ap;
	}
	public void SetAP(int v){
		ap = v;
	}
	public virtual void Init(Dictionary<string,object> dict){

	}
	public bool IsPierce(){
		return pierce;
	}

}
