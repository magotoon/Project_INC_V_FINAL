using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController1 : MonoBehaviour {

	public float speed;
	private float lifetime = 2.0f;
	public int bulletNumber;
	private HealthBar hBar;




	private GameObject player;
	private Health pHealth;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player1");
		pHealth = (Health) FindObjectOfType (typeof(Health));
		hBar = (HealthBar)FindObjectOfType (typeof(HealthBar));

		AudioSource hitsound = GetComponent<AudioSource> ();
		
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
		if (collision.gameObject.tag == "Player1") {
			pHealth.playerHealth -= pHealth.damage;
			hBar.hitpoint -= pHealth.damage;
			hBar.UpdateHealthBar();
			Debug.Log ("black just rocked you" + pHealth.playerHealth);
	
			Destroy(gameObject);
	
		}
	}
}
