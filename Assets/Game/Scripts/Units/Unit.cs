using UnityEngine;
using System.Collections;

public class Unit : EntityObject {

	public string name = "";
	public int no = 0;
	public int level = 0;

	protected GameObject bulletPrefab;

	public Weapon weapon;

	[SerializeField]
	protected UISprite img;

	[SerializeField]
	protected BasicGauge hpGauge;

	protected int hp = 300;
	protected int maxHP = 300;

}
