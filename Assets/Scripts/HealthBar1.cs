using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar1 : MonoBehaviour
{
    public Image currentHealthbar;
    public Text ratioText;

	public float hitpoint = 100;
	public float maxHitpoints = 100;

    private void Start()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float ratio = hitpoint / maxHitpoints;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

	/*
    public void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint < 0)
        {
            hitpoint = 0;
            Debug.Log("Dead!");
        }
        UpdateHealthBar();
    }
	*/

    public void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoints)
            hitpoint = maxHitpoints;

    
        UpdateHealthBar();
    }
}
