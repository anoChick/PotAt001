using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	protected GameObject bulletPrefab;

	protected int level=0;
	protected int no = 0;

	private Unit unit;

	protected string friend;

	public void Awake(){
		friend=gameObject.tag.Replace("Unit","");
		unit = gameObject.GetComponent<Unit>();
		if (unit != null) {
			level = unit.level;
			no = unit.no;
		}
	}

}
