using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

	[SerializeField]
	RectTransform hpFill;

	private KyuHealth kyu;
	public void SetKyu (KyuHealth kyu)
	{
		this.kyu = kyu;
	}




	void Update()
	{
		SetHPBar (kyu.GetHPPct());
	}

	void SetHPBar (float hp)
	{
		hpFill.localScale = new Vector3 (hp, 1f, 1f);

	}

}
