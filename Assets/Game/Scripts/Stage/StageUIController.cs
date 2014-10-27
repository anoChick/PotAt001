using UnityEngine;
using System.Collections;

public class StageUIController : MonoBehaviour {

	[SerializeField]
	private BasicGauge youbunGauge;

	[SerializeField]
	private BasicGauge osenGauge;

	[SerializeField]
	private UILabel scoreLabel;

	[SerializeField]
	private UILabel stageLabel;


	[SerializeField]
	private VegeButton[] vegeButtonList;

	void Awake(){
		youbunGauge.Init (StageManager.Instance.GetYoubun(),StageManager.Instance.GetMaxYoubun());
		osenGauge.Init (StageManager.Instance.GetOsen(),StageManager.Instance.GetMaxOsen());
	}

	public void ReNewStageValue(int v){
		stageLabel.text = v.ToString();
	}
	public void ReNewScoreValue(int v){
		scoreLabel.text = "SCORE:" + (v.ToString().PadLeft (10, '0'));
	}

	public void RenewYoubunValue (int v)
	{
		youbunGauge.RenewValue (v);
		RenewVegeButtons (v);
	}
	public void RenewMaxYoubunValue (int v)
	{
		youbunGauge.RenewMaxValue (v);
	}
	public void RenewOsenValue (int v)
	{
		osenGauge.RenewValue (v);
	}
	public void RenewMaxOsenValue (int v)
	{
		osenGauge.RenewMaxValue (v);
	}

	public void RenewVegeButtons(int youbunValue){
		foreach (var vegeBtn in vegeButtonList) {
				vegeBtn.SetEnable (vegeBtn.Cost <= youbunValue);
		}
	}
}
