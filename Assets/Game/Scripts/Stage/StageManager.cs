using UnityEngine;
using System.Collections;

public class StageManager : SingletonMonoBehaviour<StageManager> {

		
	[SerializeField]
	private GameStatus gameStatus;

	[SerializeField]
	private StageUIController stageUIController;

	[SerializeField]
	private Farm farm;

	public GameObject stageArea;

	void Awake(){
		gameStatus.nutriment = 10;
		gameStatus.maxNutriment = 500;
		gameStatus.pollution = 0;
		gameStatus.maxPollution = 100;
		SetStage (1);
		SetScore (0);
	}

	public void SetYoubun(int v){
		gameStatus.nutriment = v;
		stageUIController.RenewYoubunValue(v);
	}

	public void SetMaxYoubun(int v){
		gameStatus.maxNutriment = v;
		stageUIController.RenewMaxYoubunValue(v);
	}
	public int GetYoubun(){
		return gameStatus.nutriment;
	}
	public int GetMaxYoubun(){
		return gameStatus.maxNutriment;
	}

	public void SetOsen(int v){
		gameStatus.pollution = v;
		stageUIController.RenewOsenValue(v);
	}

	public void SetMaxOsen(int v){
		gameStatus.maxPollution = v;
		stageUIController.RenewMaxOsenValue(v);
	}
	public int GetOsen(){
		return gameStatus.pollution;
	}
	public int GetMaxOsen(){
		return gameStatus.maxPollution;
	}

	public void SetStage (int stageLevel)
	{
		gameStatus.stage = stageLevel;
		stageUIController.ReNewStageValue (stageLevel);
	}
	public void SetScore (int score)
	{
		gameStatus.score =score;
		stageUIController.ReNewScoreValue (score);
	}
	public int GetScore(){
		return gameStatus.score;
	}
	public int GetStage(){
		return gameStatus.stage;
	}
}
