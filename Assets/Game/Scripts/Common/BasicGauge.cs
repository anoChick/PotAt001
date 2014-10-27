using UnityEngine;
using System.Collections;

/// <summary>
/// 基本的な使い方のゲージ
/// </summary>
public class BasicGauge : MonoBehaviour {
	private int ANIM_FRAME = 10;

	private int nextValue;

	private int currentValue;

	private int maxValue;


	//View
	[SerializeField]
	private UILabel valueLabel;

	[SerializeField]
	private UISlider slider;

	public void Init(int value,int maxValue){
		nextValue = value;
		currentValue = value;
		this.maxValue = maxValue;
		Rerender ();
	}

	public void RenewValue(int newValue){
		nextValue = newValue;
		StartCoroutine ("TransGauge");
	}

	public void RenewMaxValue (int newMaxValue){
		maxValue = newMaxValue;
		Rerender ();
	}

	IEnumerator TransGauge(){
		int delta = (nextValue - currentValue) / ANIM_FRAME;

		for(int i = 0; i<ANIM_FRAME;i++){
			currentValue += delta;
			Rerender ();
			yield return new WaitForSeconds (0.016f);
		}
		currentValue = nextValue;
		Rerender ();
		yield break;
	}

	//現在の値でゲージの表示を変更
	void Rerender(){
		slider.value = ((float)currentValue) / ((float)maxValue);
		if (valueLabel != null)
			valueLabel.text = currentValue + " / " + maxValue;

	}

}
