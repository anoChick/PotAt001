using UnityEngine;
using System.Collections;

public class EntityObject : MonoBehaviour {

	public void Destroy(){
		CancelInvoke ("Destroy");
		Destroy (GetComponent<MovePattern>());
		Destroy (GetComponent<Weapon>());
		ObjectPool.instance.ReleaseGameObject (gameObject);
	}
	public bool OutOfDisplay(){
		int DISP_W = (int)(1080f*1.15f);
		int DISP_H = (int)(1920f*1.1f);
		int x = (int)transform.localPosition.x;
		int y = (int)transform.localPosition.y;

		if ((DISP_H / 2) < y)
			return true;
		if (-(DISP_H / 2) > y)
			return true;

		if ((DISP_W / 2) < x)
			return true;
		if (-(DISP_W / 2) > x)
			return true;

		return false;
	}
}
