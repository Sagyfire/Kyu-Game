using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KyuHealth : MonoBehaviour {

    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour;
    public bool damaged = false;

	//HP and HPHUD
	private float currentHP;
	public float GetCurrentHP() {return currentHP;}
	public void SetCurrentHP(float hp)
	{
		currentHP = hp;
	}

	private float max_hp = 100f;
	public float GetMaxHP(){return max_hp;}

	public float GetHPPct()
	{
		return	(float)currentHP / max_hp;
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
		
	}


    public void TakeDamage ()
    {
        damaged = true;
    }

    IEnumerator DamageFlah()
    {
        yield return null;
    }
}
