using UnityEngine;
using System.Collections;
using System.Collections.Generic;
interface IBullet
{
	bool IsPierce();
	int GetAP();
	void SetAP(int v);
	void Init(Dictionary<string,object> dict);
}