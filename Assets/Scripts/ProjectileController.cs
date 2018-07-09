using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public float speed;
	private float lifetime = 2.0f;
	public int bulletNumber;
	private HealthBar1 hBar;



	private GameObject player;
	private Health1 pHealth;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player2");
		pHealth = (Health1) FindObjectOfType (typeof(Health1));
		hBar = (HealthBar1) FindObjectOfType (typeof(HealthBar1));
		
	}
	
	// Update is called once per frame
	void Update () {

		lifetime -= Time.deltaTime;

		if (lifetime > 0) 
		{
			transform.Translate (Vector2.up * speed);
		} else 
		{
			Destroy(gameObject);
		}	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player2") {
			pHealth.playerHealth -= pHealth.damage;
			hBar.hitpoint -= pHealth.damage;
			hBar.UpdateHealthBar();
			Debug.Log ("black just rocked you" + pHealth.playerHealth);
	
			Destroy (gameObject);
	
		}
	}
}
