using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	//現在のステージ
	public int stage =1;

	//養分
	public int nutriment = 0;
	public int maxNutriment = 500;

	//汚染
	public int pollution = 0;
	public int maxPollution = 500;

	//お金
	public int monay = 0;

	//スコア
	public int score = 0;
}
